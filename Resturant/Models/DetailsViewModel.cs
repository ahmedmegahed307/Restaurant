using Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Resturant.Models
{
    public class DetailsViewModel : TbReview
    {
        public TbProduct Product { get; set; }
        public virtual IEnumerable<TbProduct> RelatedProducts { get; set; }
        public virtual IEnumerable<TbReview> ListReviews { get; set; }
    }
}
