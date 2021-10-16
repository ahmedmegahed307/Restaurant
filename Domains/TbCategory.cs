using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domains
{
 public class TbCategory
    {
        [Key]
        public int TbCategoryId { get; set; }
        [Required,MaxLength(50)]
        public string CategoryName { get; set; }
        public string CategorySlug { get; set; }
        public virtual ICollection<TbProduct> Product { get; set; }

    }
}
