using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Ver2.Data.Interfaces;
using Ver2.Data.Models;

namespace Ver2.Controllers
{
    public class OrderController : Controller
    {
        private readonly IAllOrders allOrders;
        private readonly ShopCart shopCart;
        public OrderController(IAllOrders allOrders, ShopCart shopCart)
        {
            this.allOrders = allOrders;
            this.shopCart = shopCart;
        }
        //функція повертає View з діями користувача
        public IActionResult Checkout()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Checkout(Order order)
        {
            shopCart.listShopItems = shopCart.getShopItems();
            if (shopCart.listShopItems.Count == 0)
            {
                ModelState.AddModelError("", "Ви повинні додати товар!");
            }
            if (ModelState.IsValid)
            {
                allOrders.createOrder(order);
                return RedirectToAction("Complete");
            }
            return View(order);
        }
        public IActionResult Complete()
        {
            ViewBag.Message = "Замовлення відправлено на обробку!";
            return View();
        }

    }

}