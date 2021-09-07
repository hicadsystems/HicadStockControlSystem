using HicadStockSystem.Models;
using System.Collections.Generic;

namespace HicadStockSystem.Controllers.ResourcesVM.AcountVM
{
    public class RolesViewModel
    {
        public IEnumerable<Role> Roles { get; set; }
        public IEnumerable<Menu> Menus { get; set; }
    }
}
