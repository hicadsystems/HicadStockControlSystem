using HicadStockSystem.Core;
using HicadStockSystem.Core.IRespository;
using HicadStockSystem.Core.Models;
using HicadStockSystem.Data;
using HicadStockSystem.Persistence.Repository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HicadStockSystem.Persistence
{
    public class St_StockClassRepo : RepositoryMasterRepo<St_StockClassRepo, string>, ISt_StockClass
    {
        private readonly StockControlDBContext _dbContext;
        private readonly IUnitOfWork _uow;

        public St_StockClassRepo(StockControlDBContext dbContext, IUnitOfWork uow)
            :base(dbContext, uow)
        {
            _dbContext = dbContext;
            _uow = uow;
        }

        public async Task CreateAsync(St_StockClass stockClass)
        {
            await _dbContext.St_StockClasses.AddAsync(stockClass);
            await _uow.CompleteAsync();
        }

        //public async Task<IEnumerable<St_StockClass>> GetAll()
        //{
        //    return await _dbContext.St_StockClasses.ToListAsync();
        //}

        //public St_StockClass GetById(string classId)
        //{
        //    return _dbContext.St_StockClasses
        //        .Where(sc => sc.SktClass == classId)
        //        .FirstOrDefault();
        //}

        //public async Task DeleteAsync(string classId)
        //{
        //    var stockClassInDb = GetById(classId);
        //    _dbContext.Remove(stockClassInDb);
        //    await _uow.CompleteAsync();
        //}

        Task<St_StockClass> IRespositoryMaster<St_StockClass, string>.GetByCode(string key)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(St_StockClass entity)
        {
            throw new NotImplementedException();
        }

        IEnumerable<St_StockClass> IRespositoryMaster<St_StockClass, string>.GetAll()
        {
            throw new NotImplementedException();
        }

        public St_StockClass GetById(string classId)
        {
            throw new NotImplementedException();
        }
    }
}
