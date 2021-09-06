using HicadStockSystem.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HicadStockSystem.Core.Utilities.Report
{
    public class BuyersGuide
    {
        public string ItemCode { get; set; }
        public string ItemDesc { get; set; }
        public string SupplierCode { get; set; }
        public string SupplierName { get; set; }

        public SuppliersByCode Suppliers { get; set; }
       
    }

    public class Suppliers
    {
        public string ItemCode { get; set; }
        public string SuppliersCode1 { get; set; }
        public string SuppliersCode2 { get; set; }
        public string SuppliersCode3 { get; set; }
        public string SuppliersCode4 { get; set; }
        public string SuppliersCode5 { get; set; }
    }

    //public class SuppliersByCode
    //{
    //    public St_Supplier Supplier1 { get; set; }
    //    public St_Supplier Supplier2 { get; set; }
    //    public St_Supplier Supplier3 { get; set; }
    //    public St_Supplier Supplier4 { get; set; }
    //    public St_Supplier Supplier5 { get; set; }
    //}
}
