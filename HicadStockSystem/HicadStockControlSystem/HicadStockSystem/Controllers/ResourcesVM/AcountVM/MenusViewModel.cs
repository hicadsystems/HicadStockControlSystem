using HicadStockSystem.Models;
using System.Collections.Generic;

namespace HicadStockSystem.Controllers.ResourcesVM.AcountVM
{ 
    public class MenusViewModel
    {
        public IEnumerable<Menu> Menus { get; set; }
        public IEnumerable<GroupMenu> MenuGroups { get; set; }
    }
}
