using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LoginAPI.Models
{
    public class CommonProperties
    {
        public DateTime Datecreated { get; set; } = new DateTime (1900, 1, 1 );
        public DateTime DateUpdated { get; set; } = new DateTime(1900, 1, 1);
        public string Message { get; set; }

    }
}
