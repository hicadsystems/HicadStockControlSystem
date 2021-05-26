using HicadStockSystem.Core;
using HicadStockSystem.Core.IRespository;
using HicadStockSystem.Core.Models;
using HicadStockSystem.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HicadStockSystem.Persistence.Repository
{
    [ApiController()]
    [Route("api/requisition")]
    public class St_StkJournalRepo :  ISt_StkJournal
    {
        private readonly StockControlDBContext _dbContext;
        private readonly IUnitOfWork _uow;

        public St_StkJournalRepo(StockControlDBContext dbContext,IUnitOfWork uow)
        {
            _dbContext = dbContext;
            _uow = uow;
        }
        public async Task CreateAsync(St_StkJournal stkJournal)
        {
            await _dbContext.St_StkJournals.AddAsync(stkJournal);
            await _uow.CompleteAsync();
        }

        public async Task<IEnumerable<St_StkJournal>> GetAll()
        {
            return await _dbContext.St_StkJournals.Where(sj=>sj.IsDeleted==false).ToListAsync();
        }

        public St_StkJournal GetByCompany(string coy)
        {
            return _dbContext.St_StkJournals.Where(sj => sj.Stk_Company == coy && sj.IsDeleted==false).FirstOrDefault();
        }

        public async Task UpdateAsync(St_StkJournal stkJournal)
        {
            _dbContext.Update(stkJournal);
            await _uow.CompleteAsync();

        }

        public async Task UpdateAsync(string coy)
        {
            var JournalInDb = GetByCompany(coy);
            _dbContext.Update(JournalInDb);
            await _uow.CompleteAsync();
        }

        public async Task DeleteAsync(string coy)
        {
            var journalInDb = GetByCompany(coy);
            journalInDb.IsDeleted=true;
            await _uow.CompleteAsync();
        }

    }
}
