using _03_Challenge3BadgesRepo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03_Challenge3BadgesConsoleApp
{
    class ProgramUI
    {
        private BadgeRepo _badgeRepo = new BadgeRepo();
        public void Run()
        {
            SeedBadgeDictionary();
            Menu();
        }
        private void Menu()
        {
            bool keepRunning = true;
            while (keepRunning)
            {
                Console.WriteLine("Welcome to the Komodo Insurance Badge Door Access Application. \nWhat would you like to do?\n" +
                    "\n1. View All Badges and Door Access\n" +
                    "2. Create a New Badge\n" +
                    "3. Update Door Access on a Badge\n" +
                    "4. Remove All Door Access From a Badge\n" +
                    "5. Exit");

                string input = Console.ReadLine();

                switch (input)
                {
                    case "1":
                        //View All Badges & Door Access
                        ViewAllBadgesAndDoors();
                        break;
                    case "2":
                        //Create a New Badge -- DONE
                        CreateANewBadge();
                        break;
                    case "3":
                        //Update Door Access on a Badge
                        break;
                    case "4":
                        //Remove All Door Access From Badge
                        break;
                    case "5":
                        Console.Clear();
                        Console.WriteLine("Thank you for using Komodo Insurance Badge Door Application. Goodbye!");
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

        private void ViewAllBadgesAndDoors()// -- INCOMPLETE
        {
            Console.Clear();
            Dictionary<int, Badge> badgeDictionary = _badgeRepo.GetBadges();

            string badgeID = "Badge ID";
            string doors = "Door Access";

            Console.WriteLine("{0,-5}{1,20}", badgeID, doors);

            foreach ( int badgeNumber in badgeDictionary.Keys)
            {
                Console.WriteLine("\n{0,-5} {1,20}", badgeDictionary.Keys, badgeDictionary.Values);
            }
            Console.ReadLine();
        }

        private void CreateANewBadge() //--ISN'T WORKING RIGHT
        {
            Console.Clear();
            Badge newBadge = new Badge();

            bool endErrorCheck = false;
            while (endErrorCheck == false)
            {
                int badgeNumber = 0;

                Console.WriteLine("Enter the new Badge ID number:");

                if (int.TryParse(Console.ReadLine(), out int result) == true)
                {
                    badgeNumber = result;
                }

                if (badgeNumber <= 0)
                {
                    Console.WriteLine("The badge number must be numeric and greater than zero.");
                }
                else
                {
                    Badge tempNumber = _badgeRepo.GetBadgeByIDNumber(badgeNumber);
                    if (tempNumber != null)
                    {
                        Console.WriteLine("This badge number already exists.");
                    }
                    else
                    {
                        endErrorCheck = true;
                        newBadge.BadgeID = badgeNumber;
                    }
                }
            }

            Console.WriteLine("Enter the doors for this badge to have access to. Separate each door with a comma (ie: B25, B27, C11):");
            string doorNames = Console.ReadLine();
            string[] doorArray = doorNames.Split(',');

            foreach (string door in doorArray)
            {
                newBadge.DoorNamesList.Add(door.Trim());
            }

            _badgeRepo.CreateNewBadge(newBadge.BadgeID, newBadge);
        }

        public void SeedBadgeDictionary()
        {
            Badge one = new Badge(101);
            Badge two = new Badge(102);
            Badge three = new Badge(103);

            
            _badgeRepo.CreateNewBadge(one.BadgeID, one);
            _badgeRepo.CreateNewBadge(two.BadgeID, two);
            _badgeRepo.CreateNewBadge(three.BadgeID, three);

            _badgeRepo.UpdateDoorsOnBadge(101, "A1, B2, B3");
            _badgeRepo.UpdateDoorsOnBadge(102, "A11, B2, B4, C13");
            _badgeRepo.UpdateDoorsOnBadge(103, "D12, B2");
        }
    }
}

