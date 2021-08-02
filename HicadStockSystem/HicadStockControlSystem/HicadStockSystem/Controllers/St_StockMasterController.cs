using AutoMapper;
using HicadStockSystem.Controllers.ResourcesVM.St_StockMaster;
using HicadStockSystem.Core;
using HicadStockSystem.Core.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HicadStockSystem.Controllers
{
    [ApiController()]
    [Route("api/stockmaster")]
    public class St_StockMasterController : ControllerBase
    {
        private readonly ISt_StockMaster _stockMaster;
        private readonly IMapper _mapper;

        public St_StockMasterController(ISt_StockMaster stockMaster, IMapper mapper)
        {
            _stockMaster = stockMaster;
            _mapper = mapper;
        }
       
        [HttpGet]
        public async Task<IActionResult> GetAllStockMaster()
        
        {

            var stockMaster = await _stockMaster.GetAll();
            return Ok(stockMaster);
        }

        [HttpPost]
        public async Task<IActionResult> CreateStockMaster([FromBody]CreateStockMasterVM stockMaster)
        {
            if (ModelState.IsValid)
            {
                var newStockMaster = _mapper.Map<CreateStockMasterVM, St_StockMaster>(stockMaster);
                newStockMaster.CreatedOn = DateTime.Now;
                await _stockMaster.CreateAsync(newStockMaster);

                return CreatedAtAction("GetAllStockMaster", new { newStockMaster.ItemCode}, newStockMaster);
            }

            return BadRequest("Something went wrong please try again");
        }

        [HttpGet("{itemCode}")]
        public IActionResult GetByItemCode(string itemCode)
        {
            var stockMasterInDb = _stockMaster.GetByItemCode(itemCode);

            if (stockMasterInDb==null)
                return NotFound("Item does not exist");

            return Ok(stockMasterInDb);

        }

        [HttpPut]
        public async Task<IActionResult> UpdateStockMaster([FromBody]UpdateStockMasterVM stockMaster)
        {
            var stockMasterInDb = _stockMaster.GetByItemCode(stockMaster.ItemCode);

            if (stockMasterInDb == null)
                return NotFound("Item does not exist");

            _mapper.Map(stockMaster, stockMasterInDb);

            stockMasterInDb.UpdatedOn = DateTime.Now;

            await _stockMaster.UpdateAsync(stockMasterInDb);

            return Ok(stockMasterInDb);
        }

        [HttpPatch("{itemCode}")]
        public async Task<IActionResult> DeleteStockMaster(string itemCode)
        {
            var stockMasterInDb = _stockMaster.GetByItemCode(itemCode);

            if (stockMasterInDb == null)
                return NotFound("Item does not exist");

            await _stockMaster.Delete(itemCode);

            return Ok(stockMasterInDb);
        }

        //[Route("stockposition")]
        //[HttpGet]
        //public async Task<IActionResult> GetStockPosition()
        //{
        //    var stkposition = await _stockMaster.StockPositions();
        //    return Ok(stkposition);
        //}
    }
}
