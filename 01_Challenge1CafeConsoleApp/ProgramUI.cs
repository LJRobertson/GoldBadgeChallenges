using _01_Challenge1Cafe;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01_Challenge1CafeConsoleApp
{
    class ProgramUI
    {
        private MenuItemRepo _menuItemRepo = new MenuItemRepo();


        public void Run()
        {
            SeedMenuList();
            Menu();
        }

        private void Menu()
        {
            bool keepRunning = true;
            while (keepRunning)
            {
                Console.WriteLine("Welcome to the Komodo Cafe Management Application. \nPlease choose from the following options:\n" +
                    "\n1. View All Menu Items\n" +
                    "2. Add New Menu Item\n" +
                    "3. Delete Menu Item\n" +
                    "4. Exit");

                string input = Console.ReadLine();

                switch (input)
                {
                    case "1":
                        //View Menu Items
                        ViewMenuItems();
                        break;
                    case "2":
                        //Add Menu Items
                        AddMenuItems();
                        break;
                    case "3":
                        //Delete Menu Items
                        DeleteMenuItems();
                        break;
                    case "4":
                        Console.WriteLine("Thank you for using Komodo Cafe Management Application. Goodbye!");
                        keepRunning = false;
                        break;
                    default:
                        Console.WriteLine("Your selection was invalid. Please enter a valid number.");
                        break;
                }
                Console.WriteLine("Please press any key to continue...");
                Console.ReadKey();
                Console.Clear();
            }
        }

        public void ViewMenuItems()
        {
            Console.Clear();
            List<MenuItem> listOfMenuItems = _menuItemRepo.GetMenuList();

            foreach (MenuItem item in listOfMenuItems)
            {
                Console.WriteLine($"Meal Number: {item.MealNumber} -- {item.MealName}\n" +
                    $"Description: {item.Description}\n" +
                    $"Ingredients: {item.Ingredients}\n" +
                    $"Price: ${item.Price}\n");
            }
        }

        public void AddMenuItems()
        {
            Console.Clear();
            MenuItem newItem = new MenuItem();

            bool endErrorCheck = false;
            while (endErrorCheck == false)
            {
                int menuNumber = 0;

                Console.WriteLine("Enter the new meal number:");

                if (int.TryParse(Console.ReadLine(), out int result) == true)
                {
                    menuNumber = result;
                }

                if(menuNumber <= 0){
                    Console.WriteLine("The meal number must be numeric and greater than zero.");
                }
                else
                {
                    MenuItem tempNumber = _menuItemRepo.GetMenuItemByNumber(menuNumber);
                    if (tempNumber != null)
                    {
                        Console.WriteLine("This meal number already exists.");
                    }
                    else
                    {
                        endErrorCheck = true;
                        newItem.MealNumber = menuNumber;
                    }
                }
            }

            Console.WriteLine("Enter the new meal name:");
            newItem.MealName = Console.ReadLine();

            Console.WriteLine("Enter new meal description:");
            newItem.Description = Console.ReadLine();

            Console.WriteLine("Enter new meal ingredients:");
            newItem.Ingredients = Console.ReadLine();

            Console.WriteLine("Enter new meal price (omit the $ symbol):");
            newItem.Price = double.Parse(Console.ReadLine());

            _menuItemRepo.AddMenuItemToList(newItem);
        }
    
        public void DeleteMenuItems()
        {
            ViewMenuItems();

            Console.WriteLine("Enter the ID Number of the menu item to be deleted:");

            int input = int.Parse(Console.ReadLine());

            bool wasDeleted = _menuItemRepo.RemoveMenuItemFromList(input);
            if (wasDeleted)
            {
                Console.WriteLine("The item was successfully deleted.");
            }
            else
            {
                Console.WriteLine("The item could not be deleted.");
            }
        }

        public void SeedMenuList()
        {
            MenuItem burger = new MenuItem(1, "Cheeseburger", "Classic cheeseburger and fries", "bun, beef, cheese, lettuce, tomato, fries", 5.95);
            MenuItem tenders = new MenuItem(2, "Chicken Tenders", "Tenders and fries", "chicken, fries", 4.95);
            MenuItem caesar = new MenuItem(3, "Caesar Salad", "Caesar salad and toast - it's almost healthy", "romaine lettuce, caesar dressing, parmesean cheese, toasted baguette", 6.50);
            MenuItem nachos = new MenuItem(4, "Nachos", "Cheese 'n' Chips", "tortilla chips, nacho cheese, jalapenos", 4.50);

            _menuItemRepo.AddMenuItemToList(burger);
            _menuItemRepo.AddMenuItemToList(tenders);
            _menuItemRepo.AddMenuItemToList(caesar);
            _menuItemRepo.AddMenuItemToList(nachos);
        }
    }
}

