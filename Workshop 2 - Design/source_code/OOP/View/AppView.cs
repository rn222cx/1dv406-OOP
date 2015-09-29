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
            Console.WriteLine(StringResource.Welcome);
        }

        public MenuEnum.ListOptions listMenu()
        {
            // Below is to different way to work with strings, the second one is C# 6.0
            // TODO: TEAM -> Choose which string interpolation to stick with
            Console.WriteLine("1. {0}", AppStrings.menuAddNewMember);
            // Denna fungerar inte för mig i VS 2013. 
            //Console.WriteLine($"2. { AppStrings.menuAddNewBoat }");
            Console.Write(AppStrings.menuMakeChoice);

            while (true)
            {
                //int keyValue = int.Parse(Console.ReadLine());
                char keyValue = Console.ReadKey().KeyChar;

                switch (keyValue)
                {
                    case '1':
                        return MenuEnum.ListOptions.addMember;
                    case '2':
                        return MenuEnum.ListOptions.addBoat;
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
            Console.Write(AppStrings.addMemberSCN);
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

            Console.Write(AppStrings.addMemberSCN);
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
