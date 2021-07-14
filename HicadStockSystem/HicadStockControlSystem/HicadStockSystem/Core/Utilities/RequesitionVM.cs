using HicadStockSystem.Core.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HicadStockSystem.Core
{
    public class RequesitionVM
    {
        public string RequisitionNo { get; set; }
        public string RequisitionBy { get; set; }
        public string Department { get; set; }
        public string CostLocCode { get; set; }
        public string DateCreated { get; set; }
        public string DateAndTime { get; set; }
        public string ItemCode { get; set; }
        public string ItemDescription { get; set; }
        public float? Requested { get; set; }
        public string ApprovedBy { get; set; }
        public string Unit { get; set; }
        public List<ItemViewModel> ItemLists { get; set; }

    }

    //public class ItemListViewModel
    //{
    //    public string Itemcode { get; set; }
    //    public float? Requested { get; set; }
    //    public string Unit { get; set; }
    //    public string ItemDescription { get; set; }
    //}
}
