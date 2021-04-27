﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HicadStockSystem.Controllers.ResourcesVM.St_IssueApprove
{
    public class UpdateSt_IssueApproveVM
    {
        [Required]
        [StringLength(20)]
        public string ItemCode { get; set; }
        [StringLength(25)]
        public string Description { get; set; }
        [StringLength(12)]
        public string DocNo { get; set; }
        public decimal? Quantity { get; set; }
        public decimal? ApprovedQty { get; set; }
        //public DateTime? CreatedOn { get; set; }
        public DateTime? UpdatedOn { get; set; }
    }
}
