using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _01_Cafe;

namespace _01_CafeUI
{
    public class ProgramUI
    {
        protected readonly MenuRepository _menuRepo = new MenuRepository();
        public void Run()
        {
            DisplayMenu();
        }
        private void DisplayMenu()
        {
            bool isRunning = true;
            while (isRunning)
            {
                Console.Clear();
                Console.WriteLine(
                    "Enter the number of the option you would like to select (1-4):\n" +
                    "1. Show All Menu Items\n" +
                    "2. Create New Menu Item\n" +
                    "3. Delete Menu Items\n" +
                    "4. Find Menu Items By Meal Name\n" +
                    "5. Exit\n");

                string userInput = Console.ReadLine();

                switch (userInput)
                {
                    case "1":
                        ShowAllMenuItems();
                        break;
                    case "2":
                        AddNewItems();
                        break;
                    case "3":
                        DeleteItems();
                        break;
                    case "4":
                        GetItemsByName();
                        break;
                    case "5":
                        //Exit
                        isRunning = false;
                        break;
                    default:
                        Console.WriteLine("Please enter a valid number between 1 and 5");
                        Console.WriteLine("Press any key to continue...");
                        Console.ReadKey();
                        break;
                }
            }
        }

        private void AddNewItems()
        {
            Console.Clear();
            Console.WriteLine("Please enter a meal number: ");
            int mealNumber = int.Parse(Console.ReadLine());
            Console.WriteLine("Please enter a meal name: ");
            string mealName = Console.ReadLine();
            Console.WriteLine("Please enter a description: ");
            string desc = Console.ReadLine();
            Console.WriteLine("Please enter a price: ");
            decimal price = decimal.Parse(Console.ReadLine());
            Menu content = new Menu(mealNumber, mealName, desc, price);
            //Do not forgot to actually add!!!!!
            _menuRepo.AddItemsToMenus(content);
        }
        private void ShowAllMenuItems()
        {
            Console.Clear();
            List<Menu> menus = _menuRepo.GetItems();
            foreach (Menu content in menus)
            {
                Console.WriteLine($"MealNumber: {content.MealNumber}\n" +
                             $"MealName: {content.MealName}\n" +
                             $"Description: {content.Description}\n" +
                             $"Price: {content.Price}\n");
            }
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
        }
        private void GetItemsByName()
        {
            Console.Clear();
            Console.WriteLine("What menu item are you looking for?");
            string mealName = Console.ReadLine();
            Menu content = _menuRepo.GetItemsByName(mealName);
            if (content != null)
            {
                Console.WriteLine($"MealNumber: {content.MealNumber}\n" +
                             $"MealName: {content.MealName}\n" +
                             $"Description: {content.Description}\n" +
                             $"Price: {content.Price}\n");
            }
            else
            {
                Console.WriteLine("Failed to find item");
            }
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
        }
        private void DeleteItems()
        {
            Console.Clear();
            Console.WriteLine("What meal items would you like to remove?");
            int count = 0;
            List<Menu> contentList = _menuRepo.GetItems();
            foreach (Menu content in contentList)
            {
                count++;
                Console.WriteLine($"{count}. {content.MealName}");
            }
            int userInput = int.Parse(Console.ReadLine());
            int targetIndex = userInput - 1;
            if (targetIndex >= 0 && targetIndex < contentList.Count())
            {
                Menu targetContent = contentList[targetIndex];
                if (_menuRepo.DeleteExistingItems(targetContent))
                {
                    Console.WriteLine($"{targetContent.MealName} removed from repo");
                }
                else
                {
                    Console.WriteLine("Sorry something went wrong");
                }
            }
            else
            {
                Console.WriteLine("Invalid Selection");
            }
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
        }
    }
}
