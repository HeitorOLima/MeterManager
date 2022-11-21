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
                ConfirmRead();
                return exitProgram;
            }

            switch (opt)
            {
                case "1":
                    CreateMeter();
                    ConfirmRead();
                    break;
                case "2":
                    UpdateMeter();
                    ConfirmRead();
                    break;
                case "3":
                    DeleteMeter();
                    ConfirmRead();
                    break;
                case "4":
                    GetAllMeters();
                    ConfirmRead();
                    break;
                case "5":
                    GetMeterBySerialNumber();
                    ConfirmRead();
                    break;
                case "6":
                    exitProgram = 6;
                    break;

            }
            return exitProgram;
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
        private async void CreateMeter()
        {
            var meter = GetMeterData();

            if(meter != null)
            {
                var createdMeter = await _meterService.CreateMeter(meter);
                
                Console.WriteLine("Meter Succesfully created!\n");
                ShowMeterData(createdMeter);
            }
            else
            {
                Console.WriteLine("Problem with create method");
            }
        }
        private async void UpdateMeter()
        {
            Console.WriteLine("Please inform the serial number of the meter that you want to Edit");
            var serialNumber = Console.ReadLine();

            if (string.IsNullOrEmpty(serialNumber))
                Console.WriteLine("Invalid serial number, please try again.");
            else{
                var meterToEdit = await _meterService.GetMeterBySerialNumber(serialNumber);

                Console.WriteLine("Are you sure that you want to edit the following Meter? [Y/N]\n");
                ShowMeterData(meterToEdit);

                var confirmation = Console.ReadLine();

                if (!string.IsNullOrEmpty(confirmation) && confirmation.ToUpper().Contains("Y"))
                {
                    var updatedMeter = GetMeterData();

                    await _meterService.UpdateMeter(updatedMeter);
                    Console.WriteLine("Meter Updated");
                }
            }
            ConfirmRead();
        }
        private async void GetMeterBySerialNumber()
        {
            Console.WriteLine("Inform the serial Number of the meter");
            var serialNumber = Console.ReadLine();

            if (!string.IsNullOrEmpty(serialNumber))
            {
                await _meterService.GetMeterBySerialNumber(serialNumber);
            }
            else
            {
                Console.WriteLine("Meter not found");
            }
            ConfirmRead();
        }
        private async void GetAllMeters()
        {
            var meters = await _meterService.GetAllMeters();

            if(!(meters.Count == 0))
            {
                Console.WriteLine("Meters information: ");
                foreach(var item in meters)
                {
                    ShowMeterData(item);
                }
            }
            else
            {
                Console.WriteLine("No meters found");
            }
            ConfirmRead();
        }
        private async void DeleteMeter()
        {
            Console.WriteLine("Inform the meter Serial Number");
            var serialNumber = Console.ReadLine();

            if (!string.IsNullOrEmpty(serialNumber))
            {
                await _meterService.DeleteMeter(serialNumber);
                Console.WriteLine("Meter deleted");
            }
            else
            {
                Console.WriteLine("Meter not found");
            }
            ConfirmRead();
        }

        private MeterDto GetMeterData() {

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

                    return meter;
                }
            }

            return null;
        }

        private void ConfirmRead()
        {
            Console.WriteLine("Press any key to continue...");
            Console.ReadLine();
            Console.Clear();
        }

    }
}

