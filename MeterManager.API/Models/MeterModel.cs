using MeterManager.API.Models.Enums;

namespace MeterManager.API.Models
{
    public class MeterModel
    {
        private string SerialNumber { get; set; }
        private MeterModelEnum ModelId { get; set; }
        private int Number { get; set; }
        private string FirmwareVersion { get; set; }
        private SwitchStateEnum SwitchState { get; set; }

    }
}
