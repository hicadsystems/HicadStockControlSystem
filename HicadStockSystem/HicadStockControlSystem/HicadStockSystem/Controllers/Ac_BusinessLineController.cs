using AutoMapper;
using HicadStockSystem.Controllers.ResourcesVM.Ac_BusinessLine;
using HicadStockSystem.Core.IRespository;
using HicadStockSystem.Core.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HicadStockSystem.Controllers
{
    [Route("api/ac_businessline")]
    [ApiController()]
    public class Ac_BusinessLineController : ControllerBase
    {
        private readonly IAc_BusinessLine _businessLine;
        private readonly IMapper _mapper;

        public Ac_BusinessLineController(IAc_BusinessLine businessLine, IMapper mapper)
        {
            _businessLine = businessLine;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAC_BusinessLine()
        {
            var busLine = await _businessLine.GetAll();
            return Ok(busLine);
        }

        [HttpPost]
        public async Task<IActionResult> CreateAC_BusinessLine([FromBody]CreateAc_BusinessLineVM businessLineVM)
        {
            if (ModelState.IsValid)
            {
                var newBusLine = _mapper.Map<CreateAc_BusinessLineVM, Ac_BusinessLine>(businessLineVM);
                newBusLine.DateCreated = DateTime.Now;
                await _businessLine.CreateAsync(newBusLine);

                return Ok(newBusLine);
            }
            return BadRequest();
        }

        [HttpGet("{busLine}")]
        public IActionResult GetByBusinessLine(string busLine)
        {
            var busLineInDb = _businessLine.GetByBusLine(busLine);
            if (busLineInDb == null)
                return NotFound();

            return Ok(busLineInDb);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateBusinessLine([FromBody]UpdateAc_BusinessLineVM businessLineVM)
        {
            var busLineInDb = _businessLine.GetByBusLine(businessLineVM.BusinessLine);
            if (busLineInDb == null)
                return NotFound();

            _mapper.Map(businessLineVM, busLineInDb);
            busLineInDb.UpdatedOn = DateTime.Now;
            await _businessLine.UpdateAsync(busLineInDb);

            return Ok(busLineInDb);

        }

        [HttpDelete("{busLine}")]
        public async Task<IActionResult> DeleteBusinessLine(string busLine)
        {
            var busLineInDb = _businessLine.GetByBusLine(busLine);
            if (busLineInDb == null)
                return NotFound();
            await _businessLine.DeleteAsync(busLine);
            return Ok(busLineInDb);
        }
    }
}
