using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;


namespace HicadStockSystem.Models
{
    public class User:IdentityUser<int>
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Password { get; set; }
        public DateTime Datecreated { get; set; }
        public List<UserRole> UserRoles { get; set; }
    }
}
