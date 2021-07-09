using AutoMapper;
using HicadStockSystem.Controllers.ResourcesVM.St_Requisition;
using HicadStockSystem.Core;
using HicadStockSystem.Core.IRespository;
using HicadStockSystem.Core.Models;
using HicadStockSystem.Core.Utilities;
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
        private readonly ISt_ItemMaster _itemMaster;

        public St_RequisitionController(ISt_Requisition requisition, IMapper mapper, ISt_ItemMaster itemMaster)
        {
            _requisition = requisition;
            _mapper = mapper;
            _itemMaster = itemMaster;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllRequistion()
        {
            var requisition = await _requisition.GetAll();
            //foreach (var item in requisition)
            //{
            //    if (item.RequisitionNo.Max()>1)
            //    {

            //    }
            //}
            return Ok(requisition);
        }

        [HttpPost]
        public async Task<IActionResult> CreateRequisition([FromBody] CreateSt_RequisitionVM requisitionVM)
        {
            if (ModelState.IsValid)
            {
                var reqNo = requisitionVM.RequisitionNo = await _requisition.GenerateRequisitionNo();

                var requisitionNumberInDb = _requisition.GetByReqNo(reqNo);

                /*var checkCurrentBal = _mapper.Map<CreateSt_RequisitionVM, CreateSt_RequisitionVM>(requisitionVM);
                var currentBal = _requisition.CheckCurrentBal(checkCurrentBal);*/
                //check to avoid duplicate number
                if (requisitionNumberInDb == null)
                {
                    foreach (var item in requisitionVM.LineItems)
                    {
                        requisitionVM.UserId = "HICAD1";

                        requisitionVM.Itemcode = item.Itemcode;
                        requisitionVM.Quantity = item.Quantity;
                        requisitionVM.Unit = item.Unit;
                        requisitionVM.Description = _requisition.GetDescription(requisitionVM.Itemcode);
                        var newRequisition = _mapper.Map<CreateSt_RequisitionVM, St_Requisition>(requisitionVM);
                        newRequisition.CreatedOn = DateTime.Now;

                        newRequisition.RequisitionDate = DateTime.Now;

                        await _requisition.CreateAsync(newRequisition);

                        //check for the availability of requested quantity
                       //var checkCurrentBal = _mapper.Map<CreateSt_RequisitionVM, St_Requisition>(requisitionVM);

                    }
                    //requisitionVM.Description = _requisition.GetDescription(requisitionVM.Itemcode);

                    //check for the availability of requested quantity 
                    //var checkCurrentBal = _mapper.Map<CreateSt_RequisitionVM, St_Requisition>(requisitionVM);

                    /*var checkCurrentBal = _mapper.Map<CreateSt_RequisitionVM, CreateSt_RequisitionVM>(requisitionVM);
                    var currentBal = _requisition.CheckCurrentBal(checkCurrentBal);*/

                    //if (requisitionVM.Quantity >= currentBal)
                    //{
                    //    return BadRequest();
                    //}

                    //logged in user
                    //requisitionVM.UserId = "HICAD1";

                    //var newRequisition = _mapper.Map<CreateSt_RequisitionVM, St_Requisition>(requisitionVM);

                    //newRequisition.CreatedOn = DateTime.Now;

                    //newRequisition.RequisitionDate = DateTime.Now;

                    //await _requisition.CreateAsync(newRequisition);

                    return Ok(/*newRequisition*/);
                }


            }

            return BadRequest("Requisition already exist.. please try later");
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
            if (ModelState.IsValid)
            {
                await _requisition.UpdateAsync(requisitionVM);

                //await _requisition.SupplyRequisition(requisitionVM);
            }
            //foreach (var item in requisitionVM.ItemLists)
            //{
            //    try
            //    {

            //        requisitionVM.ItemCode = item.ItemCode;

            //        //swapping supplyqty to quantity and approved qty to supplyqty column
            //        requisitionVM.SupplyQty = (decimal?)item.Requested;
            //        requisitionVM.Quantity = (float?)item.Quantity;

            //        requisitionVM.UpdatedOn = DateTime.Now;

            //        await _requisition.UpdateAsync(requisitionVM);

            //    }
            //    catch (Exception)
            //    {

            //        throw;
            //    }

            //}

           

            return Ok(requisitionVM);
        }

        [HttpPatch]
        [Route("RequisitionApproval")]
        public async Task<IActionResult> RequisitionApproval([FromBody] UpdateSt_RequisitionVM requisitionVM)
        {
            var requisitioInDb = _requisition.GetByReqNo(requisitionVM.RequisitionNo);
            if (requisitioInDb == null)
                return BadRequest();
            foreach (var item in requisitionVM.ItemLists)
            {
                _mapper.Map(requisitionVM, requisitioInDb);
                requisitioInDb.ItemCode = item.ItemCode;
                requisitioInDb.Quantity = requisitionVM.Quantity = (float?)item.Quantity;
                requisitioInDb.Description = requisitionVM.Description = item.ItemDescription;
                requisitioInDb.Unit = requisitionVM.Unit = item.Unit;
                requisitioInDb.UpdatedOn = DateTime.Now;


                //requisitioInDb.ItemCode = item.ItemCode;
                await _requisition.RequisitioApprovalAsync(requisitioInDb);
            }

            return Ok(/*requisitioInDb*/);
        }

        [HttpPatch]
        [Route("UnapprovedItems")]
        public async Task<IActionResult> UnapprovedItems([FromBody] UpdateSt_RequisitionVM requisitionVM)
        {
            foreach (var item in requisitionVM.UnApprovedItems)
            {
                var requisitioInDb = _requisition.GetByReqNo(requisitionVM.RequisitionNo);

                if (requisitioInDb == null)
                    return BadRequest();

                _mapper.Map(requisitionVM, requisitioInDb);
                requisitioInDb.ItemCode = _itemMaster.GetItemCodeByDesc(item.ItemCode);
                requisitioInDb.Quantity = 0;
                requisitioInDb.Description = requisitionVM.Description = item.ItemDescription;
                requisitioInDb.Unit = requisitionVM.Unit = item.Unit;
                requisitioInDb.IsDeleted = true;
                requisitioInDb.UpdatedOn = DateTime.Now;

                await _requisition.RequisitioApprovalAsync(requisitioInDb);

            }
            return Ok();
        }

        [HttpPatch("{reqNo}")]
        public async Task<IActionResult> DeleteRequisition(string reqNo)
        {
            var requisitioInDb = _requisition.GetByReqNo(reqNo);
            if (requisitioInDb == null)
                return NotFound();

            await _requisition.DeleteAsync(reqNo);

            return Ok(requisitioInDb);
        } 

        [HttpPatch]
        [Route("DeleteUnissuedRequisition")]
        public async Task<IActionResult> DeleteUnissuedRequisition([FromBody] UnissuedRequisition unissued)
        {
            if (ModelState.IsValid)
            {
                if (!string.IsNullOrEmpty(unissued.RequisitionNo))
                {
                    var requisitionInDb = await _requisition.GetByReqNos(unissued.RequisitionNo);
                    foreach (var item in requisitionInDb)
                    {
                        item.IsDeleted = true;
                        await _requisition.DeleteUnissuedRequisition();
                    }
                }
                else if (unissued.RequisitionAge != null)
                {
                    var requisitionInDb = await _requisition.GetByDate(unissued.RequisitionAge);
                    foreach (var item in requisitionInDb)
                    {
                        item.IsDeleted = true;
                        await _requisition.DeleteUnissuedRequisition();
                    }
                }
                else
                {
                    foreach (var item in unissued.RequisitionList)
                    {
                        var requisitionInDb = await _requisition.GetByReqNos(item);
                        if (requisitionInDb != null)
                        {
                            foreach (var req in requisitionInDb)
                            {
                                req.IsDeleted = true;
                                await _requisition.DeleteUnissuedRequisition();
                            }

                        }
                    }

                }
            }

            return Ok(/*requisitioInDb*/);
        }

        [HttpGet]
        [Route("getcostcentre")]
        public async Task<IActionResult> GetCostCentreCode()
        {
            var costcentre = await _requisition.GetCostCentre();

            return Ok(costcentre);
        }

        [HttpGet]
        [Route("getStockItems/{itemCode}")]
        public async Task<IActionResult> GetStockItems(string itemCode)
        {
           var stockItem = await _requisition.StockItemViewModels(itemCode);
            return Ok(stockItem);
        }

        [HttpGet]
        [Route("GetUnissuedRequisitions")]
        public async Task<IActionResult> GetUnissuedRequisitions()
        {
            var itemCode = await _requisition.GetUnissuedReqisition();

            return Ok(itemCode);
        }

        [HttpGet]
        [Route("RequisitionApproval/{itemCode}")]
        public async Task<IActionResult> RequisitionApproval(string itemCode)
        {
            var approval = await _requisition.RequesitionsVM(itemCode); 

            RequisitionApprovalItems(itemCode);

            return Ok(approval);

        }

        [HttpGet]
        [Route("RequisitionApprovalItems/{reqNo}")]
        public IActionResult RequisitionApprovalItems(string reqNo)
        {
            var items =  _requisition.ItemLists(reqNo);

            return Ok(items);
        } 

        [HttpGet]
        [Route("GetUnissuedReq")]
        public IActionResult GetUnissuedReq()
        {
            //var items =  _requisition.ItemLists(reqNo);
            var req = _requisition.GetAllRequisition();
            return Ok(req);
        }

        [HttpGet]
        [Route("GetApprovedRequistion")]
        public async Task<IActionResult> GetApprovedRequistion()
        {
            var requisition = await _requisition.GetApproved();
            return Ok(requisition);
        }
    }
}
