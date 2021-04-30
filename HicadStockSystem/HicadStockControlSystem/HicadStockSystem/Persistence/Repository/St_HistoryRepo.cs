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
    public class St_HistoryRepo : RepositoryMasterRepo<St_History, string>, ISt_History
    {
        private readonly StockControlDBContext _dbContext;
        private readonly IUnitOfWork _uow;

        public St_HistoryRepo(StockControlDBContext dbContext, IUnitOfWork uow)
            :base(dbContext, uow)
        {
            _dbContext = dbContext;
            _uow = uow;
        }
        //public async Task CreateAsync(St_History history)
        //{

        //    await _dbContext.St_Histories.AddAsync(history);
        //    await _uow.CompleteAsync();
        //}

        //public async Task<IEnumerable<St_History>> GetAll()
        //{
        //    return await _dbContext.St_Histories.ToListAsync();
        //}

        //public St_History GetByCode(string itemCode)
        //{
        //    return _dbContext.St_Histories.Where(h => h.ItemCode == itemCode).FirstOrDefault();
        //}

        //public async Task UpdateAsync(St_History history)
        //{
        //    _dbContext.Update(history);
        //    await _uow.CompleteAsync();
        //}

        //public async Task UpdateAsync(string itemCode)
        //{
        //    var historyInDb = GetByCode(itemCode);
        //    _dbContext.Update(historyInDb);
        //    await _uow.CompleteAsync();
        //}

        //public async Task DeleteAsync(string itemCode)
        //{
        //    var historyInDb = GetByCode(itemCode);
        //    _dbContext.Remove(historyInDb);
        //    await _uow.CompleteAsync();
        //}
    }
}
