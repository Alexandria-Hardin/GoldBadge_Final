using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01_Cafe
{
    public class Menu
    {
        public int MealNumber { get; set; }
        public string MealName { get; set; }
        public string Description { get; set; }
        public List<string> ListOfIngredients { get; set; }
        public decimal Price { get; set; }
        public Menu() { }
        public Menu(int mealNumber, string mealName, string desc, decimal price)
        {
            MealNumber = mealNumber;
            MealName = mealName;
            Description = desc;
            Price = price;
        }
    }
}
