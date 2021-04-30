using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HicadStockSystem.Core.IRespository
{
    public interface IRespositoryMaster<TEntity, TKey> where TEntity : class
    {
        Task CreateAsync(TEntity entity);
        Task<TEntity> GetByCode(TKey key);
        Task UpdateAsync(TEntity entity);
        Task UpdateAsync(TKey key);
        IEnumerable<TEntity> GetAll();
        Task DeleteAsync(TKey key);
    }
}
