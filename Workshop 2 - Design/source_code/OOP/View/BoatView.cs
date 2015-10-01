using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Workshop_2.Model;

namespace Workshop_2.View
{
    class BoatView
    {
        private BoatDAL boatDAL;
        public BoatView()
        {
            boatDAL = new BoatDAL();
        }
        #region Add
        public void addBoat()
        {
            Console.Clear();
            Console.WriteLine(AppStrings.menuAddNewBoat);
        }
        #endregion
        #region Get        
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
                        Console.Write(AppStrings.failMenuWrongChoice);
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
                    Console.Write(AppStrings.failWrongLength);
            }
        }
        public int getBoatToRemove(int memberID)
        {
            var boats = boatDAL.getBoatsByMemberID(memberID);
            if (boats.Count == 0)
            {
                Console.WriteLine(AppStrings.memberHasNoBoat);
                return 0;
            }
            else
            {
                int numOfBoats = 1;
                foreach (var boat in boats)
                {
                    Console.WriteLine(AppStrings.renderBoatInformation, numOfBoats, boat.Type, boat.Length);
                    numOfBoats++;
                }

                Console.WriteLine(AppStrings.getBoatToRemove);

                int boatNumber;
                string Result = Console.ReadLine();

                while (!Int32.TryParse(Result, out boatNumber) || boatNumber > boats.Count)
                {
                    Console.WriteLine(AppStrings.failNotValidNumber);
                    Result = Console.ReadLine();
                }
                return boatNumber - 1;
            }
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
                    Console.WriteLine(AppStrings.renderBoatInformation, boatNumber, boat.Type, boat.Length);
                    boatNumber++;
                }
            }
        }
        public int getBoatToEdit()
        {
            Console.WriteLine(AppStrings.getBoatToEdit);
            return Convert.ToInt32(Console.ReadLine()) - 1;
        }
        #endregion
        #region Render
        public void renderBoatsByID(int ID)
        {
            var boats = boatDAL.getBoatsByMemberID(ID);
            Console.WriteLine(AppStrings.renderMembersNumberOfBoats, boats.Count);
            foreach (Boat boat in boats)
            {
                Console.WriteLine(AppStrings.renderBoat, boat.Type, boat.Length);
            }
        }
        public void renderRemoveBoatSuccess()
        {
            Console.WriteLine(AppStrings.removeBoatSuccess);
        }
        public void renderEditBoatSuccess()
        {
            Console.WriteLine(AppStrings.editBoatSuccess);
        }
        public void renderAddBoatSuccess()
        {
            Console.WriteLine(AppStrings.addBoatSuccess);
        }
        #endregion
    }
}
