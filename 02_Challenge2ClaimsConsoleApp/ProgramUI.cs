using _02_Challenge2ClaimsRepo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02_Challenge2ClaimsConsoleApp
{

    class ProgramUI
    {
        private ClaimRepo _claimRepo = new ClaimRepo();
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
                Console.WriteLine("Welcome to the Komodo Claims Department Application. \nPlease choose from the following options:\n" +
                    "\n1. View All Claims\n" +
                    "2. Process Next Claim\n" +
                    "3. Enter a New Claim\n" +
                    "4. Exit");

                string input = Console.ReadLine();

                switch (input)
                {
                    case "1":
                        //View All Claims
                        break;
                    case "2":
                        //Process Next Claim
                        break;
                    case "3":
                        //Enter a New Claim
                        CreateNewClaim();
                        break;
                    case "4":
                        Console.WriteLine("Thank you for using Komodo Claims Department Application. Goodbye!");
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
        public void CreateNewClaim()
        {
            Console.Clear();
            Claim newClaim = new Claim();

            bool endErrorCheck = false;
            while (endErrorCheck == false)
            {
                int claimNumber = 0;

                Console.WriteLine("Enter the new claim ID:");

                if (int.TryParse(Console.ReadLine(), out int result) == true)
                {
                    claimNumber = result;
                }

                if (claimNumber <= 0)
                {
                    Console.WriteLine("The claim ID must be numeric and greater than zero.");
                }
                else
                {
                    Claim tempNumber = _claimRepo.GetClaimByID(claimNumber);
                    if (tempNumber != null)
                    {
                        Console.WriteLine("This claim ID already exists. Please select a new ID.");
                    }
                    else
                    {
                        endErrorCheck = true;
                        newClaim.ClaimID = claimNumber;
                    }
                }
            }
            Console.WriteLine("Enter the Claim Type:");
            newClaim.ClaimType = TypeOfClaim.(Console.ReadLine());//cast?

            Console.WriteLine("Enter the claim description:");
            newClaim.Description = Console.ReadLine();

            Console.WriteLine("Enter the dollar amount of the claim:");
            newClaim.ClaimAmount = int.Parse(Console.ReadLine());

            Console.WriteLine("What date did the incident occur? Format: YYYY, MM, DD");
            newClaim.DateOfIncident = DateTime.Parse(Console.ReadLine());

            Console.WriteLine("Today's date will automatically be used for the Date of Claim.");
            newClaim.DateOfClaim = DateTime.Now;

            _claimRepo.CreateANewClaim(newClaim);
        }

        //Seed List
        public void SeedClaimList()
        {
            Claim one = new Claim(1, TypeOfClaim.Car, "crash on 465", 3000.00, "03/07/2016", "2016, 4, 8", true);
            Claim two = new Claim(2, TypeOfClaim.Home, "Water damage", 1000.00, "07/08/2017", "2017, 11, 12", false);
            Claim three = new Claim(3, TypeOfClaim.Theft, "Video gaming system stolen", 400.00, "012/011/2019", "2020, 25, 02", false);

            _claimRepo.CreateANewClaim(one);
            _claimRepo.CreateANewClaim(two);
            _claimRepo.CreateANewClaim(three);
        }
    }
}
