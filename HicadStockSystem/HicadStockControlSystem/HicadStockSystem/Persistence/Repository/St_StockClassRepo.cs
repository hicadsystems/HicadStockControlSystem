using HicadStockSystem.Core;
using HicadStockSystem.Core.Models;
using HicadStockSystem.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HicadStockSystem.Persistence
{
    public class St_StockClassRepo : ISt_StockClass
    {
        private readonly StockControlDBContext _dbContext;
        private readonly IUnitOfWork _uow;

        public St_StockClassRepo(StockControlDBContext dbContext, IUnitOfWork uow)
        {
            _dbContext = dbContext;
            _uow = uow;
        }

        public IEnumerable<St_StockClass> GetAllStkClass()
        {
            return _dbContext.St_StockClasses.AsNoTracking().OrderBy(c => c.SktClass);
        }

        public async Task CreateAsync(St_StockClass stockClass)
        {
            await _dbContext.St_StockClasses.AddAsync(stockClass);
            await _uow.CompleteAsync();
        }


        //public async Task UpdateAsync(St_StockClass stockClass)
        //{
        //    _dbContext.St_StockClasses.Update(stockClass);
        //    await _uow.CompleteAsync();
        //}

        public St_StockClass GetClassById(string classId)
        {
            return _dbContext.St_StockClasses.Where(c => c.SktClass == classId).FirstOrDefault();

        }

        
        public async Task Delete(string stockClass)
        {
            var stockClassInDb = GetClassById(stockClass);
            _dbContext.Remove(stockClassInDb);
            await _uow.CompleteAsync();
        }
       
    }
}
