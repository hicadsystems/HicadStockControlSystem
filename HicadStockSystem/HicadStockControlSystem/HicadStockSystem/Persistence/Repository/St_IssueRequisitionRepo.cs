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
    public class St_IssueRequisitionRepo : ISt_IssueRequisition
    {
        private readonly StockControlDBContext _dbContext;
        private readonly IUnitOfWork _uow;

        public St_IssueRequisitionRepo(StockControlDBContext dbContext, IUnitOfWork uow)
        {
            _dbContext = dbContext;
            _uow = uow;
        }
        public async Task CreateAsync(St_IssueRequisition issueRequisition)
        {
            await _dbContext.St_IssueRequisitions.AddAsync(issueRequisition);
            await _uow.CompleteAsync();
        }

        public async Task<IEnumerable<St_IssueRequisition>> GetAll()
        {
            return await _dbContext.St_IssueRequisitions.ToListAsync();
        }

        public St_IssueRequisition GetByCode(string itemCode)
        {
            return _dbContext.St_IssueRequisitions.Where(ir => ir.ItemCode == itemCode).FirstOrDefault();
        }

        public async Task UpdateAsync(St_IssueRequisition issueRequisition)
        {
            _dbContext.Update(issueRequisition);
            await _uow.CompleteAsync();
        }

        public async Task UpdateAsync(string itemCode)
        {
            var issueReqInDb = GetByCode(itemCode);
            _dbContext.Update(issueReqInDb);
            await _uow.CompleteAsync();
        }

        public async Task DeleteAsync(string itemCode)
        {
            var issueReqInDb = GetByCode(itemCode);
            _dbContext.Remove(issueReqInDb);
            await _uow.CompleteAsync();
        }
    }
}
