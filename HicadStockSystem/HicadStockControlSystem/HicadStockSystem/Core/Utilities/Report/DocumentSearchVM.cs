using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HicadStockSystem.Core.Utilities.Report
{
    public class DocumentSearchVM
    {
        public string DocumentNo { get; set; }
        public string DocumentType { get; set; }
        public string DocumentDate { get; set; }
        public List<ListOfItems> ListOfItems { get; set; }
        public Supplier Supplier { get; set; }
        public string UserId { get; set; }
        public Location Location { get; set; }
        //public string Remark { get; set; }
    }

    public class ListOfItems
    {
        public string ItemCode { get; set; }
        public string ItemDesc { get; set; }
        public float? Quantity { get; set; }
        public decimal? Price { get; set; }
        public decimal? Value { get; set; }
    }

    public class Supplier
    {
        public string SupplierCode { get; set; }
        public string Name { get; set; }
        public string Contact { get; set; }
        public string Phone { get; set; }
    }

    public class Location
    {
        public string LocationCode { get; set; }
        public string LocationName { get; set; }
    }


}
