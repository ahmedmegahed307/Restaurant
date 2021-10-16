using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domains
{
   public class TbContact
    {
        public int TbContactId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public decimal PhoneNumber { get; set; }
        public string Email { get; set; }
        public string Message { get; set; }
    }
}
