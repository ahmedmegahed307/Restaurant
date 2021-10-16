using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domains
{
   public class TbProductImage
    {
        [Key]
        public int TbProductImageId { get; set; }
        [Required]
        public string ProductImageName { get; set; }
        public int ProductId { get; set; } //Foreign-Key
        public virtual TbProduct Product { get; set; }
    }
}
