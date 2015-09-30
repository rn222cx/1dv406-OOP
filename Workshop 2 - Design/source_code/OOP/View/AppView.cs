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
        private MemberDAL memberDAL;
        private BoatDAL boatDAL;
        public AppView ()
        {
            memberDAL = new MemberDAL();
            boatDAL = new BoatDAL();
        }
        public void welcomeMessage()
        {
            Console.WriteLine(AppStrings.menuWelcome);
        }

        public ListOption listMenu()
        {
            Console.Clear();
            Console.WriteLine("1. {0}", AppStrings.menuAddNewMember);
            Console.WriteLine("2. {0}", AppStrings.menuAddNewBoat);
            Console.WriteLine("3. {0}", AppStrings.menuShowCompactListOfMembers);
            Console.WriteLine("5. {0}", AppStrings.removeMember);
            Console.WriteLine("Q. {0}", AppStrings.menuQuit);
            Console.Write(AppStrings.menuMakeChoice);

            while (true)
            {
                char keyValue = Console.ReadKey().KeyChar;
                switch (char.ToLower(keyValue))
                {
                    case '1':
                        return ListOption.addMember;
                    case '2':
                        return ListOption.addBoat;
                    case '3':
                        return ListOption.showCompactListOfMembers;
                    case '5':
                        return ListOption.removeMember;
                    case 'q':
                        return ListOption.quit;
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

            Console.Write(AppStrings.addMemberSSN);
            string id = Console.ReadLine();

            return new Member(name, id);
        }

        public void addMemberSuccess()
        {
            Console.WriteLine(AppStrings.addMemberSuccess);
        }

        public void addBoat()
        {
            Console.Clear();
            Console.WriteLine(AppStrings.menuAddNewBoat);
        }

        public Boat getNewBoat()
        {
            var boatType = new BoatType();

            Console.WriteLine("1. {0}", AppStrings.boatTypeSailbot);
            Console.WriteLine("2. {0}", AppStrings.boatTypeMotorsailer);
            Console.WriteLine("3. {0}", AppStrings.boatTypeCanoe);
            Console.WriteLine("4. {0}", AppStrings.boatTypeOther);
            Console.Write(AppStrings.addBoatType);

            var correctInput = false;
            while (!correctInput)
            {
                char type = Console.ReadKey().KeyChar;
                switch (char.ToLower(type))
                {
                    case '1':
                        correctInput = true;
                        boatType = BoatType.Sailboat;
                        break;
                    case '2':
                        correctInput = true;
                        boatType = BoatType.Motorsailer;
                        break;
                    case '3':
                        correctInput = true;
                        boatType = BoatType.Canoe;
                        break;
                    case '4':
                        correctInput = true;
                        boatType = BoatType.Other;
                        break;
                    default:
                        Console.Write(AppStrings.menuWrongChoice);
                        break;
                }
            }

            Console.Write(AppStrings.addBoatLength);
            string length = Console.ReadLine();
            
            return new Boat(boatType, length);
        }

        public int getNewBoatMemberID()
        {
            while (true)
            {
                int ID;
                Console.Write(AppStrings.getMemberId);
                if (int.TryParse(Console.ReadLine(), out ID))
                {
                    if (memberDAL.validateMemberID(ID))
                    {
                        var member = memberDAL.getMemberByID(ID);
                        Console.WriteLine(AppStrings.presentMembersName, member.Name);
                        Console.WriteLine(AppStrings.presentMembersSSN, member.SocialSecurityNumber);
                        var boats = boatDAL.getBoatsByMemberID(ID);
                        Console.WriteLine(AppStrings.presentMembersNumberOfBoats, boats.Count);
                        foreach (Boat boat in boats)
                        {
                            Console.WriteLine(AppStrings.presentBoat, boat.Type, boat.Length);
                        }
                        return ID;
                    }
                    else
                    {
                        Console.Write(AppStrings.getMemberIDFail);
                    }
                } 
            }
        }

        public void addBoatSuccess()
        {
            Console.WriteLine(AppStrings.addBoatSuccess);
        }

        public void displayCompactListOfMembers()
        {
            Console.Clear();
            Console.WriteLine(AppStrings.compactListOfMembers);
            Console.WriteLine(AppStrings.divider);
            var members = memberDAL.getMembers();

            foreach (var member in members)
            {
                Console.WriteLine(AppStrings.presentShortMember, member.Name, member.SocialSecurityNumber);
            }

            Console.WriteLine(AppStrings.back, AppStrings.backKey);
            if (char.ToUpper(Console.ReadKey().KeyChar) == char.Parse(AppStrings.backKey))
            {
                return;
            }
        }

        public void exit()
        {
            Console.Write("\n{0}", AppStrings.menuGoodBye);
            Console.ReadKey();
        }
    }
}
