using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Ver2.Data.Models;

namespace Ver2.ViewModels
{
    public class RoomListViewModel
    {
        //поле, що збергіає всі товари
        public IEnumerable<Room> allRooms { get; set; }
        //зберігає поточну категорію
        public string currCategory { get; set; }
    }
}
