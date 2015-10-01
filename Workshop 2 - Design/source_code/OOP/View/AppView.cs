using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Workshop_2.Model;

namespace Workshop_2.View
{
    class AppView
    {
        public void fail()
        {
            Console.WriteLine(AppStrings.failGeneral);
        }
        public void exit()
        {
            Console.Write(AppStrings.menuGoodBye);
            Console.ReadKey();
        }
        public void waitForUserToRead()
        {
            Console.WriteLine(AppStrings.pressAnyKey);
            Console.ReadLine();
        }
    }
}
