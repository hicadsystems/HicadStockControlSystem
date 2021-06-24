using AutoMapper;
using HicadStockSystem.Controllers.ResourcesVM.St_Requisition;
using HicadStockSystem.Core;
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
                var reqNo = requisitionVM.RequisitionNo = _requisition.GenerateRequisitionNo();

                var requisitionNumberInDb = _requisition.GetByReqNo(reqNo);

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
                       var checkCurrentBal = _mapper.Map<CreateSt_RequisitionVM, St_Requisition>(requisitionVM);

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
            var requisitioInDb = _requisition.GetByReqNo(requisitionVM.RequisitionNo);
            if (requisitioInDb == null)
                return BadRequest();

            requisitionVM.Price = 0;

            _mapper.Map(requisitionVM, requisitioInDb);
            //swapping supplyqty to quantity and approved qty to supplyqty column
            requisitioInDb.SupplyQty = (decimal?)requisitionVM.Quantity;
            requisitioInDb.Quantity = (float?)requisitionVM.SupplyQty;

            requisitioInDb.IsSupplied = true;
            requisitioInDb.SupplyBy = "HICAD90";
            requisitioInDb.SupplyDate = DateTime.Now;
            requisitioInDb.UpdatedOn = DateTime.Now;

            await _requisition.UpdateAsync(requisitioInDb);

            return Ok(requisitioInDb);
        }

        [HttpPatch]
        [Route("RequisitionApproval")]
        public async Task<IActionResult>RequisitionApproval([FromBody] UpdateSt_RequisitionVM requisitionVM)
        {
            var requisitioInDb = _requisition.GetByReqNo(requisitionVM.RequisitionNo);
            if (requisitioInDb == null)
                return BadRequest();
            foreach (var item in requisitionVM.ItemLists)
            {
                requisitioInDb = _requisition.GetByItemCode(item.ItemCode);
                _mapper.Map(requisitionVM, requisitioInDb);
                //requisitioInDb.ItemCode = item.ItemCode;
                requisitioInDb.Quantity = (float?)item.Quantity;
                requisitioInDb.Description = item.ItemDescription;
                requisitioInDb.Unit = item.Unit;
                requisitioInDb.UpdatedOn = DateTime.Now;
                await _requisition.RequisitioApprovalAsync(requisitioInDb);

            }
            return Ok(requisitioInDb);
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
        [Route("getItemCode")]
        public async Task<IActionResult> GetItemCode()
        {
            var itemCode = await _requisition.GetItemCode();

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
        [Route("GetApprovedRequistion")]
        public async Task<IActionResult> GetApprovedRequistion()
        {
            var requisition = await _requisition.GetApproved();
            return Ok(requisition);
        }
    }
}
