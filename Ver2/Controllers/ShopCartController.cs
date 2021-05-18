using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Ver2.Data.Interfaces;
using Ver2.Data.Models;
using Ver2.ViewModels;

namespace Ver2.Controllers
{
    public class ShopCartController : Controller
    {
        private readonly IAllRooms _roomRep;
        private readonly ShopCart _shopCart;
        public ShopCartController(IAllRooms roomRep, ShopCart shopCart)
        {
            _roomRep = roomRep;
            _shopCart = shopCart;
        }
        public ViewResult Index()
        {
            var items = _shopCart.getShopItems();
            _shopCart.listShopItems = items;
            var obj = new ShopCartViewModel
            {
                shopCart = _shopCart
            };
            return View(obj);
        }
        public RedirectToActionResult AddToCart(int id)
        {
            var item = _roomRep.Rooms.FirstOrDefault(i => i.id == id);
            if (item != null)
            {
                _shopCart.AddToCart(item);
            }
            return RedirectToAction("Index");
        }
    }
}