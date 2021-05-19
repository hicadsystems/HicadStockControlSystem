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
    public class St_RecordTableRepo :  ISt_RecordTable
    {
        private readonly StockControlDBContext _dbContext;
        private readonly IUnitOfWork _uow;

        public St_RecordTableRepo(StockControlDBContext dbContext, IUnitOfWork uow)
        {
            _dbContext = dbContext;
            _uow = uow;
        }
        public async Task CreateAsync(St_RecordTable recordTable)
        {
            await _dbContext.St_RecordTables.AddAsync(recordTable);
            await _uow.CompleteAsync();
        }



        public async Task<IEnumerable<St_RecordTable>> GetAll()
        {
            return await _dbContext.St_RecordTables.ToListAsync();
        }

        public St_RecordTable GetByCode(string code)
        {
            return _dbContext.St_RecordTables.Where(rt => rt.Code == code).FirstOrDefault();
        }

        //public St_RecordTable GetByDocCode(string code)
        //{
        //    return _dbContext.St_RecordTables.Where(rt => rt.Code == code).FirstOrDefault();
        //}
        public async Task UpdateAsync(St_RecordTable recordTable)
        {
            _dbContext.Update(recordTable);
            await _uow.CompleteAsync();
        }

        public async Task UpdateAsync(string code)
        {
            var recordTableInDb = GetByCode(code);
            _dbContext.Update(recordTableInDb);
            await _uow.CompleteAsync();
        }

        public async Task DeleteAsync(string code)
        {
            var recordTableInDb = GetByCode(code);
            _dbContext.Remove(recordTableInDb);
            await _uow.CompleteAsync();
        }
    }
}
