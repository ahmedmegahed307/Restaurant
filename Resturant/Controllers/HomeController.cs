using Domains;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Resturant.InfraStructure;
using Resturant.InterfaceClasses;
using Resturant.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Resturant.Controllers
{
    public class HomeController : Controller
    {
        IProductService IProduct;
        ResturantContext ctx;
        public HomeController(IProductService serve,ResturantContext context)
        {
            IProduct = serve;
            ctx = context;

        }

       
        public IActionResult Index()
        {
            HomePageViewModel model = new HomePageViewModel();
            model.ListSlider = IProduct._slider().ToList();
            model.ListGallery = IProduct.GalleryImages().ToList();
            model.ListReviews = IProduct.GetAllReviews().ToList();
            model.ListAllProducts = IProduct.GetAllProducts();
            model.ListCategory = model.ListAllProducts.GroupBy(a => a.CategoryId).Select(a => a.First()).ToList();
            return View(model);
        }
        public async Task<IActionResult> ProductsByCategory(string categorySlug, int page = 1)
        {
            TbCategory category = await ctx.TbCategory.Where(x => x.CategorySlug == categorySlug).FirstOrDefaultAsync();
            if (category == null) return RedirectToAction("Index");

            int pageSize = 8;
            var products = ctx.TbProduct.Where(x => x.CategoryId == category.TbCategoryId).Skip((page - 1) * pageSize).Take(pageSize);

            ViewBag.PageNumber = page;
            ViewBag.PageRange = pageSize;
            ViewBag.TotalPages = (int)Math.Ceiling((decimal)ctx.TbProduct.Where(x => x.CategoryId == category.TbCategoryId).Count() / pageSize);
            ViewBag.CategoryName = category.CategoryName;
            ViewBag.CategorySlug = categorySlug;

            return View(await products.ToListAsync());
        }
        public IActionResult test()
        {
            
            
            
            return View();
        }

       
       
    }
}
