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
    public class St_StkSystemRepo : ISt_StkSystem
    {
        private readonly StockControlDBContext _dbContext;

        public St_StkSystemRepo(StockControlDBContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task CreateAsync(St_StkSystem stkSystem)
        {
            await _dbContext.St_StkSystems.AddAsync(stkSystem);
        }

        public IEnumerable<St_StkSystem> GetAll()
        {
            return _dbContext.St_StkSystems.AsNoTracking().OrderBy(sys => sys.CompanyName);

        }

        public St_StkSystem GetByCompanyCode(string compcode)
        {
            return _dbContext.St_StkSystems.Where(stk => stk.CompanyCode == compcode).FirstOrDefault();
        }

        public async Task UpdateAsync(St_StkSystem stkSystem)
        {
            
            _dbContext.Update(stkSystem);
            await _dbContext.SaveChangesAsync();
        }
        public async Task UpdateAsync(string compcode)
        {
            var stksystem = GetByCompanyCode(compcode);
            _dbContext.Update(stksystem);
            await _dbContext.SaveChangesAsync();
        }
        public async Task Delete(string compcode)
        {
            //using the GetByCompanyCode instead of repeating code 
            var stkSystem = GetByCompanyCode(compcode);
            _dbContext.Remove(stkSystem);
            await _dbContext.SaveChangesAsync();
        }

        
    }
}
