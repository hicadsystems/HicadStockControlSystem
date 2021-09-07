
using HicadStockSystem.Core;
using HicadStockSystem.Core.IRespository.IAccount;
using HicadStockSystem.Data;
using HicadStockSystem.Models;
using System.Collections.Generic;
using System.Linq;

namespace HicadStockSystem.Persistence.Repository
{
    public class MenuGroupRepo : IMenuGroupRepo
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly StockControlDBContext _dbcontext;

        public MenuGroupRepo(IUnitOfWork unitOfWork, StockControlDBContext dbcontext)
        {
            this.unitOfWork = unitOfWork;
            _dbcontext = dbcontext;
        }

        public IEnumerable<GroupMenu> GetGroupMenuss()
        {
            return _dbcontext.GroupMenus.ToList();
        }

        public IEnumerable<GroupMenu> GetActiveGroupMenus()
        {
            return null;
        }
    }
}
