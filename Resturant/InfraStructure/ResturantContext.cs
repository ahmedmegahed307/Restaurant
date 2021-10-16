using Domains;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Resturant.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Resturant.InfraStructure
{
    public class ResturantContext : IdentityDbContext
    {
        public ResturantContext(DbContextOptions<ResturantContext> options)
           : base(options)
        {
        }
        public virtual DbSet<TbProduct> TbProduct { get; set; }
        public virtual DbSet<TbCategory> TbCategory { get; set; }
        public virtual DbSet<TbSlider> TbSlider { get; set; }
        public virtual DbSet<TbProductImage> TbProductImage { get; set; }
        public virtual DbSet<TbGallery> TbGallery { get; set; }
        public virtual DbSet<TbReview> Reviews { get; set; }
        public virtual DbSet<TbContact> TbContact { get; set; }
        public virtual DbSet<ShopingCart> checkoutdata { get; set; }
        public virtual DbSet<TbReserve> TbReserve { get; set; }
        public virtual DbSet<TbStuff> TbStuff { get; set; }





    }
}
