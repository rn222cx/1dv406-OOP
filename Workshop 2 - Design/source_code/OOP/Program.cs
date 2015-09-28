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
            Console.WriteLine(View.StringResource.Welcome);
            Console.Write("type member name         :");
            string name = Console.ReadLine();
            Console.Write("type member personal identification         :");
            string pid = Console.ReadLine();

            var member = new Member(name, pid);
            member.add();

        }
    }
}