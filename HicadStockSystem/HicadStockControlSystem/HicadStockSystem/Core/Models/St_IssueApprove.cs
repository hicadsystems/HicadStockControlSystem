using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace HicadStockSystem.Core.Models
{
    [Table("st_issueapprove")]
    public class St_IssueApprove
    {
        [Key]
        //remember to input stringLength at ViewModel api resource
        [StringLength(6)]
        public string ItemCode { get; set; }
        [StringLength(25)]
        public string Description { get; set; }
        [StringLength(12)]
        public string DocNo { get; set; }
        public decimal? Quantity { get; set; }
        public decimal? ApprovedQty { get; set; }
        public DateTime? CreatedOn { get; set; }
        public DateTime? UpdatedOn { get; set; }
    }
}
