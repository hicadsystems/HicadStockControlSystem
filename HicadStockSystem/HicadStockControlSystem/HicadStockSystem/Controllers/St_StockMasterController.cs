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

        public St_StockMasterController(ISt_StockMaster stockMaster)
        {
            _stockMaster = stockMaster;
        }
        [HttpGet]
        public IActionResult GetStockMaster()
        {
            var stockMaster = _stockMaster.GetAllStockMaster();
            return Ok(stockMaster);
        }

        [HttpPost]
        public IActionResult CreateStockMaster([FromBody] St_StockMaster stockMaster)
        {
            if (ModelState.IsValid)
            {
                stockMaster.CreatedOn = DateTime.UtcNow;
                 _stockMaster.CreateAsync(stockMaster);

                return Ok(stockMaster);
            }

            return BadRequest();
        }

        [HttpPut("{stockMaster}")]
        public IActionResult UpdateStockMaster([FromBody]St_StockMaster stockMaster)
        {
            var stockMasterInDb = _stockMaster.GetStockByItemCode(stockMaster.ItemCode);

            if (stockMasterInDb == null)
                return NotFound();

            stockMasterInDb.UpdatedOn = DateTime.UtcNow; 
            _stockMaster.UpdateAsync(stockMasterInDb);

            return Ok();
        }

        [HttpDelete("{itemCode}")]
        public IActionResult DeleteStockMaster(string itemCode)
        {
            var stockMasterInDb = _stockMaster.GetStockByItemCode(itemCode);

            if (stockMasterInDb == null)
                return NotFound();

            _stockMaster.Delete(itemCode);

            return Ok(stockMasterInDb);
        }
    }
}
