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
    public class St_BuyerGuideRepo :  ISt_BuyerGuide
    {
        private readonly StockControlDBContext _dbcontext;
        private readonly IUnitOfWork _uow;

        public St_BuyerGuideRepo(StockControlDBContext dbcontext, IUnitOfWork uow)
        {
            _dbcontext = dbcontext;
            _uow = uow;
        }
        public async Task CreateAsync(St_BuyerGuide buyerGuide)
        {
            await _dbcontext.St_BuyerGuides.AddAsync(buyerGuide);
            await _uow.CompleteAsync();
        }

        public async Task<IEnumerable<St_BuyerGuide>> GetAll()
        {
            return await _dbcontext.St_BuyerGuides.Where(bg=>bg.IsDeleted==false).ToListAsync();
        }

        public St_BuyerGuide GetByItemCode(string code)
        {
            return _dbcontext.St_BuyerGuides.Where(bg => bg.ItemCode == code && bg.IsDeleted==false).FirstOrDefault();
        }

        public async Task UpdateAsync(St_BuyerGuide buyerGuide)
        {
            _dbcontext.Update(buyerGuide);
            await _uow.CompleteAsync();
        }

        public async Task UpdateAsync(string code)
        {
            var buyerGuideInDb = GetByItemCode(code);
            _dbcontext.Update(buyerGuideInDb);
            await _uow.CompleteAsync();
        }

        public async Task DeleteAsync(string code)
        {
            var buyerGuideInDb = GetByItemCode(code);
            buyerGuideInDb.IsDeleted=true;
            await _uow.CompleteAsync();
        }
    }
}
