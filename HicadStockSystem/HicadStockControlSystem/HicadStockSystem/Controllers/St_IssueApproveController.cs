using AutoMapper;
using HicadStockSystem.Controllers.ResourcesVM.St_IssueApprove;
using HicadStockSystem.Core.IRespository;
using HicadStockSystem.Core.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HicadStockSystem.Controllers
{
    [Route("api/issueapprove")]
    [ApiController()]
    public class St_IssueApproveController : ControllerBase
    {
        private readonly ISt_IssueApprove _issueApprove;
        private readonly IMapper _mapper;

        public St_IssueApproveController(ISt_IssueApprove issueApprove, IMapper mapper)
        {
            _issueApprove = issueApprove;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllIssueReq()
        {
            var issueApprove = await _issueApprove.GetAll();
            return Ok(issueApprove);
        }

        [HttpPost]
        public async Task<IActionResult> CreateIssueReq([FromBody] CreateSt_IssueApproveVM issueApproveVM)
        {
            issueApproveVM.DocNo = _issueApprove.GenerateDocNo();
            if (ModelState.IsValid)
            {

                var newIssueApprove = _mapper.Map<CreateSt_IssueApproveVM, St_IssueApprove>(issueApproveVM);

                newIssueApprove.CreatedOn = DateTime.Now;

                await _issueApprove.CreateAsync(newIssueApprove);

                return Ok(newIssueApprove);
            }

            return BadRequest();
        }

        [HttpGet("{itemcode}")]
        public IActionResult GetIssueReqByCode(string reqNo)
        {
            var issueApproveInDb = _issueApprove.GetByCode(reqNo);
            if (issueApproveInDb == null)
                return NotFound();

            return Ok(issueApproveInDb);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateIssueReq([FromBody] UpdateSt_IssueApproveVM issueApproveVM)
        {
            var issueApproveInDb = _issueApprove.GetByCode(issueApproveVM.ItemCode);
            if (issueApproveVM == null)
                return NotFound();

            _mapper.Map(issueApproveVM, issueApproveInDb);
            issueApproveInDb.UpdatedOn = DateTime.Now;
            await _issueApprove.UpdateAsync(issueApproveInDb);

            return Ok(issueApproveInDb);
        }

        [HttpDelete("{itemcode}")]
        public async Task<IActionResult> DeleteIssueReq(string reqNo)
        {
            var issueApproveInDb = _issueApprove.GetByCode(reqNo);
            if (issueApproveInDb == null)
                return NotFound();

            await _issueApprove.DeleteAsync(reqNo);

            return Ok(issueApproveInDb);
        }

        [HttpGet]
        [Route("GetRequisition")]
        public async Task<IActionResult> GetRequisition()
        {
            var requisitions = await _issueApprove.GetRequisitions();
            return Ok(requisitions);
        }

        [HttpGet]
        [Route("RequisitionApproval/{itemCode}")]
        public async Task<IActionResult> RequisitionApproval(string itemCode)
        {
            var approval = await _issueApprove.RequesitionApprovalVM(itemCode);

            return Ok(approval);
        }
    }

}
