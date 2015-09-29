﻿using Workshop_2.Model;
using System;
using System.Linq;
using System.Xml.Linq;
using Workshop_2.Controller;
using Workshop_2.View;

namespace Workshop_2
{
    class Program
    {
        static void Main(string[] args)
        {
            // Creating new instances of view, controller and model
            //var memberDAL = new MemberDAL();
            var appView = new AppView();
            var appController = new AppController(appView);

            // Launching controller method. 
            appController.doControll();
            
        }
    }
}