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

        public void doControll(App a)
        {
            a.welcomMessage();
            a.render();
        }

    }
}
