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
            //SeedMenuList();
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

                        break;
                    case "2":
                        //Add Menu Items
                        break;
                    case "3":
                        //Delete Menu Items
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
            GetMenuList();

        }

        public void AddMenuItems()
        {

        }

        public void DeleteMenuItems()
        {

        }
    }
}

