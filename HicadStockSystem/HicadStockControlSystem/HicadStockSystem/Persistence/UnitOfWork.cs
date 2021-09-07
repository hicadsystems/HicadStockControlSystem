using HicadStockSystem.Core;
using HicadStockSystem.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HicadStockSystem.Persistence
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly StockControlDBContext _dbContext;

        public UnitOfWork(StockControlDBContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task CompleteAsync()
        {
            await _dbContext.SaveChangesAsync();
        }
        public async Task<bool> DoneAsync()
        {
           return  await _dbContext.SaveChangesAsync()>0;
        }

    }
}
