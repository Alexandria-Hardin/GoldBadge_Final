using System;
using System.Collections.Generic;
using System.Linq;
using Badge;
using ConsoleTables;

namespace _03_BadgeUI
{
    public class ProgramUI
    {
        protected readonly BadgeRepository _badgeRepo = new BadgeRepository();
        public void Run()
        {
            SeedContentList();
            DisplayMenu();
        }
        private void DisplayMenu()
        {
            bool isRunning = true;
            while (isRunning)
            {
                Console.Clear();
                Console.WriteLine(
                    "Hello Security Admin, What woudl you like to do? (1-3)\n" +
                    "1. Add a badge\n" +
                    "2. Edit a badge\n" +
                    "3. List all badges\n" +
                    "4. Exit\n");
                string userInput = Console.ReadLine();
                switch (userInput)
                {
                    case "1":
                        AddABadge();
                        break;
                    case "2":
                        UpdateABadge();
                        break;
                    case "3":
                        ListAllBadges();
                        Console.ReadKey();
                        break;
                    case "4":
                        isRunning = false;
                        break;
                    default:
                        Console.WriteLine("Please enter a valid number betweeb 1 and 4");
                        Console.WriteLine("Press any key to continue...");
                        Console.ReadKey();
                        break;
                }
            }
        }
        private void AddABadge()
        {
            Console.Clear();
            Console.WriteLine("What is the number on the badge: ");
            int badgeid = int.Parse(Console.ReadLine());
            Console.WriteLine("List a door that it needs access to: ");
            var doorAccess = new List<string>();
            string doorName = Console.ReadLine();
            doorAccess.Add(doorName);
            Console.WriteLine("Any other doors? (y/n) ");
            char userInput = char.Parse(Console.ReadLine());
            if (userInput == 'y')
            {
                Console.WriteLine("List a door that it needs access to: ");
                doorAccess.Add(Console.ReadLine());
            }
            else
            {
                Console.WriteLine("Badge was added.");
            }
            Badges content = new Badges(badgeid, doorAccess);
            _badgeRepo.AddBadgeToDirectory(content);
        }
        private void UpdateABadge()
        {
            Console.Clear();
            ListAllBadges();
            Console.WriteLine("What is the number on the badge you would like to update? ");
            int badgeId = int.Parse(Console.ReadLine());
            var badge = _badgeRepo.GetDoorAccessByID(badgeId);
            Console.WriteLine("What would you like to do? (1-2)\n" +
            "1. Remove a door\n" +
            "2. Add a door");
            string userInput = Console.ReadLine();
            switch (userInput)
            {
                case "1":
                    RemoveDoor(badge);
                    break;
                case "2":
                    AddDoor(badge);
                    break;
                default:
                    Console.WriteLine("Please enter a valid number between 1 and 2");
                    Console.WriteLine("Press any key to continue...");
                    Console.ReadKey();
                    break;
            }

        }
        private void ListAllBadges()
        {
            var badges = _badgeRepo.GetBadges();
            foreach (var badge in badges)
            {
                Console.WriteLine("\n" + badge.Key);
                    foreach(string door in badge.Value)
                {
                    Console.WriteLine(door);
                }
            }
        }
        private void RemoveDoor(List<string> doorsToUpdate)
        {
            Console.Clear();
            Console.WriteLine("This badge has access to these doors: ");
            foreach (string door in doorsToUpdate)
            {
                Console.WriteLine(door);
            }
            Console.WriteLine("Which door would you like to remove?");
            string userInput = Console.ReadLine();
            if (doorsToUpdate.Contains(userInput))
            {
                doorsToUpdate.Remove(userInput);
            }
            else
            {
                Console.WriteLine("Invalid Selection");
            }
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
        }

        private void AddDoor(List<string> doorsToUpdate)
        {
            Console.Clear();
            Console.WriteLine("This badge has access to these doors: ");
            foreach (string door in doorsToUpdate)
            {
                Console.WriteLine(door);
            }
            Console.WriteLine("List a door that it needs access to: ");
            string userInput = Console.ReadLine();
            doorsToUpdate.Add(userInput);
            Console.WriteLine("Door added.");
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
        }
        private void SeedContentList()
        {
            List<string> list1 = new List<string>() { "A7" };
            List<string> list2 = new List<string>() { "A1", "A4", "B1", "B2" };
            List<string> list3 = new List<string>() { "A4", "A5" };

            Badges badge1 = new Badges(12345, list1);
            Badges badge2 = new Badges(22345, list2);
            Badges badge3 = new Badges(32345, list3);

            _badgeRepo.AddBadgeToDirectory(badge1);
            _badgeRepo.AddBadgeToDirectory(badge2);
            _badgeRepo.AddBadgeToDirectory(badge3);
        }
    }
}

