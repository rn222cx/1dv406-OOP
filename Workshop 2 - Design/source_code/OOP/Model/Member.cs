using System.Collections.Generic;

namespace Workshop_2.Model
{
    class Member
    {
        public int MemberID { get; set; }
        public string Name { get; set; }
        public string SocialSecurityNumber { get; set; }
        private List<Boat> membersBoats = new List<Boat>();

        public Member(string Name, string SocialSecurityNumber)
            : this(Name, SocialSecurityNumber, 0)
        {

        }

        public Member(string Name, string SocialSecurityNumber, int MemberID)
        {
            this.Name = Name;
            this.SocialSecurityNumber = SocialSecurityNumber;
            this.MemberID = MemberID;
        }
        
        /// <summary>
        /// Add boat to members list of boats.
        /// </summary>
        /// <param name="boat"></param>
        public void addBoat(Boat boat)
        {
            membersBoats.Add(boat);
        }

        public void removeBoat(Boat boat)
        {
            membersBoats.Remove(boat);
        }
        
        // Get the members boats.
        public IEnumerable<Boat> getBoats()
        {
            return membersBoats;
        }
    }
}
