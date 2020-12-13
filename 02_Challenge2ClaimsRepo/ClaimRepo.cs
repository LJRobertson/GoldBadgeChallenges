using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02_Challenge2ClaimsRepo
{
    public class ClaimRepo
    {
        private readonly List<Claim> _claimList = new List<Claim>();
        Queue<Claim> _claimsQueue = new Queue<Claim>();


        //Create
        public void CreateANewClaim(Claim newClaim)
        {
            _claimList.Add(newClaim);
        }

        public void CreateANewClaimToQueue(Claim newClaim)
        {
            _claimsQueue.Enqueue(newClaim);
        }

        //Read
        public List<Claim> GetClaimList()
        {
            return _claimList;
        }

        public Queue<Claim> GetClaimQueue()
        {
            return _claimsQueue;
        }


        //Get By Number
        public Claim GetClaimByID(int claimNumber)
        {
            foreach (Claim claimItem in _claimList)
            {
                if (claimItem.ClaimID == claimNumber)
                {
                    return claimItem;
                }
            }
            return null;
        }

        public Claim GetClaimByIDViaQueue(int claimNumber)
        {
            foreach (Claim claimItem in _claimsQueue)
            {
                if(claimItem.ClaimID == claimNumber)
                {
                    return claimItem;
                }
            }
            return null;
        }
    }
}

 
