using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ver2.Data.Models
{
    public class Category
    {
        public int id { set; get; }
        public string categoryName { set; get; }
        public string desc { set; get; }
        public List<Room> rooms { set; get; }//список товарів в категорії
    }
}
