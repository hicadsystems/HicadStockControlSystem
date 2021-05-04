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
    public class St_SupplierRepo :  ISt_Supplier
    {
        private readonly StockControlDBContext _dbContext;
        private readonly IUnitOfWork _uow;

        public St_SupplierRepo(StockControlDBContext dbContext, IUnitOfWork uow)
        {
            _dbContext = dbContext;
            _uow = uow;
        }
        public async Task CreateAsync(St_Supplier supplier)
        {
            await _dbContext.St_Suppliers.AddAsync(supplier);
            await _uow.CompleteAsync();
        }

        public async Task<IEnumerable<St_Supplier>> GetAll()
        {
            return await _dbContext.St_Suppliers.ToListAsync();
        }

        public St_Supplier GetByCode(string code)
        {
            return _dbContext.St_Suppliers.Where(s => s.SupplierCode == code).FirstOrDefault();
        }

        public async Task UpdateAsync(St_Supplier supplier)
        {
            _dbContext.Update(supplier);
            await _uow.CompleteAsync();
        }

        public async Task UpdateAsync(string code)
        {
            var supplierInDb = GetByCode(code);
            _dbContext.Update(supplierInDb);
            await _uow.CompleteAsync();
        }

        public async Task DeleteAsync(string code)
        {
            var supplierInDb = GetByCode(code);
            _dbContext.Remove(supplierInDb);
            await _uow.CompleteAsync();
        }
    }
}
