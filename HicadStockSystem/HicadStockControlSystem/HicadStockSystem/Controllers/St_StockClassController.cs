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
       public IActionResult GetAllStockClass()
        {
            var stockClass = _stockClass.GetAll();

            return Ok(stockClass);
        }

        [HttpPost]
        public async Task<IActionResult> CreateStockClas([FromBody]CreateStockClassVM stockClassVM)
        {
            if (ModelState.IsValid)
            {
                var newStockClass = _mapper.Map<CreateStockClassVM, St_StockClass>(stockClassVM);

                newStockClass.CreatedOn = DateTime.Now;

                await _stockClass.CreateAsync(newStockClass);

                return Ok(newStockClass);
            }

            return new JsonResult("Something went wrong. Please try again") { StatusCode = 500 };
        }

        [HttpGet("{classId}")]
        public IActionResult GetStockClassById(string classId)
        {
            var stockClassInDb = _stockClass.GetById(classId);
            if (stockClassInDb == null)
                return NotFound("Stock Class does not exist");

            return Ok(stockClassInDb);
        }

        [HttpDelete("{classId}")]
        public async Task<IActionResult> DeleteStockClass(string classId) 
        {
            var stockClassInDb = _stockClass.GetById(classId);
            if (stockClassInDb == null)
                return NotFound("Stock Class does not exist");
            await _stockClass.DeleteAsync(classId);

            return Ok(classId);
        }

        
    }
}
