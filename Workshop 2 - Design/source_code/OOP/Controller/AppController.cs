using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Workshop_2.View;

namespace Workshop_2.Controller
{
    class AppController
    {
        public void doControll(App appView)
        {
            Model.MenuEnum.ListOptions menuChoice;
            appView.welcomMessage();
            menuChoice = appView.listMenu();

            switch (menuChoice)
            {
                case Model.MenuEnum.ListOptions.addMember:
                    var newMember = appView.addMember();
                    newMember.add();
                    break;
                case Model.MenuEnum.ListOptions.addBoat:
                    var newBoat = appView.addBoat();
                    newBoat.add();
                    break;
                case Model.MenuEnum.ListOptions.quit:
                    break;
                default:
                    break;
            }
        }

    }
}
