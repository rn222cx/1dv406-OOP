using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Workshop_2.Model;

namespace Workshop_2.View
{
    class ListView
    {
        private MemberDAL MemberDAL;
        private BoatDAL BoatDAL;
        private BoatView BoatView; // TODO: Would be great if ListView dosen't depend on BoatView
        public ListView()
        {
            MemberDAL = new MemberDAL();
            BoatDAL = new BoatDAL();
            BoatView = new BoatView();
        }
        /// <summary>
        /// Displays list with member name, social security number, member id and boats with boat information.
        /// </summary>
        public void renderVerboseListOfMembers()
        {
            // TODO: DRY displayCompactListOfMembers?
            Console.Clear();
            Console.WriteLine(AppStrings.renderVerboseListOfMembersTitle);
            Console.WriteLine(AppStrings.divider);

            var members = MemberDAL.getMembers();

            foreach (var member in members)
            {
                Console.WriteLine(AppStrings.renderVerboseList, member.Name, member.SocialSecurityNumber, member.MemberID);

                BoatView.getBoatsByID(member.MemberID);

                Console.WriteLine(AppStrings.divider);
            }

            Console.WriteLine(AppStrings.back, AppStrings.backKey);
            if (char.ToUpper(Console.ReadKey().KeyChar) == char.Parse(AppStrings.backKey))
            {
                return;
            }
        }
    }
}
