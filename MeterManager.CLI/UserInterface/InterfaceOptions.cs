using MeterManager.CLI.Dtos;
using MeterManager.CLI.MeterManagerServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeterManager.CLI.UserInterface
{
    internal class InterfaceOptions
    {
        MeterService _meterService = new MeterService();

        public InterfaceOptions()
        {
        }
        public int MainMenu()
        {
            int exitProgram = 0;
            string opt = "";

            Console.WriteLine("Welcome to the MeterManagerApplication!\n");
            Console.WriteLine(@"Please chose one of the actions bellow:\n
            1- Register a new Meter\n
            2- Edit a meter data\n
            3- Delete a meter from database\n
            4-  List all meters\n
            5- Find a meter by SerialNumber\n
            6- Exit Application\n
            ");

            opt = Console.ReadLine();

            if (string.IsNullOrEmpty(opt))
            {
                Console.WriteLine("Opção inválida! Tente novamente.");
                return exitProgram;
            }

            switch (opt)
            {
                case "1":
                    CreateMeter();
                    break;
                case "2":
                    break;
                case "3":
                    break;
                case "4":
                    break;
                case "5":
                    break;
                case "6":
                    exitProgram = 6;
                    break;

            }
            return exitProgram;
        }

        }
        private void ShowMeterData(MeterDto meter)
        {
            Console.WriteLine(@$"
             Meter Serial Number: {meter.SerialNumber}\n
             Meter Model Id: {meter.ModelId}\n
             Meter Number: {meter.Number}\n
             Meter Firmware Version: {meter.FirmwareVersion}\n
             Meter Switch State: {meter.SwitchState}\n
            ");
        }
        private void CreateMeter()
        {
            Console.WriteLine("Inform the meter serial Number, model Id, Number, Firmware version and the switch state. The data must be separated by a ';' character.");
            var userEntry = Console.ReadLine();

            if (string.IsNullOrEmpty(userEntry))
            {
                Console.WriteLine("Invalid data, try again");
            }
            else
            {
                var meterData = userEntry.Split(";");

                if (meterData.Count() < 5)
                {
                    Console.WriteLine("Invalid data, try again");
                }
                else
                {
                    var meter = new MeterDto
                    {
                        SerialNumber = meterData[0],
                        ModelId = Convert.ToInt32(meterData[1]),
                        Number = Convert.ToInt32(meterData[2]),
                        FirmwareVersion = meterData[3],
                        SwitchState = Convert.ToInt32(meterData[4])
                    };

                    await _meterService.CreateMeter(meter);

                    Console.WriteLine("Meter Succesfully created!\n");
                    ShowMeterData(meter);
                }
            }
        }
        private void updateMeter()
    {

    }
        private void GetMeterBySerialNumber()
        {

        }
        private void GetAllMeters()
        {

        }
        private void DeleteMeter()
        {

        }
    }
}