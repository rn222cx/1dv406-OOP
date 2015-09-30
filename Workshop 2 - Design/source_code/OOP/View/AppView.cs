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
        public void welcomeMessage()
        {
            Console.WriteLine(AppStrings.Welcome);
        }

        public MenuEnum.ListOptions listMenu()
        {
            Console.Clear();
            Console.WriteLine("1. {0}", AppStrings.menuAddNewMember);
            Console.WriteLine("2. {0}", AppStrings.menuAddNewBoat);
            Console.WriteLine("Q. {0}", AppStrings.menuQuit);
            Console.Write(AppStrings.menuMakeChoice);

            while (true)
            {
                char keyValue = Console.ReadKey().KeyChar;
                switch (char.ToLower(keyValue))
                {
                    case '1':
                        return MenuEnum.ListOptions.addMember;
                    case '2':
                        return MenuEnum.ListOptions.addBoat;
                    case 'q':
                        Console.Write("\n{0}",AppStrings.menuGoodBye);
                        Console.ReadKey();
                        return MenuEnum.ListOptions.quit;
                    default:
                        Console.Write(AppStrings.menuWrongChoice);
                        break;
                } 
            }
        }

        public void addMember()
        {
            Console.Clear();
            Console.WriteLine(AppStrings.menuAddNewMember);

            //Console.Write(AppStrings.addMemberName);
            //string name = Console.ReadLine();

            //Console.Write(AppStrings.addMemberSCN);
            //string id = Console.ReadLine();

            //return new Member(name, id);
        }

        public string getMemberName()
        {
            Console.Write(AppStrings.addMemberName);
            string name = Console.ReadLine();

            return name;          
        }

        public string getMemberSSN()
        {
            Console.Write(AppStrings.addMemberSSN);
            string ssn = Console.ReadLine();

            return ssn;
        }

        public void addMemberSuccess()
        {
            
            Console.WriteLine(AppStrings.addMemberSuccess);
        }

        public Boat addBoat()
        {
            Console.Clear();
            Console.WriteLine(AppStrings.menuAddNewBoat);

            Console.Write(AppStrings.addMemberSSN);
            string memberId = Console.ReadLine();

            Console.Write(AppStrings.addBoatType);
            string type = Console.ReadLine();

            Console.Write(AppStrings.addBoatLength);
            string length = Console.ReadLine();
            
            return new Boat(memberId, type, length);
        }



        public void addBoatSuccess()
        {
            Console.WriteLine(AppStrings.addBoatSuccess);
        }
    }
}
