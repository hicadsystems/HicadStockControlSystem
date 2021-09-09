using HicadStockSystem.Core;
using HicadStockSystem.Core.IRespository.IAccount;
using HicadStockSystem.Data;
using HicadStockSystem.Persistence.Repository.Account;
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
            users = new UserRepo(dbContext);
        }
        public IUserServices users { get; private set; }
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
