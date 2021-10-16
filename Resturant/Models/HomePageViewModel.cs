using Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Resturant.Models
{
    public class HomePageViewModel
    {
        public IEnumerable<TbSlider> ListSlider { get; set; }
        public IEnumerable<TbProduct> ListAllProducts { get; set; }
        public IEnumerable<TbGallery> ListGallery { get; set;}
        public IEnumerable<TbReview> ListReviews{ get; set; }
        public IEnumerable<TbProduct> ListCategory { get; set; }



    }
}
