using System.ComponentModel.DataAnnotations;

namespace HicadStockSystem.Controllers.ResourcesVM.AcountVM
{
    public class LoginViewModel
    {
        
        public string EmailAddress { get; set; }
        [Required]
        public string UserName { get; set; }

        [Required]
        public string Password { get; set; }

        public string Client { get; set; }

        public string MacAddress { get; set; }

    }
}
