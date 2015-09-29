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
            appView.welcomMessage();
            menuChoice = appView.listMenu();

            switch (menuChoice)
            {
                case MenuEnum.ListOptions.addMember:
                    var newMember = appView.addMember();
                    memberDAL.add(newMember);
                    break;
                case MenuEnum.ListOptions.addBoat:
                    var newBoat = appView.addBoat();
                    boatDAL.add(newBoat);
                    break;
                case MenuEnum.ListOptions.quit:
                    break;
                default:
                    break;
            }
        }

    }
}
