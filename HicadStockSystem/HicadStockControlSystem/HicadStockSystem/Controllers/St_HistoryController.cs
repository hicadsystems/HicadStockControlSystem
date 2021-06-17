using AutoMapper;
using HicadStockSystem.Controllers.ResourcesVM.St_History;
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
    [Route("api/stockhistory")]
    [ApiController()]
    public class St_HistoryController : ControllerBase
    {
        private readonly ISt_History _history;
        private readonly IMapper _mapper;

        public St_HistoryController(ISt_History history, IMapper mapper)
        {
            _history = history;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllIssueReq()
        {
            var stockHistory = await _history.GetAll();
            return Ok(stockHistory);
        }

        [HttpPost]
        public async Task<IActionResult> CreateIssueReq([FromBody] CreateSt_HistoryVM historyVM)
        {
            if (ModelState.IsValid)
            {
                
                var docNo = historyVM.DocNo = _history.GenerateDocNo();
                var docNoInDb = _history.GetByDocNo(docNo);
                if (docNoInDb == null)
                {
                    historyVM.DocType = "GR";
                    historyVM.Location = "";
                    historyVM.UserId = "HICAD1";
                    if (historyVM.DocDate==null)
                    {
                        historyVM.DocDate = DateTime.Now;
                    }
                    historyVM.DocNo = docNo;
                    historyVM.DateCreated = DateTime.Now;

                    var newStockHistory = _mapper.Map<CreateSt_HistoryVM, St_History>(historyVM);
                    //confirm if correct

                    await _history.CreateAsync(newStockHistory);

                    return Ok(newStockHistory);
                }
              
            }

            return BadRequest();
        }

        [HttpGet("{itemcode}")]
        public IActionResult GetIssueReqByCode(string docNo)
        {
            var stockHistoryInDb = _history.GetByDocNo(docNo);
            if (stockHistoryInDb == null)
                return NotFound();

            return Ok(stockHistoryInDb);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateIssueReq([FromBody] UpdateSt_HistoryVM historyVM)
        {
            var docNo = historyVM.DocNo = _history.ReturnNo();

            var stockHistoryInDb = _history.GetByDocNo(docNo);

            if (ModelState.IsValid)
            {
                //var stockHistoryInDb = _history.GetByDocNo(historyVM.DocNo);
                if (stockHistoryInDb == null)
                {
                    var returns = _mapper.Map<UpdateSt_HistoryVM, St_History>(historyVM);
                    if (historyVM.DocDate == null)
                    {
                        historyVM.DocDate = DateTime.Now;
                    }
                    historyVM.UpdatedOn = DateTime.Now;
                    //historyVM.UserId = "HICAD3";
                    await _history.UpdateAsync(returns);

                    return Ok(returns);
                } 
            }
                return BadRequest();

        }

        [HttpPatch("{itemcode}")]
        public async Task<IActionResult> DeleteIssueReq(string docNo)
        {
            var stockHistoryInDb = _history.GetByDocNo(docNo);
            if (stockHistoryInDb == null)
                return NotFound();

            await _history.DeleteAsync(docNo);

            return Ok(stockHistoryInDb);
        }
    }
}
