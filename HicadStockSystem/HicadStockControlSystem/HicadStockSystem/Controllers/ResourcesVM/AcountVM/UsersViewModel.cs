

using HicadStockSystem.Models;
using System.Collections.Generic;

namespace HicadStockSystem.Controllers.ResourcesVM.AcountVM
{
    public class UsersViewModel
    {
        public List<User> Users { get; set; }

        public IEnumerable<Role> Roles { get; set; }

    }
}
