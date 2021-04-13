using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace HicadStockSystem.Models
{
    public class UserRole:IdentityUserRole<int>
    {
        [NotMapped]
        [JsonIgnore]
        public virtual User User { get; set; }
        [NotMapped]
        public virtual Role Role { get; set; }
        public bool IsActive { get; set; }
        public DateTime DateCreated { get; set; }
    }
}
