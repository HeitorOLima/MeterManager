﻿using MeterManager.CLI.UserInterface;

namespace MeterManager.CLI.Views
{   
    internal class MeterManagerUI
    {
        static void Main(string[] args)
        {
            var interfaceOptions = new InterfaceOptions();
            bool ExitProgram = false;
            while (ExitProgram)
            {
                var validation = interfaceOptions.MainMenu();
                if (validation == 6) ExitProgram = true;
            }
            Console.WriteLine("Thank you for the oportunity!");
        }
    }
}