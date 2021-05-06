using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HicadStockSystem.Core.Models
{
    public class ItemStockMasterViewModel
    {
        public string ItemDescription { get; set; }
        public string unit { get; set; }
        public float? currentBalance { get; set; }


        //public  St_StockMaster StockMaster { get; set; }
        //public St_ItemMaster ItemMaster { get; set; }

        //public IEnumerable<St_ItemMaster> ItemMasters { get; set; }
        //public IEnumerable<St_StockMaster> StockMasters { get; set; }
    }
}
