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
        private readonly ISt_ItemMaster _itemMaster;

        public St_HistoryController(ISt_History history, IMapper mapper, ISt_ItemMaster itemMaster)
        {
            _history = history;
            _mapper = mapper;
            _itemMaster = itemMaster;
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
                
                var docNo = historyVM.DocNo = await _history.GenerateDocNo();

                var docNoInDb = _history.GetByDocNo(docNo);

                if (docNoInDb == null)
                {
                    foreach (var item in historyVM.LineItems)
                    {
                        historyVM.ItemCode = _itemMaster.GetItemCodeByDesc(item.ItemCode);
                        historyVM.Price = item.Price;
                        historyVM.Quantity = item.Quantity;
                        historyVM.DocType = "GR";
                        historyVM.Location = "";
                        historyVM.UserId = "HICAD1";
                        if (historyVM.DocDate == null)
                        {
                            historyVM.DocDate = DateTime.Now;
                        }
                        historyVM.DocNo = docNo;
                        historyVM.DateCreated = DateTime.Now;

                        var newStockHistory = _mapper.Map<CreateSt_HistoryVM, St_History>(historyVM);
                        //confirm if correct

                        await _history.CreateAsync(newStockHistory); 
                    }

                    return Ok(docNo);
                }
              
            }

            return BadRequest();
        }

        [Route("receiptreversal")]
        [HttpPost]
        public async Task<IActionResult> CreateReceiptReversal([FromBody] CreateSt_HistoryVM historyVM)
        {
            if (ModelState.IsValid)
            {

                //var docNo = historyVM.DocNo = await _history.GenerateDocNo();

                var docNoInDb = _history.GetItemByReceiptNo(historyVM.DocNo);
                var docNo = historyVM.DocNo + "R";

                if (!string.IsNullOrEmpty(historyVM.DocNo) && string.IsNullOrEmpty(historyVM.ItemCode))
                {
                       await _history.DeleteReversedReceiptByDocNo(historyVM.DocNo);
                    if (docNoInDb != null)
                    {
                        foreach (var item in docNoInDb)
                        {
                            historyVM.ItemCode = item.ItemCode;
                            historyVM.Price = item.Price;
                            historyVM.Quantity = -item.Quantity;
                            historyVM.DocType = "GR";
                            historyVM.Location = "";
                            historyVM.UserId = "HICAD1";
                            historyVM.Supplier = item.Supplier;
                            if (historyVM.DocDate == null)
                            {
                                historyVM.DocDate = DateTime.Now;
                            }
                            historyVM.DocNo = docNo;
                            historyVM.DateCreated = DateTime.Now;
                            

                            var newStockHistory = _mapper.Map<CreateSt_HistoryVM, St_History>(historyVM);
                            //confirm if correct

                            await _history.CreateAsync(newStockHistory);
                        }
                        

                        return Ok(docNo);
                    } 
                }
                else
                {
                    var docNoInDb1 = _history.ReverseByItemCode(historyVM.DocNo, historyVM.ItemCode);

                    historyVM.ItemCode = docNoInDb1.ItemCode;
                    historyVM.Price = docNoInDb1.Price;
                    historyVM.Quantity = -docNoInDb1.Quantity;
                    historyVM.DocType = "GR";
                    historyVM.Location = "";
                    historyVM.UserId = "HICAD1";
                    historyVM.Supplier = docNoInDb1.Supplier;
                    if (historyVM.DocDate == null)
                    {
                        historyVM.DocDate = DateTime.Now;
                    }
                    historyVM.DocNo = docNo;
                    historyVM.DateCreated = DateTime.Now;

                    var newStockHistory = _mapper.Map<CreateSt_HistoryVM, St_History>(historyVM);
                    //confirm if correct

                    await _history.CreateAsync(newStockHistory);
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
                    foreach (var item in historyVM.LineItems)
                    {
                        var returns = _mapper.Map<UpdateSt_HistoryVM, St_History>(historyVM);
                        if (historyVM.DocDate == null)
                        {
                            historyVM.DocDate = DateTime.Now;
                        }
                        //returns.UpdatedOn = DateTime.Now;
                        returns.ItemCode = _itemMaster.GetItemCodeByDesc(item.ItemCode);
                        returns.Quantity = item.Quantity;
                        returns.RemarkId = _history.GetRemarkId(item.Remark);
                        //historyVM.UserId = "HICAD3";
                        await _history.UpdateAsync(returns);

                    }
                    return Ok(); 
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

        [Route("GetReceipts")]
        [HttpGet]
        public async Task<IActionResult> GetReceipts()
        {
            var receipt = await _history.GetAllReceipt();
            return Ok(receipt);
        }

        [Route("receiptsno")]
        [HttpGet]
        public IActionResult GetReceiptsNo()
        {
            var receipt = _history.GetAllReceiptNo();
            return Ok(receipt);
        }
        [Route("getbyreceiptno/{receiptNo}")]
        [HttpGet]
        public IActionResult GetItemByReceiptNo(string receiptNo)
        {
            var receipt = _history.GetItemByReceiptNo(receiptNo);
            return Ok(receipt);
        }
    }
}
