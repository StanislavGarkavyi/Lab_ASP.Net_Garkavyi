using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Ver2.Data.Models;

namespace Ver2.Data
{ 
    public class AppDBContent : DbContext
    {
        public AppDBContent(DbContextOptions<AppDBContent> options) :
        base(options)
        { }
        //функція для отримання та запису всіх авто
        public DbSet<Room> Room { get; set; }
        //функція для отримання та запису всіх категорій
        public DbSet<Category> Category { get; set; }
        public DbSet<ShopCartItem> ShopCartItem { get; set; }
        public DbSet<Order> Order { get; set; }
        public DbSet<OrderDetail> OrderDetail { get; set; }

    }
}
