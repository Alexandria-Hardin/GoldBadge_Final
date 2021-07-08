using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Badge
{
    public class BadgeRepository
    {
        protected readonly Dictionary<int, List<string>> _doorAccessList = new Dictionary<int, List<string>>();
        public bool AddBadgeToDirectory(Badges newContent)
        {
            int startingCount = _doorAccessList.Count;
            _doorAccessList.Add(newContent.BadgeID, newContent.DoorAccess);
            bool wasAdded = (_doorAccessList.Count > startingCount) ? true : false;
            return wasAdded;
        }


        public Dictionary<int, List<string>> GetBadges()
        {
            return _doorAccessList;
        }

        public List<string> GetDoorAccessByID(int badgeid)
        {

            foreach (KeyValuePair<int, List<string>> content in _doorAccessList.Where(x => x.Key == badgeid))
            {
                return content.Value;
            }
            return null;
        }

        public bool UpdateExistingBadge(int originalBadgeID, Badges newContent)
        {
            var oldContent = GetDoorAccessByID(originalBadgeID);
            if (oldContent != null)
            {
                newContent.BadgeID = originalBadgeID;
                oldContent = newContent.DoorAccess;
                return true;
            }
            else
            {
                return false;
            }
        }
        public bool DeleteExistingBadge(Badges existingContent)
        {
            bool deleteResult = _doorAccessList.Remove(existingContent.BadgeID);
            return deleteResult;
        }
    }
}

