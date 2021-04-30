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
    public class St_IssueApproveRepo : ISt_IssueApprove
    {
        private readonly StockControlDBContext _dbContext;
        private readonly IUnitOfWork _uow;

        public St_IssueApproveRepo(StockControlDBContext dbContext, IUnitOfWork uow)
        {
            _dbContext = dbContext;
            _uow = uow;
        }
        public async Task CreateAsync(St_IssueApprove issueApprove)
        {
            
            await _dbContext.St_IssueApproves.AddAsync(issueApprove);
            await _uow.CompleteAsync();
        }

        public async Task<IEnumerable<St_IssueApprove>> GetAll()
        {
            return await _dbContext.St_IssueApproves.ToListAsync();
        }

        public St_IssueApprove GetByCode(string itemCode)
        {
            return _dbContext.St_IssueApproves.Where(ia => ia.ItemCode == itemCode).FirstOrDefault();
        }

        public async Task UpdateAsync(St_IssueApprove issueApprove)
        {
            _dbContext.Update(issueApprove);
            await _uow.CompleteAsync();
        }

        public async Task UpdateAsync(string itemCode)
        {
            var issueApproveInDb = GetByCode(itemCode);
            _dbContext.Update(issueApproveInDb);
            await _uow.CompleteAsync();
        }

        public async Task DeleteAsync(string itemCode)
        {
            var issueApproveInDb = GetByCode(itemCode);
            _dbContext.Remove(issueApproveInDb);
            await _uow.CompleteAsync();
        }
    }
}
