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
    public class Ac_CostCentreRepo : IAc_CostCentre
    {
        private readonly StockControlDBContext _dbcontext;
        private readonly IUnitOfWork _uow;

        public Ac_CostCentreRepo(StockControlDBContext dbcontext, IUnitOfWork uow)
        {
            _dbcontext = dbcontext;
            _uow = uow;
        }
        public async Task CreateAsync(Ac_CostCentre costCentre)
        {
            await _dbcontext.Ac_CostCentres.AddAsync(costCentre);
            await _uow.CompleteAsync();
        }

        public async Task<IEnumerable<Ac_CostCentre>> GetAll()
        {
            return await _dbcontext.Ac_CostCentres.ToListAsync();
        }

        public Ac_CostCentre GetByCode(string code)
        {
            return _dbcontext.Ac_CostCentres.Where(cc => cc.UnitCode == code).FirstOrDefault();
        }

        public async Task UpdateAsync(Ac_CostCentre costCentre)
        {
            _dbcontext.Update(costCentre);
            await _uow.CompleteAsync();
        }

        public async Task UpdateAsync(string code)
        {
            var costCenterInDb = GetByCode(code);
            _dbcontext.Update(costCenterInDb);
            await _uow.CompleteAsync();
        }

        public async Task DeleteAsync(string code)
        {
            var costCenterInDb = GetByCode(code);
            _dbcontext.Remove(costCenterInDb);
            await _uow.CompleteAsync();
        }
    }
}
