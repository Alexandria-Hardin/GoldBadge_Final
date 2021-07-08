using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Claim
{
    public class ClaimRepository
    {
        protected readonly Queue<Claims> _claimDirectory = new Queue<Claims>();
        public bool AddClaimToDirectory(Claims newContent)
        {
            int startingCount = _claimDirectory.Count;
            _claimDirectory.Enqueue(newContent);
            bool wasAdded = (_claimDirectory.Count > startingCount);
            return wasAdded;
        }
        public Queue<Claims> GetClaims()
        {
            return _claimDirectory;
        }
        public Claims GetClaimByID(int claimid)
        {
            foreach (Claims content in _claimDirectory)
            {
                return content;
            }
            return null;
        }
        public Claims NextItemInQueue()
        {
            return _claimDirectory.Peek();
        }
        public void RemoveFromQueue()
        {
            _claimDirectory.Dequeue();
        }

        public bool UpdateExistingClaim(int originalClaimID, Claims newContent)
        {
            Claims oldContent = GetClaimByID(originalClaimID);
            if (oldContent != null)
            {
                oldContent.ClaimID = newContent.ClaimID;
                oldContent.TypeOfClaim = newContent.TypeOfClaim;
                oldContent.Description = newContent.Description;
                oldContent.ClaimAmount = newContent.ClaimAmount;
                oldContent.DateOfIncident = newContent.DateOfIncident;
                oldContent.DateOfClaim = newContent.DateOfClaim;
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
