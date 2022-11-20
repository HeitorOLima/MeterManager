using MeterManager.API.Models.Enums;
using System.ComponentModel.DataAnnotations;

namespace MeterManager.API.Models
{
    public class MeterModel
    {
        [Key]
        public string SerialNumber { get; set; }
        public MeterModelEnum ModelId { get; set; }
        public int Number { get; set; }
        public string FirmwareVersion { get; set; }
        public  SwitchStateEnum SwitchState { get; set; }

    }
}
