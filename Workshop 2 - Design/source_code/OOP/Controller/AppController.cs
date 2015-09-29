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
            string name = appView.getMemberName();
            string ssc = appView.getMemberSSN();
            
            //var newMember = appView.addMember();

            // Skapar ett nytt objekt här istället eftersom jag tror att det bryter mot MVC att göra det i vyn. 
            var newMember = new Member(name, ssc);
            
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
