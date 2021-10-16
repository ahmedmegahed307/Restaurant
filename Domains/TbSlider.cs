using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domains
{
   public class TbSlider
    {
       
        public int TbSliderId { get; set; }
        [Required,MaxLength(50)]
        public string SliderTitle { get; set; }
        [Required, MaxLength(200)]
        public string SliderDescription { get; set; }
        [Required]
        public string SliderImage { get; set; }
    }
}
