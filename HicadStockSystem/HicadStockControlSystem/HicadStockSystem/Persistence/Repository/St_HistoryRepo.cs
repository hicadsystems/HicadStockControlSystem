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
    public class St_HistoryRepo :  ISt_History
    {
        private readonly StockControlDBContext _dbContext;
        private readonly IUnitOfWork _uow;
        private readonly ISt_RecordTable _recordTable;

        public St_HistoryRepo(StockControlDBContext dbContext, IUnitOfWork uow, ISt_RecordTable recordTable)
        {
            _dbContext = dbContext;
            _uow = uow;
            _recordTable = recordTable;
        }
        public async Task CreateAsync(St_History history)
        {
           
            await _dbContext.St_Histories.AddAsync(history);
            //update supplier ppty in itemmaster table
            var updateItemMaster = (from itemMaster in _dbContext.St_ItemMasters
                                    where itemMaster.ItemCode == history.ItemCode
                                    select itemMaster).First();

            var receiptInDb = GetByDocNo(history.DocNo);

            if (string.IsNullOrEmpty(updateItemMaster.Supplier1) && history.ItemCode == updateItemMaster.ItemCode)
                updateItemMaster.Supplier1 = history.Supplier;

            else if (string.IsNullOrEmpty(updateItemMaster.Supplier2)
                && history.ItemCode == updateItemMaster.ItemCode)

                updateItemMaster.Supplier2 = history.Supplier;

            else if (history.Supplier == updateItemMaster.Supplier2 
                && history.Supplier != updateItemMaster.Supplier3)

                updateItemMaster.Supplier3 = history.Supplier;

            else if (history.Supplier == updateItemMaster.Supplier3
                && history.Supplier != updateItemMaster.Supplier4)
           
                updateItemMaster.Supplier4 = history.Supplier;

            else if (history.Supplier == updateItemMaster.Supplier4
                && history.Supplier != updateItemMaster.Supplier5)

                updateItemMaster.Supplier5 = history.Supplier;

            else if (history.Supplier == updateItemMaster.Supplier5
                && history.Supplier != updateItemMaster.Supplier6)

                updateItemMaster.Supplier6 = history.Supplier;

            await _uow.CompleteAsync();
        }

        public async Task<IEnumerable<St_History>> GetAll()
        {
            return await _dbContext.St_Histories.Where(h=>h.IsDeleted==false).ToListAsync();
        }

        public St_History GetByDocNo(string docNo)
        {
            return _dbContext.St_Histories.Where(h => h.DocNo == docNo && h.IsDeleted==false).FirstOrDefault();
        }

        public async Task UpdateAsync(St_History history)
        {
            _dbContext.Update(history);
            await _uow.CompleteAsync();
        }

        public async Task UpdateAsync(string itemCode)
        {
            var historyInDb = GetByDocNo(itemCode);
            _dbContext.Update(historyInDb);
            await _uow.CompleteAsync();
        }

        public async Task DeleteAsync(string itemCode)
        {
            var historyInDb = GetByDocNo(itemCode);
            historyInDb.IsDeleted=true;
            await _uow.CompleteAsync();
        }

        public string GenerateDocNo()
        {
            var date = DateTime.Now.Year.ToString().Substring(2, 2);
            var docCode = "GRR" + date + "00000";
            int docNo = 0;
            string genDocNo = "";
            var recordTable = _recordTable.GetByCode("CODE");

            if (recordTable.Code=="CODE" && recordTable.ReceiptNo < 1)
            {
                var doc_No = recordTable.ReceiptNo = docNo + 1;
                genDocNo = docCode + doc_No;
            }
            else if (recordTable.Code=="CODE" && recordTable.ReceiptNo >= 1)
            {
                docNo = recordTable.ReceiptNo;
                var newDocNo = recordTable.ReceiptNo = docNo +1;
                genDocNo = docCode + newDocNo;
            }

            return genDocNo;
        }
    }
}
