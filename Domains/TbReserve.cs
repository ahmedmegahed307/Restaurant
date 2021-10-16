using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domains
{
   public class TbReserve
    {
        public int TbReserveId { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public int PhoneNumber { get; set; }
        [Required]
        public string email { get; set; }
        [Required]
        public DateTime TableDate { get; set; }
        public string TableHour { get; set; }
        [Required]
        public int NumOfPersons { get; set; }

    }
}
