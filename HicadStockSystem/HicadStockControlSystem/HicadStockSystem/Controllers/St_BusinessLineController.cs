using AutoMapper;
using HicadStockSystem.Controllers.ResourcesVM.St_BusinessLine;
using HicadStockSystem.Core.IRespository;
using HicadStockSystem.Core.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HicadStockSystem.Controllers
{
    [ApiController()]
    [Route("api/businessline")]
    public class St_BusinessLineController : ControllerBase
    {
        private readonly ISt_BusinessLine _busLine;
        private readonly IMapper _mapper;

        public St_BusinessLineController(ISt_BusinessLine busLine, IMapper mapper)
        {
            _busLine = busLine;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllBusinessLine()
        {
            var busLine = await _busLine.GetAll();

            return Ok(busLine);
        }

        [HttpPost]
        public async Task<IActionResult> CreateBusinessLine([FromBody]CreateBusinessLineVM busLine)
        {
            if (ModelState.IsValid)
            {
                var newBusLine = _mapper.Map<CreateBusinessLineVM, St_BusinessLine>(busLine);
                newBusLine.DateCreated = DateTime.Now;

                await _busLine.CreateAsync(newBusLine);

                return Ok(newBusLine);
            }

            return new JsonResult("Something went wrong. Please try again") { StatusCode = 500 };
        }

        [HttpGet("{busLine}")]
        public IActionResult GetByBusinessLine(string busLine)
        {
            var buslineInDb = _busLine.GetByBusLine(busLine);
            if (buslineInDb == null)
                return NotFound("Sorry, Business Line you entered does not exist");

            return Ok(buslineInDb);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateBusinessLine([FromBody] UpdateBusinessLineVM busLine)
        {
            var buslineInDb = _busLine.GetByBusLine(busLine.BusinessLine);
            if (buslineInDb == null)
                return NotFound("Sorry, Business Line you entered does not exist");

            _mapper.Map(busLine, buslineInDb);

            buslineInDb.UpdatedOn = DateTime.Now;

            await _busLine.UpdateAsync(buslineInDb);

            return Ok(buslineInDb);
        }

        [HttpPatch("{busLine}")]
        public async Task<IActionResult> DeleteBusinessLine(string busLine)
        {
            var buslineInDb = _busLine.GetByBusLine(busLine);
            if (buslineInDb == null)
                return NotFound("Sorry, Business Line you entered does not exist");

            await _busLine.DeleteAsync(busLine);

            return Ok(buslineInDb);
        }
    }
}
