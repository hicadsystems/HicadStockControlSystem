using HicadStockSystem.Core.Models;
using HicadStockSystem.Data;
using HicadStockSystem.Models;
using HicadStockSystem.Repository.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HicadStockSystem.Persistence
{
    public class St_StockMasterRepo : ISt_StkSystem
    {
        private readonly StockControlDBContext _dbContext;

        public St_StockMasterRepo(StockControlDBContext dbContext)
        {
            _dbContext = dbContext;
        }
        public Task CreateAsync(St_StkSystem stkSystem)
        {
            throw new NotImplementedException();
        }

        public Task Delete(string compcode)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<St_StkSystem> GetAll()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<StateList> GetAllState()
        {
            throw new NotImplementedException();
        }

        public St_StkSystem GetByCompanyCode(string compcode)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(St_StkSystem stkSystem)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(string compcode)
        {
            throw new NotImplementedException();
        }
    }
}
