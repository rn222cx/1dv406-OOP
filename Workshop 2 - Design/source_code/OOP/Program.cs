﻿using Workshop_2.Model;
using System;
using System.Linq;
using System.Xml.Linq;
//using Workshop_2.Controller;

namespace Workshop_2
{
    class Program
    {
        static void Main(string[] args)
        {
            Controller.AppController ac = new Controller.AppController();
            View.App a = new View.App();

            ac.doControll(a);
            
        }
    }
}