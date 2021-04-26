using HicadStockSystem.Core;
using HicadStockSystem.Core.IRespository;
using HicadStockSystem.Core.Models;
using HicadStockSystem.Data;
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

        public IEnumerable<St_IssueRequisition> GetAll()
        {
            throw new NotImplementedException();
        }

        public St_IssueRequisition GetByCode(string itemCode)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(St_IssueRequisition issueRequisition)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(string itemCode)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(string code)
        {
            throw new NotImplementedException();
        }
    }
}
