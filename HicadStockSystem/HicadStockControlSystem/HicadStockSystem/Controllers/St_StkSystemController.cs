using HicadStockSystem.Data;
using HicadStockSystem.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HicadStockSystem.Controllers
{
    [Route("api/[controller]")] //api/st_stksystem
    [ApiController()]
    public class St_StkSystemController : ControllerBase
    {
        private readonly StockControlDBContext _dbContext;

        public St_StkSystemController(StockControlDBContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpGet]
        public async Task<IActionResult> GetStkSystem()
        {
            var stkSystem = await _dbContext.St_StkSystems.ToListAsync();
            return Ok(stkSystem);
        }

        [HttpPost]
        public async Task<IActionResult> CreateSktSystem([FromBody] St_StkSystem stkSystem)
        {
            if (ModelState.IsValid)
            {
                await _dbContext.AddAsync(stkSystem);
                await _dbContext.SaveChangesAsync();

                return CreatedAtAction("GetStkSystem", new { stkSystem.CompanyName, stkSystem.CompanyCode }, stkSystem);
            }

            return BadRequest();
        }
    }
}
