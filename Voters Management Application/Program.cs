using System;

namespace Voters_Management_Application
{
    public class Program
    {
        private static string choice;

        public static void Main(string[] args)
        {
            VoterDetail voterDetail = new VoterDetail();
            VoterRepository voterRepository = new VoterRepository();

            Console.WriteLine("Lets Insert Some data First!!");
            do
            {
                Console.Write("Enter Voter Id: ");
                voterDetail.VoterId = Console.ReadLine();
                Console.Write("Enter Voter Name: ");
                voterDetail.Name = Console.ReadLine();
                Console.Write("Enter Date of Birth: ");
                voterDetail.DateOfBirth = Convert.ToDateTime(Console.ReadLine());
                Console.Write("Enter Age: ");
                voterDetail.Age = Convert.ToInt32(Console.ReadLine());
                Console.Write("Enter Gender M/F/O: ");
                voterDetail.Gender = Console.ReadLine();
                Console.Write("Enter Voting Location: ");
                voterDetail.VotingLocation = Console.ReadLine();
                Console.WriteLine(" ");
                voterRepository.AddVoter(voterDetail);
                Console.WriteLine(" ");

                Console.WriteLine("Do you want to add another voter? Y/N: ");
                choice = Console.ReadLine();
            } while (choice == "Y");

            Console.WriteLine("-------------------------------");

            Console.WriteLine("All Eligible Voters:");
            Console.WriteLine(" ");
            voterRepository.DisplayEligibleVoters();
            Console.WriteLine("-------------------------------");

            Console.Write("Enter Voter Id to update Age: ");
            string IdToUpdate = Console.ReadLine();
            Console.Write("Age value to be updated: ");
            int AgeValue = Convert.ToInt32(Console.ReadLine());
            voterRepository.UpdateVoterAge(IdToUpdate, AgeValue);
            Console.WriteLine("-------------------------------");

            Console.Write("Enter Voter Id to Search: ");
            string IdToSearch = Console.ReadLine();
            voterRepository.FindVoter(IdToSearch);
            Console.WriteLine("-------------------------------");

            Console.Write("Enter Voter Id to delete: ");
            string IdToDelete = Console.ReadLine();
            voterRepository.DeleteVoter(IdToDelete);
            Console.WriteLine("-------------------------------");

            Console.Write("Enter Voter Id to Search: ");
            string SearchDeletedId = Console.ReadLine();
            voterRepository.FindVoter(SearchDeletedId);
            Console.WriteLine("-------------------------------");

            Console.ReadLine();
        }
    }
}
