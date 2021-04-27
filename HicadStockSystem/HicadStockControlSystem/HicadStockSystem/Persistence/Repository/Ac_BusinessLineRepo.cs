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
    public class Ac_BusinessLineRepo : IAc_BusinessLine
    {
        private readonly StockControlDBContext _dbcontext;
        private readonly IUnitOfWork _uow;

        public Ac_BusinessLineRepo(StockControlDBContext dbcontext, IUnitOfWork uow)
        {
            _dbcontext = dbcontext;
            _uow = uow;
        }
        public async Task CreateAsync(Ac_BusinessLine businessLine)
        {
            await _dbcontext.Ac_BusinessLines.AddAsync(businessLine);
            await _uow.CompleteAsync();
        }

        public async Task<IEnumerable<Ac_BusinessLine>> GetAll()
        {
            return await _dbcontext.Ac_BusinessLines.ToListAsync();
        }

        public Ac_BusinessLine GetByBusLine(string busLine)
        {
            return _dbcontext.Ac_BusinessLines.Where(bl => bl.BusinessLine == busLine).FirstOrDefault();
        }

        public async Task UpdateAsync(Ac_BusinessLine businessLine)
        {
            _dbcontext.Update(businessLine);
            await _uow.CompleteAsync();
        }

        public async Task UpdateAsync(string busLine)
        {
            var busLineInDb = GetByBusLine(busLine);
            _dbcontext.Update(busLineInDb);
            await _uow.CompleteAsync();
        }
        public async Task DeleteAsync(string busLine)
        {
            var busLineInDb = GetByBusLine(busLine);
            _dbcontext.Remove(busLineInDb);
            await _uow.CompleteAsync();
        }

    }
}
