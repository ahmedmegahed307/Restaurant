using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domains;
using Resturant.InterfaceClasses;
using Resturant.InfraStructure;
using Resturant.Models;
using Microsoft.AspNetCore.Mvc;

namespace Resturant.Controllers
{
    public class CartController : Controller
    {
        ResturantContext ctx;
        IProductService IProduct;
        public CartController(ResturantContext context, IProductService service)
        {
            ctx = context;
            IProduct = service;
        }
        public IActionResult AddToCart(int id)
        {
            TbProduct item = IProduct.GetProductById(id);
            ShopingCart oShopingCart = HttpContext.Session.GetObjectFromJson<ShopingCart>("Cart");
            if (oShopingCart == null)//if I opened for the first time
                oShopingCart = new ShopingCart();
            
            ShopingCartItem shopingItem = oShopingCart.ListItems.Where(a => a.ItemId == id).FirstOrDefault();
            if (shopingItem != null)
            {
                shopingItem.Qty++;
                shopingItem.Total = shopingItem.Price * shopingItem.Qty;
            }
            else
            {
                oShopingCart.ListItems.Add(new ShopingCartItem()
                {
                    ItemId = item.TbProductId,
                    ItemName = item.ProductName,
                    ImageName = item.ProductImage,
                    Price = item.ProductPrice,
                    Qty = 1,
                    Total = item.ProductPrice
                });
            }

            oShopingCart.Total = oShopingCart.ListItems.Sum(a => a.Total);

            HttpContext.Session.SetObjectAsJson("Cart", oShopingCart);
            if (HttpContext.Request.Headers["X-Requested-With"] != "XMLHttpRequest")
                return Redirect("/Cart/Cart");

            return ViewComponent("SmallCart");
            
        }

        public IActionResult Decrease(int id)
        {
           

            ShopingCart cart = HttpContext.Session.GetObjectFromJson<ShopingCart>("Cart");

            ShopingCartItem cartItem = cart.ListItems.Where(a => a.ItemId == id).FirstOrDefault();

            if (cartItem.Qty > 1)
            {
                --cartItem.Qty;
            }
            else
            {
                cart.ListItems.RemoveAll(a => a.ItemId == id);
            }

            if (cart.ListItems.Count == 0)
            {
                HttpContext.Session.Remove("Cart");
            }
            else
            {
                HttpContext.Session.SetObjectAsJson("Cart", cart);
            }

            return RedirectToAction("Cart");
        }

        public IActionResult Cart()
        {
            ShopingCart oShopingCart = HttpContext.Session.GetObjectFromJson<ShopingCart>("Cart")?? new ShopingCart();

            return View(oShopingCart);
        }
        
        public IActionResult RemoveItem(int id)
        {
            ShopingCart oShopingCart = HttpContext.Session.GetObjectFromJson<ShopingCart>("Cart");
            oShopingCart.ListItems.Remove(oShopingCart.ListItems.Where(a => a.ItemId == id).FirstOrDefault());
            oShopingCart.Total = oShopingCart.ListItems.Sum(a => a.Total);
            HttpContext.Session.SetObjectAsJson("Cart", oShopingCart);
            return RedirectToAction("Cart");
        }
        public IActionResult CheckOut()
        {
            ShopingCart oShopingCart = HttpContext.Session.GetObjectFromJson<ShopingCart>("Cart");
           
                return View(oShopingCart);
        }
        


        [HttpPost]
        public IActionResult SaveInfo(ShopingCart model)//for checkout
        {

            ctx.checkoutdata.Add(model);
            ctx.SaveChanges();
            ViewBag.first = model.firstname;
            ViewBag.last = model.lastname;
            ViewBag.phone = model.phonenumber;
            ViewBag.email = model.emailaddress;
            ViewBag.address = model.address;
            model = HttpContext.Session.GetObjectFromJson<ShopingCart>("Cart");//yoruldum vallah

            return View("OrderSuccess", model);

        }
        public IActionResult OrderSuccess()
        {
            

            return View();
        }

        public IActionResult Clear()
        {
            HttpContext.Session.Remove("Cart");
            return Redirect(Request.Headers["Referer"].ToString());
            
        }

    }
}
