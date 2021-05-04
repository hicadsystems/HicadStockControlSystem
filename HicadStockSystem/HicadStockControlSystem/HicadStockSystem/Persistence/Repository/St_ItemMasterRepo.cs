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
    public class St_ItemMasterRepo :  ISt_ItemMaster
    {
        private readonly StockControlDBContext _dbContext;
        private readonly IUnitOfWork _uow;

        public St_ItemMasterRepo(StockControlDBContext dbContext, IUnitOfWork uow)
        {
            _dbContext = dbContext;
            _uow = uow;
        }
        public async Task CreateAsync(St_ItemMaster itemMaster)
        {
            await _dbContext.St_ItemMasters.AddAsync(itemMaster);
            await _uow.CompleteAsync();
        }

        public async Task<IEnumerable<St_ItemMaster>> GetAll()
        {
            return await _dbContext.St_ItemMasters.ToListAsync();
        }

        public St_ItemMaster GetByCode(string itemCode)
        {
            return _dbContext.St_ItemMasters.Where(im => im.ItemCode == itemCode).FirstOrDefault();
        }

        public async Task UpdateAsync(St_ItemMaster itemMaster)
        {
            _dbContext.Update(itemMaster);
            await _uow.CompleteAsync();
        }

        public async Task UpdateAsync(string itemCode)
        {
            var itemMasterInDb = GetByCode(itemCode);
            _dbContext.Update(itemMasterInDb);
            await _uow.CompleteAsync();
        }
        public async Task DeleteAsync(string itemCode)
        {
            var itemMasterInDb = GetByCode(itemCode);
            _dbContext.Remove(itemMasterInDb);
            await _uow.CompleteAsync();
        }

        public async Task<IEnumerable<string>> GetStockClass()
        {
            return await _dbContext.St_StockClasses.Select(sc => sc.SktClass).ToListAsync();
        }

        public async Task<IEnumerable<string>> GetBusinessLine()
        {
            return await _dbContext.Ac_BusinessLines.Select(sc => sc.BusinessLine).ToListAsync();
        }
    }
}
