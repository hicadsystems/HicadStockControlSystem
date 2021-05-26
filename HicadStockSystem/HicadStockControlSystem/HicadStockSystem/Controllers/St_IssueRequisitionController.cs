using AutoMapper;
using HicadStockSystem.Controllers.ResourcesVM.St_IssueRequisition;
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
    [Route("api/issuerequisition")]
    public class St_IssueRequisitionController : ControllerBase
    {
        private readonly ISt_IssueRequisition _IssueReq;
        private readonly IMapper _mapper;
        public St_IssueRequisitionController(ISt_IssueRequisition IssueReq, IMapper mapper)
        {
            _IssueReq = IssueReq;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllIssueReq()
        {
            var IssueReq = await _IssueReq.GetAll();
            return Ok(IssueReq);
        }

        [HttpPost]
        public async Task<IActionResult> CreateIssueReq([FromBody] CreateSt_IssueRequisitionVM issueReqVM)
        {
            if (ModelState.IsValid)
            {
                var newIssueReq = _mapper.Map<CreateSt_IssueRequisitionVM, St_IssueRequisition>(issueReqVM);

                newIssueReq.CreatedOn = DateTime.Now;

                await _IssueReq.CreateAsync(newIssueReq);

                return Ok(newIssueReq);
            }

            return BadRequest();
        }

        [HttpGet("{itemcode}")]
        public IActionResult GetIssueReqByCode(string itemcode)
        {
            var IssueReqInDb = _IssueReq.GetByCode(itemcode);
            if (IssueReqInDb == null)
                return NotFound();

            return Ok(IssueReqInDb);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateIssueReq([FromBody] UpdateSt_IssueRequisitionVM issueReqVM)
        {
            var issueReqInDb = _IssueReq.GetByCode(issueReqVM.ItemCode);
            if (issueReqInDb == null)
                return NotFound();

            _mapper.Map(issueReqVM, issueReqInDb);
            issueReqInDb.UpdatedOn = DateTime.Now;
            await _IssueReq.UpdateAsync(issueReqInDb);

            return Ok(issueReqInDb);
        }

        [HttpPatch("{itemcode}")]
        public async Task<IActionResult> DeleteIssueReq(string itemcode)
        {
            var issueReqInDb = _IssueReq.GetByCode(itemcode);
            if (issueReqInDb == null)
                return NotFound();

            await _IssueReq.DeleteAsync(itemcode);

            return Ok(issueReqInDb);
        }

    }
}
