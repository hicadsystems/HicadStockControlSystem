using AutoMapper;
using HicadStockSystem.Controllers.ResourcesVM;
using HicadStockSystem.Controllers.ResourcesVM.St_StockClass;
using HicadStockSystem.Core;
using HicadStockSystem.Core.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HicadStockSystem.Controllers
{
    [Route("api/stockclass")]
    [ApiController()]
    public class St_StockClassController : ControllerBase
    {
        private readonly ISt_StockClass _stockClass;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _uow;

        public St_StockClassController(ISt_StockClass stockClass, IMapper mapper, IUnitOfWork uow)
        {
            _stockClass = stockClass;
            _mapper = mapper;
            _uow = uow;
        }

        
        [HttpGet]
        public IActionResult GetSTKClass()
        {
            var stkclass = _stockClass.GetAllStkClass();
            return Ok(stkclass);
        }

        [HttpPost]
        public IActionResult CreateStockClass([FromBody] CreateStockClassVM classVM)
        {
            if (ModelState.IsValid )
            {
                //var classAlreadyExist = _stockClass.GetClassById(classVM.SktClass);
                var stockClass = _mapper.Map<CreateStockClassVM, St_StockClass>(classVM);
                //if (classAlreadyExist.Equals(stockClass.SktClass))
                //{
                //    return Content("Class Already Exist");
                //}

                stockClass.CreatedOn = DateTime.UtcNow;

                _stockClass.CreateAsync(stockClass);

                return CreatedAtAction("GetSTKClass", new { stockClass.SktClass }, stockClass);
            }

            return new JsonResult("Something went wrong. Please try again") { StatusCode = 500 };
        }

        /// <summary>
        /// could be redundant
        /// </summary>
        /// <param name="classId"></param>
        /// <returns></returns>
        [HttpGet("{classId}")]
        public IActionResult GetStockClassById(string classId)
        {
            var stockClass = _stockClass.GetClassById(classId);

            if (stockClass==null)
                return NotFound();

            return Ok(stockClass);
        }
        /// <summary>
        /// Can't update the entity since it only column is a primary key
        /// </summary>
        /// <param name="classId"></param>
        /// <returns></returns>
        //[HttpPut]
        //public IActionResult UpdateStockClass(UpdateStockClassVM classVM)
        //{
        //    var stockClass = _stockClass.GetClassById(classVM.SktClass);

        //    if (stockClass == null)
        //        return BadRequest();

        //    _mapper.Map<UpdateStockClassVM, St_StockClass>(classVM, stockClass);
        //    classVM.UpdatedOn = DateTime.UtcNow;

        //    return Ok(stockClass);
        //}
        [HttpDelete("{classId}")]
        public IActionResult DeleteStockClass(string classId)
        {
            var validStockClass = _stockClass.GetClassById(classId);

            if (validStockClass==null)
                return NotFound();

            _stockClass.Delete(classId);
            return Ok(validStockClass);
        }
    }
}
