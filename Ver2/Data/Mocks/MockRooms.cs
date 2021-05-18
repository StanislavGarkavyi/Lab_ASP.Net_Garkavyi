using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Ver2.Data.Interfaces;
using Ver2.Data.Models;

namespace Ver2.Data.Mocks
{
    public class MockRooms : IAllRooms
    {
        private readonly IRoomsCategory _categoryRooms = new
       MockCategory();
        public IEnumerable<Room> Rooms
        {
            get
            {
                return new List<Room> {
                     new Room {
                         name = "Номер 1",
                         shortDesc = "Гарний",
                         longDesc=" Гарний номер",
                         img="/img/1.jpg",
                         price=45000,
                         isFavourite=true,
                         available=true,
                         Category = _categoryRooms.AllCategories.First()
                     },
                     new Room {
                         name = "Номер 2",
                         shortDesc = "Приємний",
                         longDesc = "Приємний номер",
                         img = "/img/2.jpg",
                         price = 40000,
                        isFavourite = false,
                        available = true,
                        Category = _categoryRooms.AllCategories.Last()
                     }
                };
            }
        }
        public IEnumerable<Room> getFavRooms { get; set; }
        public Room getObjectRoom(int roomId)
        {
            return Rooms.FirstOrDefault();
        }
    }
}
