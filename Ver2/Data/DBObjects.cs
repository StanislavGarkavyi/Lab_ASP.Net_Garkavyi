using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Ver2.Data.Models;

namespace Ver2.Data
{
    public class DBObjects
    {
        //функція для підключення до БД
        public static void Initial(AppDBContent content)
        {
            //якщо не має жодної категорії, то додаємо категорії
            if (!content.Category.Any())
            {
                content.Category.AddRange(Categories.Select(c =>
               c.Value));
            }
            //якщо не має жодного товару, то додаємо товар
            if (!content.Room.Any())
            {
                content.AddRange(
                new Room
                {
                    name = "Кімната 1",
                    shortDesc = "Приємна",                    
               
                longDesc = "Приємний та зручний номер",
                    img = "/img/1.jpg",
                    price = 45000,
                    isFavourite = true,
                    available = true,
                    Category = Categories["Комфорт"]
                },
               new Room
               {
                   name = "Кімната 2",
                   shortDesc = "Гарна",
                   longDesc = "Гарна кімната класу люкс",
               
                img = "/img/2.jpg",
                   price = 40000,
                   isFavourite = false,
                   available = true,
                   Category = Categories["Люкс"]
               },
               new Room
               {
                   name = "Кімната 3",
                   shortDesc = "Гарна",
                   longDesc = "Гарна кімната класу люкс",

                   img = "/img/1.jpg",
                   price = 40000,
                   isFavourite = false,
                   available = true,
                   Category = Categories["Люкс"]
               },
               new Room
               {
                   name = "Кімната 4",
                   shortDesc = "Гарна",
                   longDesc = "Гарна кімната класу люкс",

                   img = "/img/2.jpg",
                   price = 40000,
                   isFavourite = false,
                   available = true,
                   Category = Categories["Люкс"]
               }, new Room
               {
                   name = "Кімната 5",
                   shortDesc = "Гарна",
                   longDesc = "Гарна кімната класу люкс",

                   img = "/img/1.jpg",
                   price = 40000,
                   isFavourite = false,
                   available = true,
                   Category = Categories["Люкс"]
               },
               new Room
               {
                   name = "Кімната 6",
                   shortDesc = "Гарна",
                   longDesc = "Гарна кімната класу люкс",

                   img = "/img/1.jpg",
                   price = 40000,
                   isFavourite = false,
                   available = true,
                   Category = Categories["Люкс"]
               }, new Room
               {
                   name = "Кімната 7",
                   shortDesc = "Гарна",
                   longDesc = "Гарна кімната класу люкс",

                   img = "/img/2.jpg",
                   price = 40000,
                   isFavourite = false,
                   available = true,
                   Category = Categories["Люкс"]
               },
               new Room
               {
                   name = "Кімната 8",
                   shortDesc = "Гарна",
                   longDesc = "Гарна кімната класу люкс",

                   img = "/img/1.jpg",
                   price = 40000,
                   isFavourite = false,
                   available = true,
                   Category = Categories["Люкс"]
               },
               new Room
               {
                   name = "Кімната 9",
                   shortDesc = "Гарна",
                   longDesc = "Гарна кімната класу люкс",

                   img = "/img/2.jpg",
                   price = 40000,
                   isFavourite = false,
                   available = true,
                   Category = Categories["Люкс"]
               }, new Room
               {
                   name = "Кімната 10",
                   shortDesc = "Гарна",
                   longDesc = "Гарна кімната класу люкс",

                   img = "/img/1.jpg",
                   price = 40000,
                   isFavourite = false,
                   available = true,
                   Category = Categories["Люкс"]
               },
               new Room
               {
                   name = "Кімната 11",
                   shortDesc = "Гарна",
                   longDesc = "Гарна кімната класу люкс",

                   img = "/img/1.jpg",
                   price = 40000,
                   isFavourite = false,
                   available = true,
                   Category = Categories["Люкс"]
               }


                );
            }
            content.SaveChanges();
        }
        private static Dictionary<string, Category> category;
        public static Dictionary<string, Category> Categories
        {
            get
            {
                if (category == null)
                {
                    //створення інфомаціїї для занесення в БД
                    var list = new Category[]{
                                 new Category {categoryName = "Комфорт",
                                desc = "Номери комфорт класу"},
                                 new Category {categoryName = "Люкс", desc = "Номери люкс класу"},
 };
                    category = new Dictionary<string, Category>();
                    foreach (Category el in list)
                    {
                        category.Add(el.categoryName, el);
                    }
                }
                return category;
            }
        }
    }

}
