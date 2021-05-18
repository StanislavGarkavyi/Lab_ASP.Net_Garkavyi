using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Ver2.Data.Interfaces;
using Ver2.Data.Models;

namespace Ver2.Data.Repository
{
    public class CategoryRepository : IRoomsCategory
    {
        private readonly AppDBContent appDBContent;

        public CategoryRepository(AppDBContent appDBContent)
        {
            this.appDBContent = appDBContent;
        }
        public IEnumerable<Category> AllCategories =>
       appDBContent.Category;
    }
}
