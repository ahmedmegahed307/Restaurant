using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domains
{
  public  class ShopingCart : Checkoutdata
    {
        //it is as cart ViewModel
        public ShopingCart()
        {
            ListItems = new List<ShopingCartItem>();
        }
        public List<ShopingCartItem> ListItems { get; set; }
        public decimal Total { get; set; }//all products total

    }
}
