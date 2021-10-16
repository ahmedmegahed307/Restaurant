using Resturant.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domains;
using Resturant.InfraStructure;

namespace Resturant.Infrastructure
{
    public class SmallCartCountViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            ShopingCart cart = HttpContext.Session.GetObjectFromJson<ShopingCart>("Cart");
            SmallCartViewModel model;
            if(cart==null||cart.ListItems.Count==0)
            {
                model = null;
            }
            else
            {
                model = new SmallCartViewModel
                {
                    NumberOfItems = cart.ListItems.Sum(x => x.Qty),
                    
                   
                   
                };
            }
            return View(model);
            


        }
    }
}
