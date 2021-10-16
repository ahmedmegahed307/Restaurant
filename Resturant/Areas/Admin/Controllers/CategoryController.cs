using Domains;
using Microsoft.AspNetCore.Mvc;
using Resturant.InterfaceClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Resturant.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CategoryController : Controller
    {
        ICategorySerivce ICategory;
        public CategoryController(ICategorySerivce qq)
        {
            ICategory = qq;
        }

        public IActionResult CategoryList()
        {
            return View(ICategory.GetAllCategories());
        }

        public IActionResult CategoryEdit(int? id)
        {
            if (id != null)
            {
                return View(ICategory.GetById(Convert.ToInt32(id)));

            }
            else

                return View();
        }

        [HttpPost]
        public IActionResult Save(TbCategory category)
        {

            if (category.TbCategoryId == 0)
            {
                ICategory.addcategory(category);

            }
            else
            {
                ICategory.editcategory(category);
            }
            return RedirectToAction("CategoryList");
        }

        public IActionResult Delete(string name)
        {
            ICategory.Delete(name);
            return RedirectToAction("CategoryList");

        }
    }
}
