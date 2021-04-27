﻿using AutoMapper;
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

        public  St_IssueApproveController(ISt_IssueApprove issueApprove, IMapper mapper)
        {
            _issueApprove = issueApprove;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetAllIssueReq()
        {
            var issueApprove = _issueApprove.GetAll();
            return Ok(issueApprove);
        }

        [HttpPost]
        public async Task<IActionResult> CreateIssueReq([FromBody] CreateSt_IssueApproveVM issueApproveVM)
        {
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
        public IActionResult GetIssueReqByCode(string itemcode)
        {
            var issueApproveInDb = _issueApprove.GetByCode(itemcode);
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
        public async Task<IActionResult> DeleteIssueReq(string itemcode)
        {
            var issueApproveInDb = _issueApprove.GetByCode(itemcode);
            if (issueApproveInDb == null)
                return NotFound();

            await _issueApprove.DeleteAsync(itemcode);

            return Ok(issueApproveInDb);
        }
    }
}