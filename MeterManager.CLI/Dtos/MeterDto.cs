using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeterManager.CLI.Dtos
{
    internal class MeterDto
    {
        public string SerialNumber { get; set; }
        public int ModelId { get; set; }
        public int Number { get; set; }
        public string FirmwareVersion { get; set; }
        public int SwitchState { get; set; }
    }       
}
