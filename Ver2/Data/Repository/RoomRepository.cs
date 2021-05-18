using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Ver2.Data.Interfaces;
using Ver2.Data.Models;

namespace Ver2.Data.Repository
{
    public class RoomRepository:IAllRooms
    {
        //змінна для роботи з класом налаштувань БД AppDBContext.cs
        private readonly AppDBContent appDBContent;
        public RoomRepository(AppDBContent appDBContent)
        {
            this.appDBContent = appDBContent;
        }
        public IEnumerable<Room> Rooms => appDBContent.Room.Include(c => c.Category);
        public IEnumerable<Room> getFavRooms => appDBContent.Room.Where(p => p.isFavourite).Include(c => c.Category);
        public Room getObjectRoom(int carId) => appDBContent.Room.FirstOrDefault(p => p.id == carId);                
    }
}
