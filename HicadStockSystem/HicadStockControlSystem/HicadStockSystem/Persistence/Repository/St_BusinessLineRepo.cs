using HicadStockSystem.Core;
using HicadStockSystem.Core.IRespository;
using HicadStockSystem.Models;
using HicadStockSystem.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HicadStockSystem.Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;

namespace HicadStockSystem.Persistence.Repository
{
    public class St_BusinessLineRepo : ISt_BusinessLine
    {
        private readonly StockControlDBContext _dbContext;
        private readonly IUnitOfWork _uow;

        public St_BusinessLineRepo(StockControlDBContext dbContext, IUnitOfWork uow)
        {
            _dbContext = dbContext;
            _uow = uow;
        }

        public async Task CreateAsync(St_BusinessLine busLine)
        {
            await _dbContext.St_BusinessLines.AddAsync(busLine);

            await _uow.CompleteAsync();
        }

        public async Task<IEnumerable<St_BusinessLine>> GetAll()
        {
            return await _dbContext.St_BusinessLines.ToListAsync(); 
        }

        public St_BusinessLine GetByBusLine(string busLine)
        {
            return _dbContext.St_BusinessLines.Where(bl => bl.BusinessLine == busLine).FirstOrDefault();
        }

        public async Task UpdateAsync(St_BusinessLine busLine)
        {
            _dbContext.Update(busLine);
            await _uow.CompleteAsync();

        }

        public async Task UpdateAsync(string busLine)
        {
            var busLineInDb = GetByBusLine(busLine);
            _dbContext.Update(busLineInDb);
            await _uow.CompleteAsync();
        }

        public async Task Delete(string busLine)
        {
            var busLineInDb = GetByBusLine(busLine);
            _dbContext.Remove(busLineInDb);
            await _uow.CompleteAsync();
        }

    }
}
