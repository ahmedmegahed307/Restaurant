using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domains;
using Resturant.InfraStructure;
using Resturant.Models;

namespace Resturant.InterfaceClasses
{
    public interface ICategorySerivce
    {

        List<TbCategory> GetAllCategories();
        TbCategory GetById(int id);
        bool addcategory(TbCategory category);
        bool editcategory(TbCategory category);
        bool Delete(string name);
    }
    public class ClsCategory : ICategorySerivce
    {
        ResturantContext ctx;
        public ClsCategory(ResturantContext context)
        {
            ctx = context;

        }
        public List<TbCategory> GetAllCategories()
        {
            var item = ctx.TbCategory.ToList();
            return item;
        }
        public TbCategory GetById(int id)
        {
            var item = ctx.TbCategory.Where(a => a.TbCategoryId == id).FirstOrDefault();
            return item;
        }
        public bool addcategory(TbCategory category)
        {
            ctx.TbCategory.Add(category);
            ctx.SaveChanges();
            return true;
        }
        public bool editcategory(TbCategory category)
        {


            //var result = ctx.TbCategory.Where(a => a.CategoryName == name).FirstOrDefault();
            //result.CategoryName = name;
            //ctx.SaveChanges();
            //return true;
            ctx.Entry(category).State = Microsoft.EntityFrameworkCore.EntityState.Modified;

            ctx.SaveChanges();
            return true;
        }

        //public bool editcategory(TbCategory category)
        //{
        //    ctx.Entry(category).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
        //    ctx.SaveChanges();
        //    return true;

        //}
        public bool Delete(string name)
        {
            var result = ctx.TbCategory.Where(a => a.CategoryName == name).FirstOrDefault();
            ctx.TbCategory.Remove(result);
            ctx.SaveChanges();
            return true;
        }
    }
}
