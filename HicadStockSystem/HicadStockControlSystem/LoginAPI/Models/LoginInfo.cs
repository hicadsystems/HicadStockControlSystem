using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace LoginAPI.Models
{
    public class LoginInfo:CommonProperties
    {
        [Key]
        public int UserId { get; set; }
        [Display(Name ="Eamil Address")]
        [Required(ErrorMessage ="Eamil Address Required")]
        [EmailAddress(ErrorMessage ="Invalid Eamil Address")]
        public string EmailId { get; set; }
        [Required(ErrorMessage ="Username Required")]
        public string UserName { get; set; }
        [Required(ErrorMessage = "Password Required")]
        [StringLength(255, ErrorMessage ="Must be between 5 and 255",MinimumLength =5)]
       [DataType(DataType.Password)]
        public string Password { get; set; }
        [Required(ErrorMessage = "Password Required")]
        [DataType(DataType.Password)]
        [Compare("Password")]
        [NotMapped]
        public string ConfirmPassword { get; set; }

        public bool isMailConfirm { get; set; }

    }
}
