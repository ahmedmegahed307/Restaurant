using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domains
{
   public class TbGallery
    {
        [Key]
        public int TbGalleryId { get; set; }
        [Required]
        public string GalleryImage { get; set; }
        

    }
}
