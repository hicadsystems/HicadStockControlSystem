using HicadStockSystem.Core;
using HicadStockSystem.Core.IRespository;
using HicadStockSystem.Core.Models;
using HicadStockSystem.Data;
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

        public St_RequisitionRepo(StockControlDBContext dbContext, IUnitOfWork uow)
        {
            _dbContext = dbContext;
            _uow = uow;
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


        public string RandomString(int length)
        {
            Random random = new Random();
            const string chars = "0123456789";
            return new string(Enumerable.Repeat(chars, length)
              .Select(s => s[random.Next(s.Length)]).ToArray());
        }

        public async Task<IEnumerable<string>> GetCostCentre()
        {
            return await _dbContext.Ac_CostCentres.Select(cc=>cc.UnitCode).ToListAsync();
        }

        public async Task<ItemStockMasterViewModel> StockItemViewModels(string ItemCodes)
        {
            return await (from item in _dbContext.St_ItemMasters
                          join stock in _dbContext.St_StockMasters on item.ItemDesc equals stock.Description
                          where item.ItemDesc==ItemCodes 
                          select new ItemStockMasterViewModel
                          {
                            ItemDescription = item.ItemDesc,
                            unit=item.Units,
                            currentBalance=stock.QtyInTransaction
                          }).FirstOrDefaultAsync();
        
        }

        //not completed yet
        public Task GenerateRequisitionNo()
        {
            var dd = DateTime.Now.Year.ToString().Substring(0, 2);
            var requisitionno = "T" + dd + "00000";
            var gg = "";

            var recordTable = _dbContext.St_RecordTables.Where(r=>r.Code=="CODE").FirstOrDefaultAsync();

            if (recordTable != null)
            {
                gg = requisitionno + recordTable;
            }
            else
            {
                gg = requisitionno + 1;
                
                _dbContext.Update(recordTable);
                _uow.CompleteAsync();
            }
            return recordTable;
        }

        public async Task<IEnumerable<string>> GetItemDesc()
        {
            return await _dbContext.St_ItemMasters.Select(c => c.ItemDesc).ToListAsync();
        }

        public St_ItemMaster GetDescription()
        {
            throw new NotImplementedException();
        }
    }
}
