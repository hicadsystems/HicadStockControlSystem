using HicadStockSystem.Core;
using HicadStockSystem.Core.IRespository;
using HicadStockSystem.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HicadStockSystem.Persistence.Repository
{
    public class RepositoryMasterRepo<TEntity, TKey> : IRespositoryMaster<TEntity, TKey> where TEntity : class
    {
        private readonly StockControlDBContext _dbcontext;
        private readonly IUnitOfWork _uow;

        public RepositoryMasterRepo(StockControlDBContext dbcontext, IUnitOfWork uow)
        {
            _dbcontext = dbcontext;
            _uow = uow;
        }
        public async Task CreateAsync(TEntity entity)
        {
            await _dbcontext.Set<TEntity>().AddAsync(entity);
            //await _dbcontext.Set<TEntity>.AddAsync(entity);
            await _uow.CompleteAsync();
        }

        public virtual IEnumerable<TEntity> GetAll()
        {
            return  _dbcontext.Set<TEntity>().AsEnumerable();
        }

        public async virtual Task<TEntity> GetByCode(TKey code)
        {
            return await _dbcontext.Set<TEntity>().FindAsync(code);
        }

        public async Task UpdateAsync(TEntity entity)
        {
            _dbcontext.Set<TEntity>().Update(entity);
            await _uow.CompleteAsync();
        }

        public async Task UpdateAsync(TKey code)
        {
            var costCenterInDb = GetByCode(code);
            _dbcontext.Update(costCenterInDb);
            await _uow.CompleteAsync();
        }

        public async Task DeleteAsync(TKey code)
        {
            var costCenterInDb = GetByCode(code);
            _dbcontext.Remove(costCenterInDb);
            await _uow.CompleteAsync();
        }
       
    }
}
