using HicadStockSystem.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HicadStockSystem.Core.Utilities
{
    public class UnissuedRequisition
    {
        public string RequisitionNo { get; set; }
        public List<string> RequisitionList { get; set; }
        public DateTime? RequisitionAge { get; set; }

    }

    public class RequisitionNumbers
    {
        public string RequisitionNo { get; set; }

    }
}
