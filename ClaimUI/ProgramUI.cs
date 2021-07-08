using System;
using System.Collections.Generic;
using System.Data.Linq;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Claim;
using ConsoleTables;

namespace ClaimUI
{
    public class ProgramUI
    {
        protected readonly ClaimRepository _claimRepo = new ClaimRepository();
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
                    "1. See all claims \n" +
                    "2. Take care of next claim \n" +
                    "3. Enter a new claim \n" +
                    "4. Exit\n");

                string userInput = Console.ReadLine();
                switch (userInput)
                {
                    case "1":
                        SeeAllClaims();
                        break;
                    case "2":
                        TakeCareOfNextClaim();
                        break;
                    case "3":
                        EnterNewClaim();
                        break;
                    case "4":
                        isRunning = false;
                        break;
                    default:
                        Console.WriteLine("Please enter a valid number between 1 and 4");
                        Console.WriteLine("Press any key to continue...");
                        Console.ReadKey();
                        break;
                }
            }
        }

        private void EnterNewClaim()
        {
            Console.Clear();
            Console.WriteLine("Please enter the claim id: ");
            int claimid = int.Parse(Console.ReadLine());
            Console.WriteLine("Select the claim type : \n" +
                "1. Car\n" +
                "2. Home\n" +
                "3. Theft");
            string stringClaimType = Console.ReadLine();
            Console.WriteLine("Please enter a claim description: ");
            string desc = Console.ReadLine();
            Console.WriteLine("Please enter the amount of the damage: ");
            decimal claimAmount = int.Parse(Console.ReadLine());
            Console.WriteLine("Please enter the date of the accident: ");
            DateTime dateOfIncident = DateTime.Parse(Console.ReadLine());
            Console.WriteLine("Please enter the date of the claim: ");
            DateTime dateOfClaim = Convert.ToDateTime(Console.ReadLine());
            Console.WriteLine("Is the claim valid? ");
            bool isValid = bool.Parse(Console.ReadLine());
            ClaimType claimType;
            claimType = (ClaimType)int.Parse(stringClaimType);
            Claims content = new Claims(claimid, claimType, desc, claimAmount, dateOfIncident, dateOfClaim);
            _claimRepo.AddClaimToDirectory(content);
        }
        private void SeeAllClaims()
        {
            Console.Clear();
            Queue<Claims> listOfContent = _claimRepo.GetClaims();
            foreach (Claims content in listOfContent)
            {
                DisplayClaims(content);
            }
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
        }

        private void TakeCareOfNextClaim()
        {
            Console.Clear();
            Console.WriteLine("These are the details for the next claim: ");
            var nextClaim = _claimRepo.NextItemInQueue();
            DisplayClaims(nextClaim);
            Console.WriteLine("Would you like to take care of this claim now? (y/n) ");
            char userInput = char.Parse(Console.ReadLine());
            if (userInput == 'y')
            {
                _claimRepo.RemoveFromQueue();
            }
            else
            {
                DisplayMenu();
            }
        }
        private void DisplayClaims(Claims content)
        {
            var table = new ConsoleTable("ClaimID", "Type", "Description", "Amount", "DateOfAccident", "DateOfClaim", "IsValid");
            table.AddRow(content.ClaimID, content.TypeOfClaim, content.Description, content.ClaimAmount, content.DateOfIncident, content.DateOfClaim, content.IsValid);
            table.Write();
        }
        private void SeedContentList()
        {
            var Claims1 = new Claims(1, ClaimType.car, "Car accident on 465.", 400.00m, new DateTime(2018, 4, 27), new DateTime(2018, 4, 28));
            var Claims2 = new Claims(2, ClaimType.home, "House fire in the kitchen", 4000.00m, new DateTime(2018, 4, 27), new DateTime(2018, 4, 28));
            var Claims3 = new Claims(3, ClaimType.theft, "Stolen pancakes", 4.00m, new DateTime(2018, 4, 27), new DateTime(2018, 6, 1));

            _claimRepo.AddClaimToDirectory(Claims1);
            _claimRepo.AddClaimToDirectory(Claims2);
            _claimRepo.AddClaimToDirectory(Claims3);
        }
    }
}
