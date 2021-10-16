using Domains;
using Microsoft.AspNetCore.Mvc;
using Resturant.InfraStructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Resturant.Controllers
{
    public class ReservationController : Controller
    {
        ResturantContext ctx;
        public ReservationController(ResturantContext context)
        {
            ctx = context;
        }
        public IActionResult Reserve()
        {
            return View();
        }

        [HttpPost]
        public IActionResult SaveReserve(TbReserve model)
        {
            ViewBag.name = model.Name; ViewBag.email = model.email;ViewBag.phone = model.PhoneNumber;ViewBag.numperson = model.NumOfPersons;ViewBag.date = model.TableDate;
            ctx.TbReserve.Add(model);
            ctx.SaveChanges();
            return View("SuccessReservation",model);
        }
        public IActionResult SuccessReservation()
        {
            return View();
        }
        public IActionResult Stuff()
        {
            return View(ctx.TbStuff.ToList());
        }
    }
}
