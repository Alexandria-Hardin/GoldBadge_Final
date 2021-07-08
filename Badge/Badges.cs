using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Badge
{
    public class Badges
    {
        public int BadgeID { get; set; }
        public List<string> DoorAccess = new List<string>();
        public Badges() { }
        public Badges(int badgeid, List<string>doorAccess)
        {
            BadgeID = badgeid;
            DoorAccess = doorAccess;
        }
    }
}
