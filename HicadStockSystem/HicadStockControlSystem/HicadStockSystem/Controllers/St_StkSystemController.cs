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
    [Route("api/st_stksystem")] //api/st_stksystem
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

            return new JsonResult("Something went wrong. Please try again") { StatusCode = 500 };
        }

        [HttpGet("{coycode}")]
        public async Task<IActionResult> GetSystem(string coycode)
        {
            var sktSystem = await _dbContext.St_StkSystems.FirstOrDefaultAsync(s => s.CompanyCode == coycode);
            if (sktSystem==null)
                return NotFound();
            return Ok(sktSystem);
        }

        [HttpPut("{coycode}")]
        public async Task<IActionResult> UpdateSktSystem(string coycode, St_StkSystem stkSystem)
        {
            var validSktSystem = await _dbContext.St_StkSystems.Where(s => (s.CompanyCode).Equals(coycode)).FirstOrDefaultAsync();

            if (validSktSystem == null)
                return NotFound();

            validSktSystem.CompanyName = stkSystem.CompanyName;
            validSktSystem.CompanyAddress = stkSystem.CompanyAddress;
            validSktSystem.Town_City = stkSystem.Town_City;
            validSktSystem.State = stkSystem.State;
            validSktSystem.Phone = stkSystem.Phone;
            validSktSystem.Email = stkSystem.Email;
            validSktSystem.SerialNumber = stkSystem.SerialNumber;
            validSktSystem.GLCode = stkSystem.GLCode;
            validSktSystem.UpdatedOn = stkSystem.UpdatedOn;

            _dbContext.SaveChanges();
            return Ok(validSktSystem);
        }

       [HttpDelete("{coycode}")]
       public async Task<IActionResult> DeleteStkSystem(string coycode)
        {
            var validStkSystem = await _dbContext.St_StkSystems.Where(c => (c.CompanyCode).Equals(coycode)).FirstOrDefaultAsync();

            if (validStkSystem == null)
                return BadRequest();
            _dbContext.Remove(validStkSystem);
            await _dbContext.SaveChangesAsync();

            return Ok(validStkSystem);
        }
    }
}
