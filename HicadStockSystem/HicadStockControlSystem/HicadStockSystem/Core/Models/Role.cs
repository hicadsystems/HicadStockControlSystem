using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace HicadStockSystem.Models
{
    public class Role:IdentityRole<int>
    {
        public string Description { get; set; }
        public bool IsActive { get; set; }
        public DateTime DateCreated { get; set; }
        public virtual ICollection<RoleMenu> RoleMenus { get; set; }
        [JsonIgnore]
        public virtual ICollection<UserRole> userRoles { get; set; }
    }
}
