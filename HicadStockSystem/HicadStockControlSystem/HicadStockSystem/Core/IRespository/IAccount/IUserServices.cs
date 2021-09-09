using HicadStockSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace HicadStockSystem.Core.IRespository.IAccount
{
   public interface IUserServices
    {
        Task<User> User(Expression<Func<User, bool>> predicate);
        Task<User> UserWithRolesandMenus(Expression<Func<User, bool>> predicate);
        Task<User> UserWithRoles(Expression<Func<User, bool>> predicate);
    }
}
