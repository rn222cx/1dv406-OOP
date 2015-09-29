using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Workshop_2.Model;

namespace Workshop_2.View
{
    class App
    {
        private bool correctInput = false;

        public void welcomMessage()
        {
            Console.WriteLine(StringResource.Welcome);
        }

        public void listMenu()
        {
            Console.WriteLine("1. Add a new member");
            Console.WriteLine("2. Add a boat to an existing user");
            Console.WriteLine("Enter any Key: ");

            do
            {
                int keyValue = int.Parse(Console.ReadLine());

                switch (keyValue)
                {
                    case 1:
                        addMember();
                        correctInput = true;
                        break;
                    case 2:
                        addBoat();
                        correctInput = true;
                        break;
                    default:
                        Console.WriteLine("Please choose a value from the list");
                        break;
                } 
            } while (correctInput == false);
            correctInput = false;
            Console.ReadLine();
        }

        public void addMember()
        {
            Console.WriteLine("Add New member section");

            Console.Write("type member name : ");
            string name = Console.ReadLine();
            Console.Write("type member personal identification : ");
            string pid = Console.ReadLine();

            var member = new Member(name, pid);
            member.add();

            Console.WriteLine("You added member");
            Console.ReadLine();
        }

        public void addBoat()
        {
            Console.WriteLine("Add New boat section");
            Console.Write("type member id :");
            string memberId = Console.ReadLine();
            Console.Write("type boat type :");
            string type = Console.ReadLine();
            Console.Write("type boat length         :");
            string length = Console.ReadLine();

            var boat = new Boat(memberId, type, length);
            boat.add();

            Console.WriteLine("You added boat");
            Console.ReadLine();
        }
    }
}
