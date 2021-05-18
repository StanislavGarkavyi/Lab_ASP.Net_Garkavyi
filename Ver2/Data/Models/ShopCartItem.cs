using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ver2.Data.Models
{
    public class ShopCartItem
    {
        public int id { get; set; }//id самого товару
        public Room Room{ get; set; }

        public int price { get; set; }
        public string ShopCartId { get; set; }//id товару в кошику
    }

}
