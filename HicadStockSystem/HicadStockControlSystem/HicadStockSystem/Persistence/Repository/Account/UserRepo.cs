using HicadStockSystem.Core;
using HicadStockSystem.Core.IRespository.IAccount;
using HicadStockSystem.Data;
using HicadStockSystem.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace HicadStockSystem.Persistence.Repository.Account
{
    public class UserRepo: IUserServices
    {
    private readonly StockControlDBContext _dbcontext;
   // private readonly UserManager<User> userManager;
   // private readonly IUnitOfWork unitOfWork;

    public UserRepo(StockControlDBContext dbcontext)
    {
                //this.unitOfWork = unitOfWork;
                _dbcontext = dbcontext;
     }
        public async Task<User> User(Expression<Func<User, bool>> predicate)
        {
            var reu = await _dbcontext.Users
                 .Include(x => x.UserRoles)
                 .ThenInclude(x => x.Role)
                 .FirstOrDefaultAsync(predicate);
            return reu;
        }

        public async Task<User> UserWithRolesandMenus(Expression<Func<User, bool>> predicate)
        {
            return await _dbcontext.Users
                .Include(x => x.UserRoles)
                .ThenInclude(x => x.Role)
                .ThenInclude(x => x.RoleMenus)
                .ThenInclude(x => x.Menu)
                .ThenInclude(x => x.GroupMenu)
                .FirstOrDefaultAsync(predicate);
        }

        public async Task<User> UserWithRoles(Expression<Func<User, bool>> predicate)
        {
            try
            {
                var pp = await _dbcontext.Users
                .Include(x => x.UserRoles)
                .ThenInclude(x => x.Role).FirstOrDefaultAsync(predicate);
                return pp;
            }
            catch (Exception ex)
            {
            
            }
            return null;
        }
    }
}
