﻿using _02_Challenge2ClaimsRepo;
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
            SeedClaimQueue();
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
                        ViewClaimsQueue();
                        break;
                    case "2":
                        //Process Next Claim
                        ProcessNextClaim();
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

        public void ViewClaimsQueue()
        {
            Console.Clear();
            Queue<Claim> queueOfClaims = _claimRepo.GetClaimQueue();

            string claimID = "Claim";
            string type = "Type";
            string description = "Description";
            string amount = "Amount";
            string dateOfAccident = "DateOfAccident";
            string dateOfClaim = "DateOfClaim";
            string isValid = "IsValid";

            Console.WriteLine("{0,5} {1,-10} {2,-15} {3,-15} {4,-25} {5,-25} {6,-10}", claimID, type, description, amount, dateOfAccident, dateOfClaim, isValid);

            foreach (Claim claim in queueOfClaims)
            {
                Console.WriteLine("\n{0,5} {1,-10} {2,-15} {3,-15:C} {4,-25} {5,-25} {6,-10}", claim.ClaimID, claim.ClaimType, claim.Description, claim.ClaimAmount, claim.DateOfIncident.Date.ToShortDateString(), claim.DateOfClaim.Date.ToShortDateString(), claim.IsValid);
            }
            Console.ReadLine();
        }

        public void ProcessNextClaim()
        {
            Console.Clear();

            _claimRepo.GetClaimQueue();
            Queue<Claim> claimQueue = _claimRepo.GetClaimQueue();
            Claim nextClaim = claimQueue.Peek();

            Console.WriteLine("Here are the details for the next claim to be handled:\n");

            Console.WriteLine($"Claim ID: {nextClaim.ClaimID}\n" +
                $"Description: { nextClaim.Description}\n" +
                $"Amount: ${nextClaim.ClaimAmount}\n" +
                $"DateOfAccident: {nextClaim.DateOfIncident.Date.ToShortDateString()}\n" +
                $"DateOfClaim: {nextClaim.DateOfClaim.Date.ToShortDateString()}\n" +
                $"IsValid: {nextClaim.IsValid}\n\n" +
                $"Do you want to deal with this claim now (y/n)?");

            string deal = Console.ReadLine().ToLower();

            if (deal == "y")
            {
                nextClaim = claimQueue.Dequeue();
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
            Console.WriteLine("Enter the Claim Type: \n" +
                "For Car Enter 1\n" +
                "For Home Enter 2\n" +
                "For Theft Enter 3");

            string input = Console.ReadLine();
            switch (input)
            {
                case "1":
                    newClaim.ClaimType = TypeOfClaim.Car;
                    break;
                case "2":
                    newClaim.ClaimType = TypeOfClaim.Home;
                    break;
                case "3":
                    newClaim.ClaimType = TypeOfClaim.Theft;
                    break;
                default:
                    Console.WriteLine("Your selection was invalid. Please enter 1, 2, or 3.");
                    break;
            }

            Console.WriteLine("Enter the claim description:");
            newClaim.Description = Console.ReadLine();

            Console.WriteLine("Enter the dollar amount of the claim:");
            newClaim.ClaimAmount = int.Parse(Console.ReadLine());

            Console.WriteLine("What date did the incident occur? Format: MM/DD/YYYY");
            newClaim.DateOfIncident = DateTime.Parse(Console.ReadLine());

            Console.WriteLine("Today's date will automatically be used for the Date of Claim.");
            newClaim.DateOfClaim = DateTime.Now.Date;

            _claimRepo.CreateANewClaimToQueue(newClaim);
        }

        public void SeedClaimQueue()
        {
            Claim one = new Claim(1, TypeOfClaim.Car, "Crash on 465", 3000.00, DateTime.Parse("03/17/2016"), DateTime.Parse("04/08/2016"));
            Claim two = new Claim(2, TypeOfClaim.Home, "Water damage", 1000.00, DateTime.Parse("05/07/2016"), DateTime.Parse("11/11/2018"));
            Claim three = new Claim(3, TypeOfClaim.Theft, "Stolen ring", 400.00, DateTime.Parse("12/24/2017"), DateTime.Parse("01/05/2018"));

            _claimRepo.CreateANewClaimToQueue(one);
            _claimRepo.CreateANewClaimToQueue(two);
            _claimRepo.CreateANewClaimToQueue(three);
        }
    }
}
