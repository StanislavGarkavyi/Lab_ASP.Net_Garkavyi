using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Ver2.Data.Interfaces;
using Ver2.Data.Models;

namespace Ver2.Data.Repository
{
    public class OrdersRepository : IAllOrders
    {
        private readonly AppDBContent appDBContent;
        private readonly ShopCart shopCart;
        public OrdersRepository(AppDBContent appDBContent, ShopCart
       shopCart)
        {
            this.appDBContent = appDBContent;
            this.shopCart = shopCart;
        }
        public void createOrder(Order order)
        {
            order.orderTime = DateTime.Now;
            appDBContent.Order.Add(order);
            appDBContent.SaveChanges();
            var items = shopCart.listShopItems;
            foreach (var el in items)
            {
                var orderDetail = new OrderDetail()
                {
                    carID = el.Room.id,
                    orderID = order.id,
                    price = el.Room.price
                };
                appDBContent.OrderDetail.Add(orderDetail);
            }            
        appDBContent.SaveChanges();
        }
    }
}
