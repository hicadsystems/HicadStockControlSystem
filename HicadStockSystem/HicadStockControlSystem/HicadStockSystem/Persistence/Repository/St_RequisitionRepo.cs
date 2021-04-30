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
    public class St_RequisitionRepo : RepositoryMasterRepo<St_Requisition, string>, ISt_Requisition
    {
        private readonly StockControlDBContext _dbContext;
        private readonly IUnitOfWork _uow;

        public St_RequisitionRepo(StockControlDBContext dbContext, IUnitOfWork uow)
            :base(dbContext, uow)
        {
            _dbContext = dbContext;
            _uow = uow;
        }
        //public async Task CreateAsync(St_Requisition requisition)
        //{
        //    //requisition.Itemcode = RandomString(12);
        //    await _dbContext.St_Requisitions.AddAsync(requisition);
        //    await _uow.CompleteAsync();
        //}

        //public async Task<IEnumerable<St_Requisition>> GetAll()
        //{
        //    return await _dbContext.St_Requisitions.ToListAsync();
        //}

        public St_Requisition GetByReqNo(string reqNo)
        {
            return _dbContext.St_Requisitions.Where(sr => sr.RequisitionNo == reqNo).FirstOrDefault();
        }

        //public async Task UpdateAsync(St_Requisition requisition)
        //{
        //    _dbContext.Update(requisition);
        //    await _uow.CompleteAsync();
        //}

        //public async Task UpdateAsync(string reqNo)
        //{
        //    var requisitionInDb = GetByReqNo(reqNo);
        //    _dbContext.Update(requisitionInDb);
        //    await _uow.CompleteAsync();
        //}

        //public async Task DeleteAsync(string reqNo)
        //{
        //    var requisitionInDb = GetByReqNo(reqNo);
        //    _dbContext.Remove(requisitionInDb);
        //    await _uow.CompleteAsync();
        //}


        public string RandomString(int length)
        {
            Random random = new Random();
            const string chars = "0123456789";
            return new string(Enumerable.Repeat(chars, length)
              .Select(s => s[random.Next(s.Length)]).ToArray());
        }

        //public static string RandomString(int length)
        //{
        //    Random random = new Random();
        //    const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789!@%$#*&><";
        //    return new string(Enumerable.Repeat(chars, length)
        //      .Select(s => s[random.Next(s.Length)]).ToArray());
        //}
    }
}
