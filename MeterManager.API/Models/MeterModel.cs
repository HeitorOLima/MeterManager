using MeterManager.API.Models.Enums;
using System.ComponentModel.DataAnnotations;

namespace MeterManager.API.Models
{
    public class MeterModel
    {
        [Key]
        public string SerialNumber { get; set; }
        private MeterModelEnum ModelId { get; set; }
        private int Number { get; set; }
        private string FirmwareVersion { get; set; }
        private SwitchStateEnum SwitchState { get; set; }

    }
}
