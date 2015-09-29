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
        public void welcomMessage()
        {
            Console.WriteLine(StringResource.Welcome);
        }

        public MenuEnum.ListOptions listMenu()
        {
            // Below is to different way to work with strings, the second one is C# 6.0
            // TODO: Team: Choose which string interpolation to stick with
            Console.WriteLine("1. {0}", AppStrings.menuAddNewMember);
            Console.WriteLine($"2. { AppStrings.menuAddNewBoat }");
            Console.Write(AppStrings.menuMakeChoice);

            while (true)
            {
                int keyValue = int.Parse(Console.ReadLine());

                switch (keyValue)
                {
                    case 1:
                        return MenuEnum.ListOptions.addMember;
                    case 2:
                        return MenuEnum.ListOptions.addBoat;
                    default:
                        Console.Write(AppStrings.menuWrongChoice);
                        break;
                } 
            }
        }

        public Member addMember()
        {
            Console.Clear();
            Console.WriteLine(AppStrings.menuAddNewMember);

            Console.Write(AppStrings.addMemberName);
            string name = Console.ReadLine();
            Console.Write(AppStrings.addMemberSCN);
            string id = Console.ReadLine();

            // TODO: Success message should only be displayed after success, maybe put in a new method and let MemberDAL.Add() return true if success?
            Console.WriteLine(AppStrings.addMemberSuccess);

            return new Member(name, id);
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

            // TODO: Success message should only be displayed after success, maybe put in a new method and let BoatDAL.Add() return true if success?
            Console.WriteLine(AppStrings.addBoatSuccess);

            return new Boat(memberId, type, length);
        }
    }
}
