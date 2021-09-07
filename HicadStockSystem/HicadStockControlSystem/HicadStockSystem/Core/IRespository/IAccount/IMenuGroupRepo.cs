using HicadStockSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HicadStockSystem.Core.IRespository.IAccount
{
    public interface IMenuGroupRepo
    {
        IEnumerable<GroupMenu> GetActiveGroupMenus();
        IEnumerable<GroupMenu> GetGroupMenuss();
    }
}
