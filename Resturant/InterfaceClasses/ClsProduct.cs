using Domains;
using Microsoft.EntityFrameworkCore;
using Resturant.InfraStructure;
using Resturant.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Resturant.InterfaceClasses
{
    public interface IProductService
    {
        //start product
        List<TbProduct> GetAllProducts();
        TbProduct GetProductById(int id);
        bool addproduct(TbProduct product);
        bool editproduct(TbProduct product);
        bool deleteproduct(int id);
        //end product

        //start photo
        bool addphoto(TbProductImage image);
        List<TbProductImage> GetAllPhotos();
        TbProductImage GetPhotoById(int id);
        bool Deletephoto(int id);
        //end photo

        //start slider
        bool addslider(TbSlider slider);
        bool DeleteSlider(int id);
        bool editslider(TbSlider slider);
        List<TbSlider> _slider();
        TbSlider GetSliderById(int id);
        //end slider

        //start gallery
        List<TbGallery>GalleryImages();
        //end gallery

        //start reviews
        List<TbReview> GetAllReviews();
        List<TbReview> ReviewsById(int id);
        //end reviews

        //start details page//
        TbProduct ProductWithImage(int id);
        List<TbProduct> RelatedProducts(decimal price);
        //end details page
        
    }
    public class ClsProduct : IProductService
    {
        ResturantContext ctx;
        public ClsProduct(ResturantContext context)
        {
            ctx = context;
        }

        

        public List<TbProduct> GetAllProducts()
        {
            
            return ctx.TbProduct.Include(a => a.Category).ToList();
        }

        public TbProduct GetProductById(int id)
        {
            var result = ctx.TbProduct.Where(a => a.TbProductId == id).FirstOrDefault();
            return result;
        }
        public bool addproduct(TbProduct product)
        {
            ctx.TbProduct.Add(product);
            ctx.SaveChanges();
            return true;
        }

        public bool editproduct(TbProduct product)
        {
            ctx.Entry(product).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            ctx.SaveChanges();
            return true;
        }

        public bool deleteproduct(int id)
        {
            var result = ctx.TbProduct.Where(a => a.TbProductId == id).FirstOrDefault();
            ctx.Remove(result);
            ctx.SaveChanges();
            return true;
        }

        public List<TbProductImage> GetAllPhotos()
        {
            List<TbProductImage> product = ctx.TbProductImage.ToList();
            return product;
        }

       
        public TbProductImage GetPhotoById(int id)
        {
            var item = ctx.TbProductImage.Where(a => a.ProductId == id).FirstOrDefault();
            return item;
        }

        public bool Deletephoto(int id)
        {
            var result = ctx.TbProductImage.Where(a => a.ProductId == id).FirstOrDefault();
            ctx.TbProductImage.Remove(result);
            ctx.SaveChanges();
            return true;
        }
        public bool addphoto(TbProductImage image)
        {
            ctx.TbProductImage.Add(image);
            ctx.SaveChanges();
            return true;
        }

        public bool addslider(TbSlider slider)
        {
            ctx.TbSlider.Add(slider);
            ctx.SaveChanges();
            return true;
        }
        public bool DeleteSlider(int id)
        {
            var result = ctx.TbSlider.Where(a => a.TbSliderId == id).FirstOrDefault();
            ctx.TbSlider.Remove(result);
            ctx.SaveChanges();
            return true;
        }

        public bool editslider(TbSlider slider)
        {
            ctx.Entry(slider).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            ctx.SaveChanges();
            return true;
        }

        
        public List<TbSlider> _slider()
        {
            var item = ctx.TbSlider.ToList();
            return item;
        }
        public TbSlider GetSliderById(int id)
        {
            var item = ctx.TbSlider.Where(a => a.TbSliderId == id).FirstOrDefault();
            return item;
        }

        public List<TbGallery> GalleryImages()
        {
            var result = ctx.TbGallery.ToList();
            return result;
        }

        public List<TbReview> GetAllReviews()
        {
            var result = ctx.Reviews.ToList();
            return result;
        }
        public List<TbReview> ReviewsById(int id)
        {
            var result = ctx.Reviews.Include(a=>a.Product).Where(a =>a.ProductId== id).ToList();
            return result;
        }

        public TbProduct ProductWithImage(int id)
        {
            var result = ctx.TbProduct.Include(a => a.FProductImage).Where(a => a.TbProductId == id).FirstOrDefault();
            return result;
        }

        public List<TbProduct> RelatedProducts(decimal price)
        {
            decimal start = price -30 ;
            decimal end = price + 30;
            var result = ctx.TbProduct.Where(a => a.ProductPrice <= end && a.ProductPrice >= start).Take(5).ToList();
            return result;  
        }   


    }
}
