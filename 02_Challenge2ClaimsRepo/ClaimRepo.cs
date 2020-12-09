using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02_Challenge2ClaimsRepo
{
    class ClaimRepo
    {
        private readonly List<Claim> _claimList = new List<Claim>();

        //Create
        public void CreateANewClaim(Claim newClaim)
        {
            _claimList.Add(newClaim);
        }

        //Read
        public List<Claim> GetClaimList()
        {
            return _claimList;
        }

        //Is Valid
        public void IsValid()
        {

        }
        

        //Delete
        

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
    }
}

 
