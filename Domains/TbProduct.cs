using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Domains
{
 public class TbProduct
    {
        [Key]
        public int TbProductId { get; set; }
        [Required,MaxLength(50)]
        public string ProductName { get; set; }
        [Required]
        public decimal ProductPrice { get; set; }
        [Required]
        public string ProductImage { get; set; }

        [Required,MaxLength(200)]
        public string ProductDescription { get; set; }
        public int CategoryId { get; set; } //Foreign-Key

        public virtual ICollection<TbProductImage> FProductImage { get; set; }
        public virtual TbCategory Category { get; set; }
      public virtual ICollection<TbReview> Reviews { get; set; }
        


    }
}
