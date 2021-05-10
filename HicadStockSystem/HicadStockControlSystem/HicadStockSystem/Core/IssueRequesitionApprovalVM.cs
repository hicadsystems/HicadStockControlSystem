using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HicadStockSystem.Core
{
    public class IssueRequesitionApprovalVM
    {
        public string RequisitionNo { get; set; }
        public string RequisitionBy { get; set; }
        public string Department { get; set; }
        public string DateAndTime { get; set; }
        public string ItemCode { get; set; }
        public string ItemDescription { get; set; }
        public float? Requested { get; set; }
    }
}
