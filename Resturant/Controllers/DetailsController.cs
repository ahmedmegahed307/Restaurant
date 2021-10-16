using Domains;
using Microsoft.AspNetCore.Mvc;
using Resturant.InfraStructure;
using Resturant.InterfaceClasses;
using Resturant.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Resturant.Controllers
{
    public class DetailsController : Controller
    {
        IProductService IProduct;
        
        public DetailsController(IProductService serve)
        {
            IProduct = serve;
          
        }
        public IActionResult Index(int id)
        {
            DetailsViewModel model = new DetailsViewModel();
            model.Product = IProduct.ProductWithImage(id);
            model.ListReviews = IProduct.ReviewsById(id);
           model.RelatedProducts = IProduct.RelatedProducts(model.Product.ProductPrice).Take(5).ToList();
            return View(model);
        }
       
    }
}
