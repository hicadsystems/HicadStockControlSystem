using AutoMapper;
using HicadStockSystem.Controllers.ResourcesVM.St_StockMaster;
using HicadStockSystem.Core;
using HicadStockSystem.Core.Models;
using HicadStockSystem.Core.Utilities.MonthEndProcessing;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
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
        private readonly string connectionString;

        public St_StockMasterController(ISt_StockMaster stockMaster, IMapper mapper, IConfiguration configuration)
        {
            _stockMaster = stockMaster;
            _mapper = mapper;
            connectionString = configuration.GetConnectionString("DefaultConnection");
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

        [Route("physicalcount")]
        [HttpGet]
        public async Task<IActionResult> GetCountSheet()
        {
            var stkposition = await _stockMaster.PhysicalCounts();
            return Ok(stkposition);
        }

        [Route("UpdatePhysicalCount")]
        [HttpPut]
        public IActionResult UpdatePhysicalCount([FromBody] PhysicalCountVM physicalCount)
        {
            foreach (var item in physicalCount.PhysicalCountSheet)
            {

                using (SqlConnection sqlcon = new SqlConnection(connectionString))
                {
                    using (SqlCommand cmd = new SqlCommand("sp_updatephysicalcount", sqlcon))
                    {
                        cmd.CommandTimeout = 1200;
                        cmd.CommandType = System.Data.CommandType.StoredProcedure;
                        cmd.Parameters.Add(new SqlParameter("@itemcode", item.ItemCode));
                        cmd.Parameters.Add(new SqlParameter("@quantity", item.Quantity));

                        sqlcon.Open();
                        cmd.ExecuteNonQuery();
                    }
                } 
            }

            return Ok(/*stockMasterInDb*/);
        }
    }
}
