using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domains
{
   public class TbReview
    {
        public int TbReviewId { get; set; }
        [Required, MaxLength(50)]
        public string FirstName { get; set; }

        public string LastName { get; set; }
        [Required]
        public string TopicName { get; set; }
        [Required]
        public string Message { get; set; }
        [Required]
        public string ReviewDate { get; set; }
        public int ProductId { get; set; }//Foreign-Key
        public TbProduct Product { get; set; }
    }
}
