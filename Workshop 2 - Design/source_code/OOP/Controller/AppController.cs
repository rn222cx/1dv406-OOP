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
        private AppView appView;
        private MemberDAL memberDAL;
        private BoatDAL boatDAL;
        public AppController(AppView appView)
        {
            this.appView = appView;
            memberDAL = new MemberDAL();
            boatDAL = new BoatDAL();
        }
        public void doControll()
        {
            MenuEnum.ListOptions menuChoice;
            appView.welcomeMessage();
            menuChoice = appView.listMenu();

            switch (menuChoice)
            {
                case MenuEnum.ListOptions.addMember:
                    doAddMember();
                    break;
                case MenuEnum.ListOptions.addBoat:
                    doAddBoat();
                    break;
                case MenuEnum.ListOptions.quit:
                    break;
                default:
                    break;
            }
        }

        private void doAddMember()
        {
            appView.addMember();
            var newMember = new Member(appView.getMemberName(), appView.getMemberSSN());
            
            if (memberDAL.add(newMember))
            {
                appView.addMemberSuccess();
            }
        }

        private void doAddBoat()
        {
            var newBoat = appView.addBoat();
            if (boatDAL.add(newBoat))
            {
                appView.addBoatSuccess();
            }
        }

    }
}
