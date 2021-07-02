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
    public class St_RemarkRepo : ISt_Remark
    {
        private readonly StockControlDBContext _context;
        private readonly IUnitOfWork _uow;

        public St_RemarkRepo(StockControlDBContext context, IUnitOfWork uow)
        {
            _context = context;
            _uow = uow;
        }

        public async Task CreateAsync(St_Remark remark)
        {
            await _context.St_Remarks.AddAsync(remark);
            await _uow.CompleteAsync();
        }

        public IEnumerable<St_Remark> GetAll()
        {
            return  _context.St_Remarks.Where(rk => rk.IsDeleted == false).ToList();
        }

        public St_Remark GetById(int id)
        {
            return _context.St_Remarks.Where(rk => rk.IsDeleted == false && rk.Id == id).FirstOrDefault();
        }

        public async Task UpdateAsync(St_Remark remark)
        {
            _context.St_Remarks.Update(remark);
            await _uow.CompleteAsync();
        }

        public async Task UpdateAsync(int id)
        {
            var remarkInDb = GetById(id);
            _context.Update(remarkInDb);
            await _uow.CompleteAsync();
        }
        public async Task DeleteAsync(int id)
        {
            var remarkInDb = GetById(id);
            remarkInDb.IsDeleted = true;
            await _uow.CompleteAsync();
        }
    }
}
