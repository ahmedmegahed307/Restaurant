using Domains;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Resturant.InfraStructure;
using Resturant.InterfaceClasses;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Resturant.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ProductController : Controller
    {
        IProductService IProduct;
        ICategorySerivce ICategory;
        ResturantContext ctx;
        public ProductController(IProductService serve, ResturantContext context, ICategorySerivce serve2)
        {
            IProduct = serve;
            ICategory = serve2;
            ctx=context;

        }
        public IActionResult List(int page=1)
        {
            int pagesize = 10;
            var products = IProduct.GetAllProducts().Skip((page - 1) * pagesize).Take(pagesize);
            ViewBag.PageNumber = page; ViewBag.PageRange = pagesize; ViewBag.TotalPages = (int)Math.Ceiling((decimal)ctx.TbProduct.Count() / pagesize);
            return View(products.ToList());
        }
        public IActionResult Edit(int ? id)
        {
            ViewBag.cat = ICategory.GetAllCategories();//drop down list
            if(id!=null)
            {
                return View(IProduct.GetProductById(Convert.ToInt32(id)));
            }
            else
            {
                return View();
            }
        }
        public async Task<IActionResult> Save(TbProduct product, List<IFormFile> Files)
        {

            foreach (var file in Files)
            {
                if (file.Length > 0)
                {
                    string ImageName = Guid.NewGuid().ToString() + ".jpg";
                    var filePaths = Path.Combine(Directory.GetCurrentDirectory(), @"wwwroot\Uploads", ImageName);
                    using (var stream = System.IO.File.Create(filePaths))
                    {
                        await file.CopyToAsync(stream);
                    }
                    product.ProductImage = ImageName;
                   
                }
            }
            if (product.TbProductId==0)
            {
                 IProduct.addproduct(product);
            }
            else
            {
                IProduct.editproduct(product);
            }
            return RedirectToAction("List");

        }
        
        public IActionResult Delete(int id)
        {
            IProduct.deleteproduct(id);
            return RedirectToAction("List");
        }
        public IActionResult ShowPhoto(int page = 1)
        {

            int pagesize = 10;
            var products = IProduct.GetAllPhotos().Skip((page - 1) * pagesize).Take(pagesize);
            ViewBag.PageNumber = page;
            ViewBag.PageRange = pagesize;
            ViewBag.TotalPages = (int)Math.Ceiling((decimal)ctx.TbProduct.Count() / pagesize);
            return View(products.ToList());
        }
        public IActionResult EditPhoto(int? id)
        {
            if (id != null)
            {


                return View(IProduct.GetPhotoById(Convert.ToInt32(id)));
            }
            else
            {
                return View();
            }
            

        }
        public IActionResult DeletePhoto(int id)
        {
            IProduct.Deletephoto(id);
            return RedirectToAction("ShowPhoto");

        }
        [HttpPost]
        public async Task<IActionResult> SavePhoto(TbProductImage photo, List<IFormFile> Files2)
        {
            foreach (var file in Files2)
            {
                if (file.Length > 0)
                {
                    string ImageName = Guid.NewGuid().ToString() + ".jpg";
                    var filePaths = Path.Combine(Directory.GetCurrentDirectory(), @"wwwroot\Uploads", ImageName);
                    using (var stream = System.IO.File.Create(filePaths))
                    {
                        await file.CopyToAsync(stream);
                    }
                    photo.ProductImageName = ImageName;
                }
            }

            IProduct.addphoto(photo);

            return RedirectToAction("ShowPhoto");
        }
        public IActionResult ProductsInProject(int page = 1)
        {
            int pagesize = 16;
            var products = IProduct.GetAllProducts().Skip((page - 1) * pagesize).Take(pagesize);
            ViewBag.PageNumber = page;
            ViewBag.PageRange = pagesize;
            ViewBag.TotalPages = (int)Math.Ceiling((decimal)ctx.TbProduct.Count() / pagesize);
            return View(products.ToList());

        }


    }
}
