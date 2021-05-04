using HicadStockSystem.Core;
using HicadStockSystem.Core.IRespository;
using HicadStockSystem.Core.Models;
using HicadStockSystem.Data;
using HicadStockSystem.Persistence.Repository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HicadStockSystem.Persistence
{
    public class St_StockClassRepo :  ISt_StockClass
    {
        private readonly StockControlDBContext _dbContext;
        private readonly IUnitOfWork _uow;

        public St_StockClassRepo(StockControlDBContext dbContext, IUnitOfWork uow)
        {
            _dbContext = dbContext;
            _uow = uow;
        }

        public async Task CreateAsync(St_StockClass stockClass)
        {
            await _dbContext.St_StockClasses.AddAsync(stockClass);
            await _uow.CompleteAsync();
        }

        public async Task<IEnumerable<St_StockClass>> GetAll()
        {
            return await _dbContext.St_StockClasses.ToListAsync();
        }

        public St_StockClass GetById(string classId)
        {
            return _dbContext.St_StockClasses
                .Where(sc => sc.SktClass == classId)
                .FirstOrDefault();
        }

        public async Task DeleteAsync(string classId)
        {
            var stockClassInDb = GetById(classId);
            _dbContext.Remove(stockClassInDb);
            await _uow.CompleteAsync();
        }


    }
}
