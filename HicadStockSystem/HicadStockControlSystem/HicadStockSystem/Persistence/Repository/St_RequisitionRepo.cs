using HicadStockSystem.Controllers.ResourcesVM.St_Requisition;
using HicadStockSystem.Core;
using HicadStockSystem.Core.IRespository;
using HicadStockSystem.Core.Models;
using HicadStockSystem.Core.Utilities;
using HicadStockSystem.Data;
using HicadStockSystem.Repository.IRepository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HicadStockSystem.Persistence.Repository
{
    public class St_RequisitionRepo : ISt_Requisition
    {
        private readonly StockControlDBContext _dbContext;
        private readonly IUnitOfWork _uow;
        private readonly ISt_RecordTable _recordTable;
        private readonly string connectionString;
        private readonly ISt_StkSystem _system;
        public St_RequisitionRepo(StockControlDBContext dbContext, IUnitOfWork uow, 
            ISt_RecordTable recordTable, IConfiguration configuration, ISt_StkSystem system)
        {
            _dbContext = dbContext;
            _uow = uow;
            _recordTable = recordTable;
            _system = system;
            connectionString = configuration.GetConnectionString("DefaultConnection");
        }
       
        public float? CheckCurrentBal(string itemcode)
        {
            var currentBal = _dbContext.St_StockMasters.Where(x => x.IsDeleted == false && x.ItemCode == itemcode)
                .Select(y => y.OpenBalance + y.Receipts - y.Issues).FirstOrDefault();
            return currentBal;
        }
        public async Task CreateAsync(St_Requisition requisition)
        {
            //requisition.Itemcode = RandomString(12);
            await _dbContext.St_Requisitions.AddAsync(requisition);

            var stockprice = (from stockmaster in _dbContext.St_StockMasters
                              where stockmaster.ItemCode == requisition.ItemCode
                              select stockmaster.StockPrice).First();

            var updateQtyInTransit = (from stockmaster in _dbContext.St_StockMasters
                                      where stockmaster.ItemCode == requisition.ItemCode
                                      select stockmaster).FirstOrDefault();

            updateQtyInTransit.QtyInTransaction += requisition.Quantity;

            requisition.Price = stockprice;
            
             
            await _uow.CompleteAsync();
        }

        public IEnumerable<St_Requisition> GetAllRequisition()
        {
            var distinct = _dbContext.St_Requisitions.Where(x=>x.IsSupplied==false && x.IsDeleted==false).ToList();
            return distinct;
        }

        public IEnumerable<string> GetAll()
        {
            var distinct = (from req in _dbContext.St_Requisitions where req.IsApproved==false && req.IsDeleted==false  select req.RequisitionNo).Distinct().ToList();
            return distinct;
        }
        public St_Requisition GetReqNo(string reqNo)
        {
            var distinct =  _dbContext.St_Requisitions.Where(x => x.RequisitionNo == reqNo).FirstOrDefault();
            return distinct;
        }

        public IEnumerable<string> GetApproved()
        {
            var reqNos = _dbContext.St_Requisitions
                .Where(req => req.IsApproved == true && req.IsDeleted == false && req.IsSupplied == false)
                .Select(y => y.RequisitionNo)
                .Distinct()
                .ToList();
            return reqNos;
        }

        public St_Requisition GetByReqNo(string reqNo)
        {
            var response = _dbContext.St_Requisitions.Where(sr => sr.RequisitionNo == reqNo && sr.IsDeleted==false).FirstOrDefault();
            return response;
        }

        public List<St_Requisition> GetByItemCode(string requisitionNo, string itemcode)
        {
            return _dbContext.St_Requisitions
                .Where(sr => sr.RequisitionNo == requisitionNo && sr.IsDeleted == false && sr.ItemCode == itemcode)
                .ToList();
        }
        //check 
        public List<St_Requisition> GetByReqNoForApproval(string reqNo)
        {
            return _dbContext.St_Requisitions.Where(sr => sr.RequisitionNo == reqNo && sr.IsDeleted == false).ToList();
        }


        public async Task RequisitioApprovalAsync(St_Requisition requisition)
        {
            using (SqlConnection sqlcon = new SqlConnection(connectionString))
            {

                using (SqlCommand cmd = new SqlCommand("sp_UpdateRequisitionForApproval", sqlcon))
                {
                    cmd.CommandTimeout = 1200;
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@reqNo", requisition.RequisitionNo));
                    cmd.Parameters.Add(new SqlParameter("@itemcode", requisition.ItemCode));
                    cmd.Parameters.Add(new SqlParameter("@qty", requisition.Quantity));
                    cmd.Parameters.Add(new SqlParameter("@isapproved", true));
                    cmd.Parameters.Add(new SqlParameter("@isdeleted", true));

                    sqlcon.Open();
                    await cmd.ExecuteNonQueryAsync();

                }
            }
        }

        public async Task UpdateAsync(string reqNo)
        {
            var requisitionInDb = GetByReqNo(reqNo);
            _dbContext.Update(requisitionInDb);
            await _uow.CompleteAsync();
        }

        public async Task DeleteAsync(string reqNo)
        {
            var requisitionInDb = GetByReqNo(reqNo);
            requisitionInDb.IsDeleted=true;
            await _uow.CompleteAsync();
        }

      
        public async Task DeleteItemAsync(string reqNo, string itemcode)
        {
            var requisitionInDb = GetByReqNo(reqNo);
            requisitionInDb.IsDeleted = true;
            await _uow.CompleteAsync();
        }




        public async Task<IEnumerable<Ac_CostCentre>> GetCostCentre()
        {
            return await _dbContext.Ac_CostCentres.ToListAsync();
        }

        public async Task<ItemStockMasterViewModel> StockItemViewModels(string ItemCodes)
        {
            return await (from item in _dbContext.St_ItemMasters
                          join stock in _dbContext.St_StockMasters on item.ItemCode equals stock.ItemCode
                          //join req in _dbContext.St_Requisitions on stock.ItemCode equals req.ItemCode
                          where item.ItemCode == ItemCodes && stock.ItemCode == ItemCodes
                          select new ItemStockMasterViewModel
                          {
                              itemCode = item.ItemCode,
                              unit = item.Units,
                              currentBalance = (stock.OpenBalance+stock.Receipts-stock.Issues) - stock.QtyInTransaction,
                              ItemDesc = item.ItemDesc
                          }).FirstOrDefaultAsync();
        }

        //generating requisitionNo.
        public async Task<string> GenerateRequisitionNo()
        {
            var dd = DateTime.Now.Year.ToString().Substring(2, 2);
            var requisitionCode = "RN" + dd + "00000";
            int requisitionno = 0;
            var genCode = "";

            var recordTable = _recordTable.GetByCode("CODE");

            if (recordTable.Code == "CODE" && recordTable.RequsitionNo < 1)
            {
                var reqNo = recordTable.RequsitionNo = requisitionno + 1;
                genCode = requisitionCode + reqNo;
            }

            else if (recordTable.Code == "CODE" && recordTable.RequsitionNo >= 1)
            {
                requisitionno = recordTable.RequsitionNo;
                var newReqNo = recordTable.RequsitionNo = requisitionno + 1;
                genCode = requisitionCode + newReqNo;

                var docNoParam = new SqlParameter("@receiptno", recordTable.ReceiptNo);
                await _dbContext.Database.ExecuteSqlRawAsync("exec sp_update_receiptno @receiptno", docNoParam);
            }

            return genCode;
        }

        //incomplete
        public IEnumerable<St_ItemMaster> GetItemCode()
        {
            return _dbContext.St_ItemMasters.ToList();
        }

        public string GetDescription(string itemCode)
        {
            return _dbContext.St_ItemMasters.Where(c => c.ItemCode == itemCode).Select(c => c.ItemDesc).FirstOrDefault();
        }

        public RequesitionVM RequesitionsVM(string reqNo)
        {
           
            var requistion = _dbContext.St_Requisitions.Where(x => x.RequisitionNo == reqNo && x.IsDeleted == false && x.IsSupplied == false)
                .Join(_dbContext.St_ItemMasters, req => req.ItemCode, item => item.ItemCode, (req, item) => new { req, item })
                .Join(_dbContext.Ac_CostCentres, reqs => reqs.req.LocationCode, cc => cc.UnitCode, (reqs, cc) => new { reqs, cc })
                .Select(y => new RequesitionVM 
                { 
                    RequisitionNo = y.reqs.req.RequisitionNo,
                    RequisitionBy = y.reqs.req.UserId,
                    Department = y.cc.UnitDesc,
                    CostLocCode = y.reqs.req.LocationCode,
                    DateAndTime = y.reqs.req.RequisitionDate.ToString(),
                    //ItemCode = y.reqs.item.ItemCode,
                    //ItemDescription = y.reqs.item.ItemDesc,
                    //Requested = y.reqs.req.Quantity,
                    ItemLists = ItemLists(reqNo),
                    DateCreated = y.reqs.req.CreatedOn.ToString(),
                    ApprovedBy = y.reqs.req.ApprovedBy,
                    Unit = y.reqs.item.Units
                }).FirstOrDefault();
            return requistion;
        }
        public St_Requisition GetByItemcode(string itemCode)
        {
            return _dbContext.St_Requisitions.Where(sr => sr.ItemCode == itemCode).FirstOrDefault();
        }

        public async Task<IEnumerable<string>> GetUnissuedReqisition()
        {
            var distinct = await (from req in _dbContext.St_Requisitions where req.IsSupplied == false && req.IsDeleted == false select req.RequisitionNo).Distinct().ToListAsync();
            return distinct;
        }
        public async Task DeleteUnissuedRequisition()
        {
            await _uow.CompleteAsync();
        }

        public async Task<IEnumerable<St_Requisition>> GetByDate(DateTime? date)
        {
            var unissuedReq = await _dbContext.St_Requisitions.Where(req => req.IsSupplied == false && req.RequisitionDate <= date && req.IsDeleted==false).ToListAsync();
            return unissuedReq;
        }
        
        public IEnumerable<St_Requisition> GetByReqNos(string reqNo)
        {
            var requisitions = _dbContext.St_Requisitions.Where(sr => sr.RequisitionNo == reqNo && sr.IsDeleted == false && sr.IsSupplied==false).ToList();
            return requisitions;
        }

        public List<ItemViewModel> ItemLists(string reqNo)
        {
            var result = _dbContext.St_Requisitions.Where(x => x.RequisitionNo == reqNo && x.IsDeleted == false)
                .Join(_dbContext.St_StockMasters, req => req.ItemCode, stk => stk.ItemCode, (req, stk) => new { req, stk })
                .Select(y => new ItemViewModel
                {
                    ItemCode=y.req.ItemCode,
                    ItemDescription = y.req.Description,
                    Requested = y.req.Quantity,
                    Unit = y.req.Unit,
                    Quantity = (decimal)y.req.Quantity,
                    currentBalance = (y.stk.OpenBalance + y.stk.Receipts - y.stk.Issues) - y.stk.QtyInTransaction
                }).ToList();

            return result;


        }

        private decimal? GetStockItemPrice(string itemcode)
        {
            try
            {

                var stkprice = _dbContext.St_StockMasters
                   .Where(x => x.ItemCode == itemcode)
                   .Select(y => y.StockPrice)
                   .First();

                return stkprice;
            }
            catch (Exception)
            {

                throw;
            }
        }

      
    }
}
