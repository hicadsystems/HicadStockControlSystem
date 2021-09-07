using HicadStockSystem.Core;
using HicadStockSystem.Core.IRespository.IAccount;
using HicadStockSystem.Data;
using HicadStockSystem.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HicadStockSystem.Persistence.Repository
{
    public class MenuRepo : IMenuRepo
    {
        private readonly StockControlDBContext _dbcontext;
        private readonly IUnitOfWork unitOfWork;
        public MenuRepo(IUnitOfWork unitOfWork, StockControlDBContext dbcontext)
        {
            this.unitOfWork = unitOfWork;
            _dbcontext = dbcontext;
        }

        public IEnumerable<Menu> GetMenus()
        {
            return _dbcontext.Menus.ToList();
        }

        public IEnumerable<Menu> GetActiveMenus()
        {
            return _dbcontext.Menus.Where(x => x.IsActive);
        }

        public async Task<bool> AddMenu(Menu menu)
        {
            _dbcontext.Menus.Add(menu);
           return await unitOfWork.DoneAsync();
        }

        public async Task<Menu> GetMenuById(int id)
        {
            return  _dbcontext.Menus.Find(id);
        }

        public Menu GetMenuByCode(string code)
        {
            return _dbcontext.Menus.Where(x => x.Name == code).FirstOrDefault();
        }

        public async Task<bool> UpdateMenu(Menu menu)
        {
            _dbcontext.Menus.Update(menu);
           return await unitOfWork.DoneAsync();
        }
    }
}
