using EnergyEndpointManager.API.Models.Enums;

namespace EnergyEndpointManager.API.Models
{
	public class Meter
    {
        public EMeterModel Model { get; set; }
        public int Number { get; set; }
        public string FirmwareVersion { get; set; }
    }
}
