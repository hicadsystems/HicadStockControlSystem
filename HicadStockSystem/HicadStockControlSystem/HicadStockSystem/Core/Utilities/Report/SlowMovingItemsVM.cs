using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HicadStockSystem.Core.Utilities.Report
{
    public class SlowMovingItemsVM
    {
        public string ItemCode { get; set; }
        public string ItemDesc { get; set; }
        public string LastIssueDate { get; set; }
        public float? LastIssueQty { get; set; }
        public float? CurrentQty { get; set; }
        public int? ReorderLevel { get; set; }
    }
}
