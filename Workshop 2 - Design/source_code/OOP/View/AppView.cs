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
            Console.WriteLine("0. {0}", AppStrings.viewMember);
            Console.WriteLine("1. {0}", AppStrings.menuAddNewMember);
            Console.WriteLine("2. {0}", AppStrings.menuAddNewBoat);
            Console.WriteLine("3. {0}", AppStrings.menuShowCompactListOfMembers);
            Console.WriteLine("4. {0}", AppStrings.menuShowVerboseListOfMembers);
            Console.WriteLine("5. {0}", AppStrings.editMember);
            Console.WriteLine("6. {0}", AppStrings.editBoat);
            Console.WriteLine("7. {0}", AppStrings.removeMember);
            Console.WriteLine("8. {0}", AppStrings.removeBoat);
            Console.WriteLine("Q. {0}", AppStrings.menuQuit);
            Console.Write(AppStrings.menuMakeChoice);

            while (true)
            {
                string keyValue = Console.ReadLine();
                switch (keyValue.ToLower())
                {
                    case "0":
                        return ListOption.viewMember;
                    case "1":
                        return ListOption.addMember;
                    case "2":
                        return ListOption.addBoat;
                    case "3":
                        return ListOption.showCompactListOfMembers;
                    case "4":
                        return ListOption.showVerboseListOfMembers;
                    case "5":
                        return ListOption.editMember;
                    case "6":
                        return ListOption.editBoat;
                    case "7":
                        return ListOption.removeMember;
                    case "8":
                        return ListOption.removeBoat;
                    case "q":
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

            return getMemberInfo();

        }

        public Member getMemberInfo()
        {
            return getMemberInfo(0);
        }

        public Member getMemberInfo(int ID)
        {
            Console.Write(AppStrings.addMemberName);
            string name = Console.ReadLine();

            Console.Write(AppStrings.addMemberSSN);
            string ssn = Console.ReadLine();

            var member = new Member(name, ssn, ID);

            return member;
        }

        public int chooseBoatToEdit()
        {
            Console.WriteLine(AppStrings.chooseBoatToEdit);
            return Convert.ToInt32(Console.ReadLine()) - 1;
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

        internal void editMemberSuccess()
        {
            Console.WriteLine(AppStrings.editMemberSuccess);
        }

        internal void editBoatSuccess()
        {
            Console.WriteLine(AppStrings.editBoatSuccess);
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
                string type = Console.ReadLine();
                switch (type)
                {
                    case "1":
                        correctInput = true;
                        boatType = BoatType.Sailboat;
                        break;
                    case "2":
                        correctInput = true;
                        boatType = BoatType.Motorsailer;
                        break;
                    case "3":
                        correctInput = true;
                        boatType = BoatType.Canoe;
                        break;
                    case "4":
                        correctInput = true;
                        boatType = BoatType.Other;
                        break;
                    default:
                        Console.Write(AppStrings.menuWrongChoice);
                        break;
                }
            }

            Console.Write(AppStrings.addBoatLength);
            int length;
            while (true)
            {
                if (int.TryParse(Console.ReadLine(), out length))
                {
                    return new Boat(boatType, length);
                }
                else
                    Console.Write(AppStrings.wrongLength);
            }
        }

        internal void removeBoatSuccess()
        {
            Console.WriteLine(AppStrings.removeBoatSuccess);
        }

        public void fail()
        {
            Console.WriteLine(AppStrings.fail);
        }

        public int getMemberID()
        {
            Console.Write(AppStrings.getMemberId);
            while (true)
            {
                int ID;
                if (int.TryParse(Console.ReadLine(), out ID))
                {
                    if (memberDAL.validateMemberID(ID))
                    {
                        return ID;
                    }
                    else
                    {
                        Console.Write(AppStrings.getMemberIDFail);
                    }
                }
            }
        }
        public int getNewBoatMemberID()
        {
                int ID = getMemberID();
                presentMemberByID(ID);
                presentBoatsByID(ID);
                return ID;
        }

        public void presentMemberByID(int ID)
        {
            var member = memberDAL.getMemberByID(ID);
            Console.WriteLine(AppStrings.presentMembersName, member.Name);
            Console.WriteLine(AppStrings.presentMembersSSN, member.SocialSecurityNumber);
        }

        public void presentBoatsByID(int ID)
        {
            var boats = boatDAL.getBoatsByMemberID(ID);
            Console.WriteLine(AppStrings.presentMembersNumberOfBoats, boats.Count);
            foreach (Boat boat in boats)
            {
                Console.WriteLine(AppStrings.presentBoat, boat.Type, boat.Length);
            }
        }

        public void addBoatSuccess()
        {
            Console.WriteLine(AppStrings.addBoatSuccess);
        }
        public void removeMemberSuccess()
        {
            Console.WriteLine(AppStrings.removeMemberSuccess);
        }

        /// <summary>
        /// Renders list of all members with name and member id.
        /// </summary>
        public void displayCompactListOfMembers()
        {
            Console.Clear();
            Console.WriteLine(AppStrings.compactListOfMembers);
            Console.WriteLine(AppStrings.divider);
            var members = memberDAL.getMembers();

            foreach (var member in members)
            {
                var numerOfBoats = boatDAL.getBoatsByMemberID(member.MemberID).Count;
                Console.WriteLine(AppStrings.presentCompactList, member.Name, member.MemberID, numerOfBoats);
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

        /// <summary>
        /// Displays list with member name, social security number, member id and boats with boat information.
        /// </summary>
        public void displayVerboseListOfMembers()
        {
            // TODO: DRY displayCompactListOfMembers?
            Console.Clear();
            Console.WriteLine(AppStrings.verboseListOfMembers);
            Console.WriteLine(AppStrings.divider);

            var members = memberDAL.getMembers();

            foreach (var member in members)
            {
                Console.WriteLine(AppStrings.presentVerboseList, member.Name, member.SocialSecurityNumber, member.MemberID);

                getBoatsByID(member.MemberID);
                                             
                Console.WriteLine(AppStrings.divider);
            }

            Console.WriteLine(AppStrings.back, AppStrings.backKey);
            if (char.ToUpper(Console.ReadKey().KeyChar) == char.Parse(AppStrings.backKey))
            {
                return;
            }
        }
        public void showBoatsByID(int ID)
        {
            getBoatsByID(ID);
        }
        public void getBoatsByID(int ID)
        {
            var boats = boatDAL.getBoatsByMemberID(ID);
            if (boats.Count == 0)
            {
                Console.WriteLine(AppStrings.memberHasNoBoat);
            }
            else
            {

                int boatNumber = 1;

                foreach (var boat in boats)
                {
                    Console.WriteLine(AppStrings.presentBoatInformation, boatNumber, boat.Type, boat.Length);
                    boatNumber++;
                }
            }

            
        }

        public void waitForUserToRead()
        {
            Console.WriteLine(AppStrings.pressAnyKey);
            Console.ReadLine();
        }

        public int chooseBoatToRemove()
        {
            Console.WriteLine(AppStrings.chooseBoatToRemove);

            int boatNumber;
            String Result = Console.ReadLine();

            while (!Int32.TryParse(Result, out boatNumber))
            {
                Console.WriteLine("Not a valid number, try again.");
                Result = Console.ReadLine();
            }
            return boatNumber;

        }
    }
}
