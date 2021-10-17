using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domains;
using Resturant.InfraStructure;
using Resturant.Models;
using Microsoft.AspNetCore.Mvc;

namespace Resturant.Controllers
{
    public class ContactController : Controller
    {

        ResturantContext ctx;
        public ContactController(ResturantContext context)
        {
            ctx = context;
        }
        public IActionResult contact()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Save(TbContact model)
        {
            ViewBag.first = model.FirstName; ViewBag.last = model.LastName;
            ViewBag.mail = model.Email; ViewBag.number = model.PhoneNumber;
            ctx.TbContact.Add(model);
            ctx.SaveChanges();
            return View("SuccessMessage");
        }
        public IActionResult SuccessMessage()
        {
            
            return View();
        }

    }
}
