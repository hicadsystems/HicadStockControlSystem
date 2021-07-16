using HicadStockSystem.Core.Models;
using HicadStockSystem.Data;
using HicadStockSystem.Models;
using HicadStockSystem.Persistence.Repository;
using HicadStockSystem.Repository.IRepository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HicadStockSystem.Persistence
{
    public class St_StkSystemRepo :  ISt_StkSystem
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

        public async Task<IEnumerable<St_StkSystem>> GetAll()
        {
            return await _dbContext.St_StkSystems.Where(stk=>stk.IsDeleted==false).ToListAsync();

        }

        public St_StkSystem GetByCompanyCode(string compcode)
        {
            return _dbContext.St_StkSystems.Where(stk => stk.CompanyCode == compcode && stk.IsDeleted==false).FirstOrDefault();
        }
        public St_StkSystem GetSingle()
        {
            return _dbContext.St_StkSystems.Where(stk => stk.IsDeleted==false).FirstOrDefault();
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
            stkSystem.IsDeleted=true;
            await _dbContext.SaveChangesAsync();
        }

        public async Task<IEnumerable<StateList>> GetAllState()
        {
            return await _dbContext.StateLists.ToListAsync();
        }

        public async Task<IEnumerable<Ac_CostCentre>> GetCostCenter()
        {
            return await (from location in _dbContext.Ac_CostCentres select 
                          new Ac_CostCentre {
                              UnitCode = location.UnitCode,
                              UnitDesc = location.UnitDesc
                          }).ToListAsync();
        }

        public async Task<IEnumerable<Ac_BusinessLine>> GetBusLine()
        {
            return await (from busline in _dbContext.Ac_BusinessLines select
                          new Ac_BusinessLine { 
                              BusinessLine = busline.BusinessLine,
                              BusinessDesc = busline.BusinessDesc
                          }).ToListAsync();
        }

        public async Task<IEnumerable<AccChart>> GetAccChart()
        {
            return await (from accchart in _dbContext.AccCharts select
                          new AccChart {
                              AcctNumber = accchart.AcctNumber,
                              Description = accchart.Description
                          }).OrderBy(s=>s.Description).ToListAsync();
        }

        public async Task<IEnumerable<AccChart>> GetCreditorCode()
        {
            return await(from accchart in _dbContext.AccCharts
                         select
            new AccChart
            {
            AcctNumber = accchart.AcctNumber,
            Description = accchart.Description
            }).ToListAsync();
        }

        public async Task<IEnumerable<AccChart>> GetGLCode()
        {
            return await(from accchart in _dbContext.AccCharts
                         select
            new AccChart
            {
            AcctNumber = accchart.AcctNumber,
            Description = accchart.Description
            }).ToListAsync();
        }

        public async Task<IEnumerable<AccChart>> GetExpenseCode()
        {
             return await (from accchart in _dbContext.AccCharts select
                          new AccChart {
                              AcctNumber = accchart.AcctNumber,
                              Description = accchart.Description
                          }).ToListAsync();
        }
    }
}
