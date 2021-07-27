using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HicadStockSystem.Core.Utilities
{
    public class StockLedgerVM
    {
        public string ItemCode { get; set; }
        public string ItemDesc { get; set; }
        public string TransDate { get; set; }
        public string TransactionNo { get; set; }
        public int TransQty { get; set; }
        public int CurrentQty { get; set; }
        public string DocType { get; set; }
        public decimal? Price { get; set; }
        public decimal? Value { get; set; }
        public DateTime? DateCreated { get; set; }
        public decimal? StockPrice { get; set; }
        public decimal? StockQuantity { get; set; }


    }

    public class LedgerVM
    {
        public List<StockLedgerVM> a { get; set; }
        public List<StockLedgerVM> b { get; set; }
        public string Description { get; set; }
    }
}
