using System;
using System.Collections.Generic;
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
        #endregion
        #region Model
        private MemberDAL MemberDAL;
        private BoatDAL BoatDAL;
        #endregion
        public AppController(AppView AppView, BoatView BoatView, MemberView MemberView, MenuView MenuView)
        {
            this.AppView = AppView;
            this.BoatView = BoatView;
            this.MemberView = MemberView;
            this.MenuView = MenuView;
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
            Menu.Add(ListOption.showVerboseListOfMembers, doRenderVerboseListOfMembers);
            Menu.Add(ListOption.editMember, doEditMember);
            Menu.Add(ListOption.editBoat, doEditBoat);
            Menu.Add(ListOption.removeMember, doRemoveMember);
            Menu.Add(ListOption.removeBoat, doRemoveBoat);
            Menu.Add(ListOption.quit, AppView.exit);

            while (menuChoice != ListOption.quit)
            {
                AppView.consoleClear();
                MenuView.welcomeMessage();
                menuChoice = MenuView.listMenu();
                AppView.consoleClear();
                Menu[menuChoice]();
            }
        }
        private void doViewMember()
        {
            int memberID = MemberView.getMemberID();
            MemberView.renderMemberByID(memberID);
            BoatView.renderShortInformationAboutBoatsByID(memberID);
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
            BoatView.renderShortInformationAboutBoatsByID(memberID);
            var newBoat = BoatView.getNewBoat();
            if (BoatDAL.add(memberID, newBoat))
            {
                BoatView.renderAddBoatSuccess();
            }
            else
                AppView.fail();

            AppView.waitForUserToRead();
        }
        private void doEditMember()
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
            var boats = new List<Boat>();

            MemberView.renderMemberByID(memberID);
            BoatView.renderShortInformationAboutBoatsByID(memberID);

            boats = BoatView.getBoatByID(memberID);
            int chooseBoat = BoatView.getBoatToEdit(boats);

            if (chooseBoat == -1)
            {
                // Do nothing
            }
            else if (BoatDAL.updateBoat(memberID, chooseBoat, BoatView.getNewBoat()))
            {
                BoatView.renderEditBoatSuccess();
            }
            else
                AppView.fail();

            AppView.waitForUserToRead();
        }
        private void doRemoveMember()
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
        private void doRemoveBoat()
        {
            int memberID = MemberView.getMemberID();
            var boats = new List<Boat>();

            MemberView.renderMemberByID(memberID);

            boats = BoatView.getBoatByID(memberID);
            int chooseBoat = BoatView.getBoatToRemove(boats);

            if (chooseBoat == -1)
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
        private void doRenderCompactListOfMembers()
        {
            AppView.renderListTitle(AppStrings.compactListOfMembers);
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
        private void doRenderVerboseListOfMembers()
        {
            AppView.renderListTitle(AppStrings.renderVerboseListOfMembersTitle);
            var members = MemberDAL.getMembers();

            foreach (var member in members)
            {
                AppView.renderVerboseListElement(member);
                BoatView.renderLongInformationAboutBoatsByID(member.MemberID);
                AppView.renderDivider();
            }

            AppView.renderGoBackQuestion();
            if (AppView.getGoBack())
            {
                return;
            }
        }
    }
}
