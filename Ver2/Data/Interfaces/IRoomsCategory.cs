using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Ver2.Data.Models;

namespace Ver2.Data.Interfaces
{
    public interface IRoomsCategory
    {
        IEnumerable<Category> AllCategories { get; }
    }
}
