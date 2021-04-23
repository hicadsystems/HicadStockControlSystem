﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace HicadStockSystem.Core.Models
{
    [Table("st_issuereq")]
    public class St_IssueRequisition
    {
        [Key]
        //remember to input stringLength at ViewModel api resource
        [StringLength(20)]
        public string ItemCode { get; set; }
        [StringLength(50)]
        public string Description { get; set; }
        [StringLength(24)]
        public string DocNo { get; set; }
        public decimal? Quantity { get; set; }
        public decimal? SupplyQty { get; set; }
        public DateTime? CreatedOn { get; set; }
        public DateTime? UpdatedOn { get; set; }
    }
}