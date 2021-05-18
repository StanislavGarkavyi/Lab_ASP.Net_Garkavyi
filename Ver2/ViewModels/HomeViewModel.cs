using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Ver2.Data.Models;

namespace Ver2.ViewModels
{
    public class HomeViewModel
    {
        public IEnumerable<Room> favRoom { get; set; }
    }
}
