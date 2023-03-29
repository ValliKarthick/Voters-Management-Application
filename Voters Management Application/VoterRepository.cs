using System;
using System.Collections.Generic;
using System.Linq;

namespace Voters_Management_Application
{
    public class VoterRepository
    {
        VoterContext voterContext = new VoterContext();
        public void AddVoter(VoterDetail voter)
        {
            using (var voterContext = new VoterContext())
            {
                voterContext.VoterDetails.Add(voter);
                voterContext.SaveChanges();
                Console.WriteLine("*Voter Data Inserted Successfully*");
            }
        }

        public void DisplayEligibleVoters()
        {
            var VotersList = voterContext.VoterDetails.ToList();
            var EligibleVotersList = from voter in VotersList
                                     where voter.Age >= 18
                                     select voter;
            foreach (var voter in EligibleVotersList)
            {
                Console.WriteLine(voter.VoterId + "-" + voter.Name);
            }
        }

        public void UpdateVoterAge(string VoterId, int Age)
        {
            var voter = GetVoter(VoterId);
            if (voter != null)
            {
                voter.Age = Age;
                voterContext.SaveChanges();
                Console.WriteLine("*Voter’s age updated Successfully*");
            }
            else
            {
                Console.WriteLine("*Voter Not Found*");
            }           
        }
        public void FindVoter(string VoterId)
        {

            var voter = GetVoter(VoterId);
            if (voter != null)
            {
                Console.WriteLine("Name: " + voter.Name);
                Console.WriteLine("DOB: " + voter.DateOfBirth);
                Console.WriteLine("Age: " + voter.Age);
                Console.WriteLine("Gender: " + voter.Gender);
                Console.WriteLine("Voting Location: " + voter.VotingLocation);
            }
            else
            {
                Console.WriteLine("*Voter Not Found*");
            }
        }

        public void DeleteVoter(string VoterId)
        {
            var voter = GetVoter(VoterId);
            if (voter != null)
            {
                voterContext.VoterDetails.Remove(voter);
                voterContext.SaveChanges();
                Console.WriteLine("*Voter details Deleted Successfully*");
            }
            else
            {
                Console.WriteLine("*Voter Not Found*");
            }
        }

        public VoterDetail GetVoter(string VoterId)
        {
            return voterContext.VoterDetails.Find(VoterId);
        }
    }
}
