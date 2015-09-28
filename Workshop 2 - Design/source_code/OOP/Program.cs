using Workshop_2.Model;
using System;
using System.Linq;
using System.Xml.Linq;

namespace Workshop_2
{
    class Program
    {
        static void Main(string[] args)
        {

            // Ett test för att se om det funkar med slack :)
            const char keyToYes = 'y';
            Console.WriteLine(View.StringResource.Welcome);

            Console.WriteLine("Do you want to add new member? press y if yes: ");
            ConsoleKeyInfo addMember = Console.ReadKey();
            if (addMember.KeyChar == keyToYes)
            {
                Console.Write("type member name         :");
                string name = Console.ReadLine();
                Console.Write("type member personal identification         :");
                string pid = Console.ReadLine();

                var member = new Member(name, pid);
                member.add();

                Console.WriteLine("You added member");
                Console.ReadLine();
            }


            
            Console.WriteLine("Do you want to add boat? press y if yes: ");
            ConsoleKeyInfo addBoat = Console.ReadKey();
            if(addBoat.KeyChar == keyToYes)
            {
                Console.Write("type member id         :");
                string memberId = Console.ReadLine();
                Console.Write("type boat type         :");
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
}