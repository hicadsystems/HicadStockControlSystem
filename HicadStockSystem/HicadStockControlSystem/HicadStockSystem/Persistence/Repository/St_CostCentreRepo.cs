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
    public class St_CostCentreRepo : RepositoryMasterRepo<St_CostCentre, string>, ISt_CostCentre
    {
        private readonly StockControlDBContext _dbcontext;
        private readonly IUnitOfWork _uow;

        public St_CostCentreRepo(StockControlDBContext dbcontext, IUnitOfWork uow)
            :base(dbcontext, uow)
        {
            _dbcontext = dbcontext;
            _uow = uow;
        }
        //public async Task CreateAsync(St_CostCentre costCentre)
        //{
        //    await _dbcontext.St_CostCentres.AddAsync(costCentre);
        //    await _uow.CompleteAsync();
        //}

        //public async Task<IEnumerable<St_CostCentre>> GetAll()
        //{
        //    return await _dbcontext.St_CostCentres.ToListAsync();
        //}

        public St_CostCentre GetByItemCode(string code)
        {
            return _dbcontext.St_CostCentres.Where(cc => cc.UnitCode == code).FirstOrDefault();
        }

        //public async Task UpdateAsync(string code)
        //{
        //    var costCentreInDb = GetByItemCode(code);
        //    _dbcontext.Update(costCentreInDb);
        //    await _uow.CompleteAsync();
        //}

        //public async Task UpdateAsync(St_CostCentre costCentre)
        //{
        //    _dbcontext.Update(costCentre);
        //    await _uow.CompleteAsync();
        //}

        //public async Task DeleteAsync(string code)
        //{
        //    var costCentreInDb = GetByItemCode(code);
        //    _dbcontext.Remove(costCentreInDb);
        //    await _uow.CompleteAsync();
        //}
    }
}
