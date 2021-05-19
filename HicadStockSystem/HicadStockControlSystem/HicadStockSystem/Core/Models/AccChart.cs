using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HicadStockSystem.Core.Models
{
    [Table("accchart")]
    public class AccChart
    {
        [StringLength(1)]
        public string AcctCode1 { get; set; }
        [StringLength(2)]
        public string AcctCode2 { get; set; }
        [StringLength(3)]
        public string AcctCode3 { get; set; }
        [StringLength(4)]
        public string AcctCode4 { get; set; }
        [StringLength(5)]
        public string AcctCode5 { get; set; }
        [StringLength(6)]
        public string AcctCode6 { get; set; }
        [Key]
        [StringLength(15)]
        public string AcctNumber { get; set; }
        [StringLength(60)]
        public string Description { get; set; }
        [StringLength(60)]
        public string AcctCode7 { get; set; }
        [StringLength(12)]
        public string OldNumber { get; set; }
        [StringLength(2)]
        public string AccType { get; set; }
        [StringLength(1)]
        public string AcctSubtype { get; set; }
        [StringLength(100)]
        public string Address { get; set; }
        [StringLength(10)]
        public string EffDate { get; set; }
        [StringLength(20)]
        public string LedgerPasswd { get; set; }
        [StringLength(20)]
        public string LedgerPasswd2 { get; set; }
        [StringLength(6)]
        public string Subcode { get; set; }
        [StringLength(5)]
        public string BLGroup1 { get; set; }
        [StringLength(5)]
        public string BLGroup2 { get; set; }
        [StringLength(5)]
        public string BLGroup3 { get; set; }
        [StringLength(5)]
        public string BLGroup4 { get; set; }
        [StringLength(50)]
        public string BLGroupDes1 { get; set; }
        [StringLength(50)]
        public string BLGroupDes2 { get; set; }
        [StringLength(50)]
        public string BLGroupDes3 { get; set; }
        [StringLength(50)]
        public string BLGroupDes4 { get; set; }
        [StringLength(5)]
        public string BLSum1 { get; set; }
        [StringLength(5)]
        public string BLSum2 { get; set; }
        [StringLength(5)]
        public string BLSum3 { get; set; }
        [StringLength(5)]
        public string BLSum4 { get; set; }
        [StringLength(50)]
        public string BLSumDesc1 { get; set; }
        [StringLength(50)]
        public string BLSumDesc2 { get; set; }
        [StringLength(50)]
        public string BLSumDesc3 { get; set; }
        [StringLength(50)]
        public string BLSumDesc4 { get; set; }
        [StringLength(5)]
        public string CFGroup1 { get; set; }
        [StringLength(5)]
        public string CFGroup2 { get; set; }
        [StringLength(5)]
        public string CFGroup3 { get; set; }
        [StringLength(5)]
        public string CFGroup4 { get; set; }
        [StringLength(50)]
        public string CFGroupDes1 { get; set; }
        [StringLength(50)]
        public string CFGroupDes2 { get; set; }
        [StringLength(50)]
        public string CFGroupDes3 { get; set; }
        [StringLength(50)]
        public string CFGroupDes4 { get; set; }
        [StringLength(50)]
        public string CFSumDesc1 { get; set; }
        [StringLength(50)]
        public string CFSumDesc2 { get; set; }
        [StringLength(50)]
        public string CFSumDesc3 { get; set; }
        [StringLength(50)]
        public string CFSumDesc4 { get; set; }
        [StringLength(20)]
        public string CreatedBy { get; set; }
        public DateTime? DateCreated { get; set; }
        [StringLength(50)]
        public string Address1 { get; set; }
        [StringLength(50)]
        public string Address2 { get; set; }
        [StringLength(50)]
        public string Address3 { get; set; }
        [StringLength(50)]
        public string Telephone { get; set; }
        [StringLength(50)]
        public string Email { get; set; }
        [StringLength(50)]
        public string Trade { get; set; }
        public DateTime? DateBlocked { get; set; }

    }
}
