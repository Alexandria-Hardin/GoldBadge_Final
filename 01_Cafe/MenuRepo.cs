using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01_Cafe
{
    public class MenuRepository
    {
        protected readonly List<Menu> _menus = new List<Menu>();
        //Add items to menu
        public bool AddItemsToMenus(Menu newItems)
        {
            int startingCount = _menus.Count;
            _menus.Add(newItems);
            bool wasAdded = (_menus.Count > startingCount) ? true : false;
            return wasAdded;
        }
        //Recieve items from menu
        public List<Menu> GetItems()
        {
            return _menus;
        }
        public Menu GetItemsByName(string mealName)
        {
            foreach(Menu content in _menus)
            {
                if (content.MealName.ToLower() == mealName.ToLower())
                {
                    return content;
                }
            }
            return null;
        }
        //Delete menu items
       public bool DeleteExistingItems(Menu existingItems)
        {
            bool deleteResult = _menus.Remove(existingItems);
            return deleteResult;
        }
    }
}
