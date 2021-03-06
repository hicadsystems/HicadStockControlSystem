 using AutoMapper;
using HicadStockSystem.Controllers.ResourcesVM.St_Requisition;
using HicadStockSystem.Core;
using HicadStockSystem.Core.IRespository;
using HicadStockSystem.Core.Models;
using HicadStockSystem.Core.Utilities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.FileProviders;
using System;
using System.Collections.Generic;
using System.IO;
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
     
        private readonly string connectionstring;

        public St_RequisitionController(ISt_Requisition requisition, IMapper mapper, ISt_ItemMaster itemMaster, 
            IConfiguration configuration)
        {
            _requisition = requisition;
            _mapper = mapper;
            _itemMaster = itemMaster;
            connectionstring = configuration.GetConnectionString("DefaultConnection");
        }

        [HttpGet]
        public IActionResult GetAllRequistion()
        {
            var requisition = _requisition.GetAll();
            
            return Ok(requisition);
        }

        [HttpPost]
        public async Task<IActionResult> CreateRequisition([FromBody] CreateSt_RequisitionVM requisitionVM)
        {
            if (ModelState.IsValid)
            {
                var reqNo = requisitionVM.RequisitionNo = await _requisition.GenerateRequisitionNo();

                var requisitionNumberInDb = _requisition.GetByReqNo(reqNo);

                //check to avoid duplicate number
                if (requisitionNumberInDb == null)
                {
                    foreach (var item in requisitionVM.LineItems)
                    {
                        var currentbal = _requisition.CheckCurrentBal(item.Itemcode);
                        if (item.Quantity > currentbal || item.Quantity < 0)
                        {
                            return BadRequest("Your Request Is Invalid");
                        }
                    }
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

                    }

                    
                    return Ok(reqNo);
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

        [Route("issue")]
        [HttpPost]
        public IActionResult UpdateRequisitions([FromBody] UpdateSt_RequisitionVM requisition)
        {
            var reqNo = requisition.RequisitionNo;
            try
            {
                foreach (var item in requisition.ItemLists)
                {
                    var currentbal = _requisition.CheckCurrentBal(item.ItemCode);
                    if (item.Quantity > (decimal?)currentbal || item.Quantity > (decimal?)item.Requested ||  item.Quantity < 0)
                    {
                        return BadRequest("Your Request Is Invalid");
                    }
                }

                foreach (var item in requisition.ItemLists)
                {

                    using (SqlConnection sqlcon = new SqlConnection(connectionstring))
                    {

                        using (SqlCommand cmd = new SqlCommand("sp_UpdateRequisitionIssued", sqlcon))
                        {
                            cmd.CommandTimeout = 1200;
                            cmd.CommandType = System.Data.CommandType.StoredProcedure;
                            cmd.Parameters.Add(new SqlParameter("@reqNo", reqNo));
                            cmd.Parameters.Add(new SqlParameter("@itemcode", item.ItemCode));
                            cmd.Parameters.Add(new SqlParameter("@qty", item.Quantity));
                            cmd.Parameters.Add(new SqlParameter("@supplyqty", item.Requested));
                            cmd.Parameters.Add(new SqlParameter("@supplyby", "HICAD"));
                            cmd.Parameters.Add(new SqlParameter("@supplydate", DateTime.Now));
                            cmd.Parameters.Add(new SqlParameter("@issupplied", true));

                            sqlcon.Open();
                            cmd.ExecuteNonQuery();

                        }
                    }

                }
            }
            catch (Exception)
            {

                throw;
            }

            using (SqlConnection sqlcon = new SqlConnection(connectionstring))
            {
                using (SqlCommand cmd = new SqlCommand("st_supply_requisition", sqlcon))
                {
                    cmd.CommandTimeout = 1200;
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@requisitionno", reqNo));
                    cmd.Parameters.Add(new SqlParameter("@user", "HICAD"));
                    sqlcon.Open();
                    cmd.ExecuteNonQuery();
                }
            }

            return Ok("Record Create Succesfully");
        }

     

        [HttpPatch]
        [Route("RequisitionApproval")]
        public IActionResult RequisitionApproval([FromBody] UpdateSt_RequisitionVM requisitionVM)
        {
            var requisitioInDb = _requisition.GetByReqNo(requisitionVM.RequisitionNo);
            if (requisitioInDb == null)
            {
                return NotFound();
            }
            foreach (var item in requisitionVM.ItemLists)
            {
                var currentbal = _requisition.CheckCurrentBal(item.ItemCode);
                if (item.Quantity > (decimal)currentbal || item.Quantity < 0)
                {
                    return BadRequest("Your Request Is Invalid");
                }
            }
            foreach (var item in requisitionVM.ItemLists)
            {
                
                using (SqlConnection sqlcon = new SqlConnection(connectionstring))
                {

                    using (SqlCommand cmd = new SqlCommand("sp_UpdateRequisitionForApproval", sqlcon))
                    {
                        cmd.CommandTimeout = 1200;
                        cmd.CommandType = System.Data.CommandType.StoredProcedure;
                        cmd.Parameters.Add(new SqlParameter("@reqNo", requisitionVM.RequisitionNo));
                        cmd.Parameters.Add(new SqlParameter("@itemcode", item.ItemCode));
                        cmd.Parameters.Add(new SqlParameter("@qty", item.Quantity));
                        cmd.Parameters.Add(new SqlParameter("@isapproved", true));
                        cmd.Parameters.Add(new SqlParameter("@isdeleted", false));
                        cmd.Parameters.Add(new SqlParameter("@approvedby", "HICAD"));


                        sqlcon.Open();
                        cmd.ExecuteNonQuery();

                    }
                }
              
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
                    var requisitionInDb = _requisition.GetByReqNos(unissued.RequisitionNo);
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
                        var requisitionInDb = _requisition.GetByReqNos(item);
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
        public IActionResult RequisitionApproval(string itemCode)
        {
            var approval =  _requisition.RequesitionsVM(itemCode);
            
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
            var req = _requisition.GetAllRequisition();
            return Ok(req);
        }

        [HttpGet]
        [Route("GetApprovedRequistion")]
        public IActionResult GetApprovedRequistion()
        {
            var requisition = _requisition.GetApproved();
            return Ok(requisition);
        }
    }
}
