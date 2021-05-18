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
    public class RoomsController : Controller
    {
        private readonly IAllRooms _allRooms;
        private readonly IRoomsCategory _allCatagories;
        public RoomsController(IAllRooms iAllRooms, IRoomsCategory iRoomsCateory)
        {
            _allRooms = iAllRooms;
            _allCatagories = iRoomsCateory;
        }
        //функціяя що повретає html-сторінку
        [Route("Rooms/List")]
        [Route("Rooms/List/{category}")]
        public ViewResult List(string category)
        {
            string _category = category;
            IEnumerable<Room> rooms = null;
            string currCategory = "";
            if (string.IsNullOrEmpty(category))
            {
                rooms = _allRooms.Rooms.OrderBy(i => i.id);
            }
            else
            {
                if (string.Equals("lux", category,
               System.StringComparison.OrdinalIgnoreCase))
                {
                    rooms = _allRooms.Rooms.Where(i =>
                   i.Category.categoryName.Equals("Люкс")).OrderBy(i => i.id);
                    currCategory = "Люкс";
                }
                else if (string.Equals("comfort", category,
               System.StringComparison.OrdinalIgnoreCase))
                {
                    rooms = _allRooms.Rooms.Where(i =>
                   i.Category.categoryName.Equals("Комфорт")).OrderBy(i =>
                   i.id);
                    currCategory = "Комфорт";
                }
            }
            currCategory = _category;
            var carObj = new RoomListViewModel
            {
                allRooms = rooms,
                currCategory = currCategory
            };
            ViewBag.Title = "Сторінка з кімнатами";
            return View(carObj);//передача об'єкта в шаблон
        }

        public ViewResult Info()
        {
            //створюємо об'єкт для передачі в шаблон
            RoomInfoViewModel obj = new RoomInfoViewModel();
            obj.Room = _allRooms.getObjectRoom(0);
            obj.Category = _allCatagories.AllCategories.FirstOrDefault();
            ViewBag.Title = "";
            return View(obj);//передача об'єкта в шаблон
        }
    }

}