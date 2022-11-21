using MeterManager.CLI.UserInterface;

namespace MeterManager.CLI.Views
{   
    internal class Program
    {
        static void Main(string[] args)
        {
            var interfaceOptions = new InterfaceOptions();
            bool ExitProgram = false;

            Console.WriteLine("Welcome to the MeterManager application!\n\n");

            while (!ExitProgram)
            {
                var validation = interfaceOptions.MainMenu();
                if (validation == 6) ExitProgram = true;
            }
            Console.WriteLine("Thank you for the oportunity!");
        }
    }
}