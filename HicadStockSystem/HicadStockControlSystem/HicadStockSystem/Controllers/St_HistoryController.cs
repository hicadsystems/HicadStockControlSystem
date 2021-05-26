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
                var newStockHistory = _mapper.Map<CreateSt_HistoryVM, St_History>(historyVM);

                newStockHistory.DateCreated = DateTime.Now;

                await _history.CreateAsync(newStockHistory);

                return Ok(newStockHistory);
            }

            return BadRequest();
        }

        [HttpGet("{itemcode}")]
        public IActionResult GetIssueReqByCode(string itemcode)
        {
            var stockHistoryInDb = _history.GetByCode(itemcode);
            if (stockHistoryInDb == null)
                return NotFound();

            return Ok(stockHistoryInDb);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateIssueReq([FromBody] UpdateSt_HistoryVM historyVM)
        {
            var stockHistoryInDb = _history.GetByCode(historyVM.ItemCode);
            if (stockHistoryInDb == null)
                return NotFound();

            _mapper.Map(historyVM, stockHistoryInDb);
            stockHistoryInDb.UpdatedOn = DateTime.Now;
            await _history.UpdateAsync(stockHistoryInDb);

            return Ok(stockHistoryInDb);
        }

        [HttpPatch("{itemcode}")]
        public async Task<IActionResult> DeleteIssueReq(string itemcode)
        {
            var stockHistoryInDb = _history.GetByCode(itemcode);
            if (stockHistoryInDb == null)
                return NotFound();

            await _history.DeleteAsync(itemcode);

            return Ok(stockHistoryInDb);
        }
    }
}
