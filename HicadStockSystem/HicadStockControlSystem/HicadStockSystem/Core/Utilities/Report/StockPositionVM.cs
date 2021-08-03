using HicadStockSystem.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HicadStockSystem.Core.Utilities
{
    public class StockPositionVM
    {
        
        public string ItemCode { get; set; }
        public string ItemDesc { get; set; }
        public string PartNo { get; set; }
        public float? OpenBalance { get; set; }
        public float? Receipts { get; set; }
        public float? CurrentBalance { get; set; }
        public float? Issues { get; set; }
        public decimal? Price { get; set; }
        public decimal? Value { get; set; }
        public decimal? Total { get; set; }
        public St_StockMaster StockMaster { get; set; }
    }
}
