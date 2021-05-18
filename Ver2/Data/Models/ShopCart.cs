using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ver2.Data.Models
{
    public class ShopCart
    {
        //змінна для роботи з класом налаштувань БД AppDBContext.cs
        private readonly AppDBContent appDBContent;
        public ShopCart(AppDBContent appDBContent)
        {
            this.appDBContent = appDBContent;
        }
        public string ShopCartId { get; set; }
        public List<ShopCartItem> listShopItems { get; set; }
        public static ShopCart GetCart(IServiceProvider services)
        {
            //створюємо об'єкт для роботи з сессією
            ISession session =
           services.GetRequiredService<IHttpContextAccessor>()?.HttpContext.Session;
            var context = services.GetService<AppDBContent>();
            //перевіряємо чи був створений кошик чи створюємо новий
            string shopCartId = session.GetString("CartId") ??
           Guid.NewGuid().ToString(); //id кошика
                                      //присваюємо id кошика сессії
            session.SetString("CartId", shopCartId);
            return new ShopCart(context) { ShopCartId = shopCartId };
        }
        //функція додавання товару до кошика
        public void AddToCart(Room room)
        {
            appDBContent.ShopCartItem.Add(new ShopCartItem
            {
                ShopCartId = ShopCartId,
                Room = room,
                price = room.price
            });
            appDBContent.SaveChanges();
        }
        //функція відображення товарів в кошику
        public List<ShopCartItem> getShopItems()
        {
            return appDBContent.ShopCartItem.Where(c => c.ShopCartId == ShopCartId).Include(s => s.Room).ToList();
        }
    }
}
