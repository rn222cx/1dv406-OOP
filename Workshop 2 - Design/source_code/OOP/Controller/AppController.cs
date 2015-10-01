using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Workshop_2.Model;
using Workshop_2.View;

namespace Workshop_2.Controller
{
    class AppController
    {
        #region View
        private AppView AppView;
        private BoatView BoatView;
        private MemberView MemberView;
        private MenuView MenuView;
        private ListView ListView;
        #endregion
        #region Model
        private MemberDAL MemberDAL;
        private BoatDAL BoatDAL;
        #endregion
        public AppController(AppView AppView, BoatView BoatView, MemberView MemberView, MenuView MenuView, ListView ListView)
        {
            this.AppView = AppView;
            this.BoatView = BoatView;
            this.MemberView = MemberView;
            this.MenuView = MenuView;
            this.ListView = ListView;
            MemberDAL = new MemberDAL();
            BoatDAL = new BoatDAL();
        }

        public void doControll()
        {
            Dictionary<ListOption, Action> Menu = new Dictionary<ListOption, Action>();
            ListOption menuChoice = new ListOption();
            Menu.Add(ListOption.viewMember, doViewMember);
            Menu.Add(ListOption.addMember, doAddMember);
            Menu.Add(ListOption.addBoat, doAddBoat);
            Menu.Add(ListOption.showCompactListOfMembers, doRenderCompactListOfMembers);
            Menu.Add(ListOption.showVerboseListOfMembers, ListView.renderVerboseListOfMembers);
            Menu.Add(ListOption.editMember, doEditMember);
            Menu.Add(ListOption.editBoat, doEditBoat);
            Menu.Add(ListOption.removeMember, doRemoveMember);
            Menu.Add(ListOption.removeBoat, doRemoveBoat);
            Menu.Add(ListOption.quit, AppView.exit);

            while (menuChoice != ListOption.quit)
            {
                MenuView.welcomeMessage();
                menuChoice = MenuView.listMenu();
                Menu[menuChoice]();
            }
        }

        private void doViewMember()
        {
            int ID = MemberView.getMemberID();
            MemberView.renderMemberByID(ID);
            BoatView.renderBoatsByID(ID);
            AppView.waitForUserToRead();
        }

        private void doAddMember()
        {
            var newMember = MemberView.addMember();
            
            if (MemberDAL.saveMember(newMember))
            {
                MemberView.renderAddMemberSuccess();
            }
            else
                AppView.fail();

            AppView.waitForUserToRead();
        }

        private void doAddBoat()
        {
            BoatView.addBoat();
            var memberID = MemberView.getMemberID();
            MemberView.renderMemberByID(memberID);
            BoatView.renderBoatsByID(memberID);
            var newBoat = BoatView.getNewBoat();
            if (BoatDAL.add(memberID, newBoat))
            {
                BoatView.renderAddBoatSuccess();
            }
            else
                AppView.fail();

            AppView.waitForUserToRead();
        }

        public void doEditMember()
        {
            int memberID = MemberView.getMemberID();
            MemberView.renderMemberByID(memberID);
            var member = MemberView.getMemberInfo(memberID);
            if (MemberDAL.saveMember(member))
            {
                MemberView.renderEditMemberSuccess();
            }
            else
                AppView.fail();

            AppView.waitForUserToRead();
        }

        private void doEditBoat()
        {
            int memberID = MemberView.getMemberID();

            MemberView.renderMemberByID(memberID);
            BoatView.renderBoatsByID(memberID);

            int chooseBoat = BoatView.getBoatToEdit();

            if (BoatDAL.updateBoat(memberID, chooseBoat, BoatView.getNewBoat()))
            {
                BoatView.renderEditBoatSuccess();
            }
            else
                AppView.fail();

            AppView.waitForUserToRead();
        }

        public void doRemoveMember()
        {
            int memberID = MemberView.getMemberID();
            MemberView.renderMemberByID(memberID);
            if (MemberDAL.removeMember(memberID))
            {
                MemberView.renderRemoveMemberSuccess();
            }
            else
                AppView.fail();

            AppView.waitForUserToRead();
        }

        public void doRemoveBoat()
        {
            int memberID = MemberView.getMemberID();

            MemberView.renderMemberByID(memberID);
            BoatView.renderBoatsByID(memberID);

            int chooseBoat = BoatView.getBoatToRemove(memberID);

            if (chooseBoat == 0)
            {
                // Do nothing
            }
            else if (BoatDAL.removeBoat(memberID, chooseBoat))
            {
                BoatView.renderRemoveBoatSuccess();
            }
            else
                AppView.fail();

            AppView.waitForUserToRead();
        }
        public void doRenderCompactListOfMembers()
        {
            AppView.renderCompactListTitle();
            var members = MemberDAL.getMembers();

            foreach (var member in members)
            {
                var numberOfBoats = BoatDAL.getBoatsByMemberID(member.MemberID).Count;
                AppView.renderCompactListElement(member, numberOfBoats);
            }

            AppView.renderGoBackQuestion();
            if (AppView.getGoBack())
            {
                return;
            }
        }
        public void doRenderVerboseListOfMembers()
        {
            // TODO: Implement
        }

    }
}
