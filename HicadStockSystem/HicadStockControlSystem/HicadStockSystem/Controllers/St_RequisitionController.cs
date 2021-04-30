using AutoMapper;
using HicadStockSystem.Controllers.ResourcesVM.St_Requisition;
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
    [Route("api/requisition")]
    public class St_RequisitionController : ControllerBase
    {
        private readonly ISt_Requisition _requisition;
        private readonly IMapper _mapper;

        public St_RequisitionController(ISt_Requisition requisition, IMapper mapper)
        {
            _requisition = requisition;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllRequistion()
        {
            var requisition = await _requisition.GetAll();
            return Ok(requisition);
        } 

        [HttpPost]
        public async Task<IActionResult> CreateRequisition([FromBody]CreateSt_RequisitionVM requisitionVM)
        {
            if (ModelState.IsValid)
            {
                var newRequisition = _mapper.Map<CreateSt_RequisitionVM, St_Requisition>(requisitionVM);
                newRequisition.CreatedOn = DateTime.Now;
               
                await _requisition.CreateAsync(newRequisition);

                return Ok(newRequisition);
            }

            return BadRequest("Something went wrong, please try again.");
        }

        [HttpGet("{reqNo}")]
        public IActionResult GetByRequistionNo(string reqNo)
        {
            var requisitonInDb = _requisition.GetByReqNo(reqNo);
            if (requisitonInDb == null)
                return NotFound("Sorry, the record does not exist");

            return Ok(requisitonInDb);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateRequisition([FromBody] UpdateSt_RequisitionVM requisitionVM)
        {
            var requisitioInDb = _requisition.GetByReqNo(requisitionVM.RequisitionNo);
            if (requisitioInDb == null)
                return NotFound("Sorry, the record does not exist");

            _mapper.Map(requisitionVM, requisitioInDb);
            requisitioInDb.UpdatedOn = DateTime.Now;
            await _requisition.UpdateAsync(requisitioInDb);

            return Ok(requisitioInDb);
        }

        [HttpDelete("{reqNo}")]
        public async Task<IActionResult> DeleteRequisition(string reqNo)
        {
            var requisitioInDb = _requisition.GetByReqNo(reqNo);
            if (requisitioInDb == null)
                return NotFound("Sorry, the record does not exist");

            await _requisition.DeleteAsync(reqNo);

            return Ok(requisitioInDb);
        }
    }
}
