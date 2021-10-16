using Microsoft.AspNetCore.Mvc;
using Resturant.InfraStructure;
using Resturant.InterfaceClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domains;
using Resturant.Models;

namespace Resturant.Controllers
{
    public class ReviewsController : Controller
    {
        IProductService IProduct;
        ResturantContext ctx;
        public ReviewsController(IProductService serve,ResturantContext context)
        {
            IProduct = serve;
            ctx = context;
        }
        public IActionResult Reviews()
        {
            return View(ctx.Reviews.OrderByDescending(a=>a.ReviewDate).ToList());
        }

        [HttpPost]
        public IActionResult SaveReview(TbReview model,int ProductId)
        {
            ViewBag.name = model.FirstName;
            model.ProductId = ProductId;
            ctx.Reviews.Add(model);
            ctx.SaveChanges();
            return RedirectToAction("Reviews");
        }

    }
}
