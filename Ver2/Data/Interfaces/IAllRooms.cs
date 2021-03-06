using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Ver2.Data.Models;

namespace Ver2.Data.Interfaces
{
    public interface IAllRooms
    {
        //функція повертає всі товари
        IEnumerable<Room> Rooms { get; }
        //функція повертає всі товари у яких isFavorite = true
        IEnumerable<Room> getFavRooms { get;}
        //повертає товар за його id
        Room getObjectRoom(int roomId);
    }
}
