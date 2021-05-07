using HicadStockSystem.Core;
using HicadStockSystem.Core.IRespository;
using HicadStockSystem.Core.Models;
using HicadStockSystem.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HicadStockSystem.Persistence.Repository
{
    public class St_RequisitionRepo :  ISt_Requisition
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
        public async Task CreateAsync(St_Requisition requisition)
        {
            //requisition.Itemcode = RandomString(12);
            await _dbContext.St_Requisitions.AddAsync(requisition);
            await _uow.CompleteAsync();
        }

        public async Task<IEnumerable<St_Requisition>> GetAll()
        {
            return await _dbContext.St_Requisitions.ToListAsync();
        }

        public St_Requisition GetByReqNo(string reqNo)
        {
            return _dbContext.St_Requisitions.Where(sr => sr.RequisitionNo == reqNo).FirstOrDefault();
        }

        public async Task UpdateAsync(St_Requisition requisition)
        {
            _dbContext.Update(requisition);
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
            _dbContext.Remove(requisitionInDb);
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
                          where item.ItemCode==ItemCodes 
                          select new ItemStockMasterViewModel
                          {
                            itemCode=item.ItemCode,
                            unit=item.Units,
                            currentBalance=stock.QtyInTransaction,
                            ItemDesc = item.ItemDesc
                          }).FirstOrDefaultAsync();
        
        }

        //generating requisitionNo.
        public string GenerateRequisitionNo()
        {
            var dd = DateTime.Now.Year.ToString().Substring(2, 2);
            var requisitionCode = "T" + dd + "00000";
            int? requisitionno = 0;
            var genCode = "";

            var recordTable = _recordTable.GetByCode("CODE");

            if (recordTable.Code == "CODE" && recordTable.RequsitionNo < 1)
            {
                var reqNo = recordTable.RequsitionNo = requisitionno+1;
                genCode = requisitionCode + reqNo;
            }

            else if(recordTable.Code == "CODE" && recordTable.RequsitionNo >= 1)
            {
                requisitionno = recordTable.RequsitionNo;
                var newReqNo = recordTable.RequsitionNo = requisitionno+1;
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
    }
}
