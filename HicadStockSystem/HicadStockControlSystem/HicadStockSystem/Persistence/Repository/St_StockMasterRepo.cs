﻿using HicadStockSystem.Core;
using HicadStockSystem.Core.Models;
using HicadStockSystem.Data;
using HicadStockSystem.Models;
using HicadStockSystem.Repository.IRepository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HicadStockSystem.Persistence
{
    public class St_StockMasterRepo : ISt_StockMaster
    {
        private readonly StockControlDBContext _dbContext;
        private readonly IUnitOfWork _uow;

        public St_StockMasterRepo(StockControlDBContext dbContext, IUnitOfWork uow)
        {

            _dbContext = dbContext;
            _uow = uow;
        }

        public async Task CreateAsync(St_StockMaster stockMaster)
        {
            await _dbContext.St_StockMasters.AddAsync(stockMaster);
            await _uow.CompleteAsync();
        }

        public IEnumerable<St_StockMaster> GetAll()
        {
            return  _dbContext.St_StockMasters.AsNoTracking().OrderBy(sm=>sm.ItemCode);
        }

        public St_StockMaster GetByItemCode(string itemCode)
        {
            return _dbContext.St_StockMasters.Where(sm => sm.ItemCode == itemCode).FirstOrDefault();
        }

        public async Task UpdateAsync(St_StockMaster stockMaster)
        {
            _dbContext.Update(stockMaster);
            await _uow.CompleteAsync();
        }

        public async Task UpdateAsync(string itemCode)
        {
            var stockMasterInDb = GetByItemCode(itemCode);
            _dbContext.Update(stockMasterInDb);
            await _uow.CompleteAsync();
        }

        public async Task Delete(string itemCode)
        {
            var stockMasterInDb = GetByItemCode(itemCode);
            _dbContext.Remove(stockMasterInDb);
            await _uow.CompleteAsync();
        }
    }
}