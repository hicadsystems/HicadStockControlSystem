﻿using HicadStockSystem.Controllers.ResourcesVM.St_Requisition;
using HicadStockSystem.Core;
using HicadStockSystem.Core.IRespository;
using HicadStockSystem.Core.Models;
using HicadStockSystem.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HicadStockSystem.Persistence.Repository
{
    public class St_RequisitionRepo : ISt_Requisition
    {
        private readonly StockControlDBContext _dbContext;
        private readonly IUnitOfWork _uow;
        private readonly ISt_RecordTable _recordTable;

        public St_RequisitionRepo(StockControlDBContext dbContext, IUnitOfWork uow, ISt_RecordTable recordTable)
        {
            _dbContext = dbContext;
            _uow = uow;
            _recordTable = recordTable;
        }
        /*V1*/
        //public float? CheckCurrentBal(St_Requisition requisition)
        //{
        //    var updateQtyInTransit = (from stockmaster in _dbContext.St_StockMasters
        //                              where stockmaster.ItemCode == requisition.ItemCode
        //                              select stockmaster).FirstOrDefault();
        //    var currentBal = (updateQtyInTransit.OpenBalance + updateQtyInTransit.Receipts - updateQtyInTransit.Issues) - updateQtyInTransit.QtyInTransaction;

        //    return currentBal;
        //}

        public float? CheckCurrentBal(CreateSt_RequisitionVM requisition)
        {
            float? currentBal=0;
            foreach (var item in requisition.LineItems)
            {
                var updateQtyInTransit = (from stockmaster in _dbContext.St_StockMasters
                                          where stockmaster.ItemCode == item.Itemcode
                                          select stockmaster).FirstOrDefault();
                currentBal = (updateQtyInTransit.OpenBalance + updateQtyInTransit.Receipts - updateQtyInTransit.Issues) - updateQtyInTransit.QtyInTransaction;

            }
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

        //public async Task<IEnumerable<St_Requisition>> GetAll()
        //{
        //    var distinct = (from req in _dbContext.St_Requisitions select req.RequisitionNo).Distinct().ToList();
        //    return await _dbContext.St_Requisitions.Where(sr=>sr.IsDeleted==false && sr.IsApproved==false).ToListAsync();
        //}

        public async Task<IEnumerable<string>> GetAll()
        {
            var distinct = await (from req in _dbContext.St_Requisitions where req.IsApproved==false && req.IsDeleted==false  select req.RequisitionNo).Distinct().ToListAsync();
            return distinct;
        }

        public async Task<IEnumerable<St_Requisition>> GetApproved()
        {
            return await _dbContext.St_Requisitions.Where(sr => sr.IsDeleted == false && sr.IsApproved == true && sr.IsSupplied==false).ToListAsync();
        }

        public St_Requisition GetByReqNo(string reqNo)
        {
            return _dbContext.St_Requisitions.Where(sr => sr.RequisitionNo == reqNo && sr.IsDeleted==false).FirstOrDefault();
        }

        public St_Requisition GetByItemCode(string itemcode)
        {
            return _dbContext.St_Requisitions.Where(sr => sr.ItemCode == itemcode && sr.IsDeleted == false).FirstOrDefault();
        }
        //check 
        public List<St_Requisition> GetByReqNoForApproval(string reqNo)
        {
            return _dbContext.St_Requisitions.Where(sr => sr.RequisitionNo == reqNo && sr.IsDeleted == false).ToList();
        }

        public async Task UpdateAsync(St_Requisition requisition)
        {
            var stkprice = (from stockmaster in _dbContext.St_StockMasters
                            where stockmaster.ItemCode == requisition.ItemCode
                            select stockmaster.StockPrice).First();

            requisition.Price = stkprice;
            _dbContext.Update(requisition);

            var docNoParam = new SqlParameter("@docno", requisition.RequisitionNo);
            var itemcodeParam = new SqlParameter("@itemcode", requisition.ItemCode);
            var trandateParam = new SqlParameter("@trandate", requisition.SupplyDate.ToString());
            var quantityParam = new SqlParameter("@quantity", requisition.Quantity);
            var priceParam = new SqlParameter("@price", stkprice);
            var doctypeParam = new SqlParameter("@doctype", "IS");
            var supcodeParam = new SqlParameter("@supcode", "");
            var unitcodeParam = new SqlParameter("@unitcode", requisition.LocationCode);
            var user = new SqlParameter("@user", requisition.SupplyBy);
            await _dbContext.Database.ExecuteSqlRawAsync("exec st_update_transactions @docno, @itemcode, @trandate, @quantity, @price,@doctype, @supcode, @unitcode, @user",
                docNoParam, itemcodeParam, trandateParam, quantityParam, priceParam, doctypeParam, supcodeParam, unitcodeParam, user);

            requisition.Price = stkprice;

            //await _dbContext.St_Requisitions.AddAsync(requisition);
            //await _dbContext.Database.ExecuteSqlRawAsync("exec st_supply_requisition @requisitionno, @user", reqNo, user /*date*/);
            _dbContext.Update(requisition);

            //var updateQtyInTransit = (from stockmaster in _dbContext.St_StockMasters
            //                          where stockmaster.ItemCode == requisition.ItemCode
            //                          select stockmaster).FirstOrDefault();
            //updateQtyInTransit.QtyInTransaction += requisition.Quantity;

            await _uow.CompleteAsync();
        }

        public async Task RequisitioApprovalAsync(St_Requisition requisition)
        {
            requisition.IsApproved = true;
            
            requisition.ApprovedBy = "HICAD99";

            _dbContext.Update(requisition);

            //var updateQtyInTransit = (from stockmaster in _dbContext.St_StockMasters
            //                          where stockmaster.ItemCode == requisition.ItemCode
            //                          select stockmaster).FirstOrDefault();
            //updateQtyInTransit.QtyInTransaction += requisition.Quantity;

            await _uow.CompleteAsync();
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

        //public St_Requisition GetItem(string reqNo, string itemcode)
        //{
        //    return _dbContext.St_Requisitions.Where(sr => sr.RequisitionNo == reqNo && sr.IsDeleted == false).FirstOrDefault();
        //}
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
        public string GenerateRequisitionNo()
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
                //_recordTable.UpdateAsync(recordTable);
            }

            return genCode;
        }

        //incomplete
        public async Task<IEnumerable<St_ItemMaster>> GetItemCode()
        {
            return await _dbContext.St_ItemMasters.ToListAsync();
        }

        public string GetDescription(string itemCode)
        {
            return _dbContext.St_ItemMasters.Where(c => c.ItemCode == itemCode).Select(c => c.ItemDesc).FirstOrDefault();
        }

        public async Task<RequesitionVM> RequesitionsVM(string reqNo)
        {
            //var code = GetByReqNo(reqNo);
            var formatdate = new DateTime().ToString("MM/dd/yyyy HH:mm:ss");
                return await (from requisition in _dbContext.St_Requisitions
                              join item in _dbContext.St_ItemMasters on requisition.ItemCode equals item.ItemCode
                              join costCenter in _dbContext.Ac_CostCentres on requisition.LocationCode equals costCenter.UnitCode
                              where requisition.RequisitionNo == reqNo && requisition.IsDeleted == false

                              select new RequesitionVM
                              {
                                  RequisitionNo = requisition.RequisitionNo,
                                  RequisitionBy = requisition.UserId,
                                  //Department = requisition.LocationCode,
                                  Department = costCenter.UnitDesc,
                                  CostLocCode = requisition.LocationCode,
                                  DateAndTime = requisition.RequisitionDate.ToString(),
                                  ItemCode = item.ItemCode,
                                  ItemDescription = item.ItemDesc,
                                  Requested = requisition.Quantity,
                                  ItemLists = ItemLists(reqNo),
                                  DateCreated = requisition.CreatedOn.ToString(),
                                  ApprovedBy = requisition.ApprovedBy,
                                  Unit = item.Units
                              }).FirstOrDefaultAsync(); 
            
        }

        public List<ItemListVM> ItemLists(string reqNo)
        {
            return  (from requisition in _dbContext.St_Requisitions
                     join stock in _dbContext.St_StockMasters on requisition.ItemCode equals stock.ItemCode
                          where requisition.RequisitionNo == reqNo
                          select new ItemListVM
                          {
                              ItemCode = requisition.ItemCode,
                              ItemDescription = requisition.Description,
                              Requested = requisition.Quantity,
                              Unit = requisition.Unit,
                              Quantity = requisition.SupplyQty,
                              currentBalance = (stock.OpenBalance + stock.Receipts - stock.Issues) - stock.QtyInTransaction
                          }).ToList();

        }

        public St_Requisition GetByItemcode(string itemCode)
        {
            return _dbContext.St_Requisitions.Where(sr => sr.ItemCode == itemCode).FirstOrDefault();
        }
    }
}
