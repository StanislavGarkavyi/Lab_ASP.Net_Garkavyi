using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ver2.Data.Models
{
    public class Room
    {
        public int id { set; get; }
        public string name { set; get; }
        public string shortDesc { set; get; }
        public string longDesc { set; get; }
        public string img { set; get; }
        public ushort price { set; get; }
        public bool isFavourite { set; get; }
        public bool available { set; get; }
        public int categoryID { set; get; }//категорія товару
        public virtual Category Category { set; get; }//об'єкт, що містить
                                                      // всю інформацію про категорію

    }
}
