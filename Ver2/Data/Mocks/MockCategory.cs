using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Ver2.Data.Interfaces;
using Ver2.Data.Models;

namespace Ver2.Data.Mocks
{
    public class MockCategory : IRoomsCategory
    {
        public IEnumerable<Category> AllCategories
        {
            get
            {
                return new List<Category> {
                     new Category {categoryName = "Стандарт", desc =
                    "Звичайний номер"},
                     new Category {categoryName = "Люкс",
                    desc = "Номер класу люкс"},
                     };
            }
        }
    }
}
