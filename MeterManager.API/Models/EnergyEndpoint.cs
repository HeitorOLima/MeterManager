using EnergyEndpointManager.API.Models.Enums;

namespace EnergyEndpointManager.API.Models
{
	public class EnergyEndpoint
	{
        public string SerialNumber { get; set; }	
		public Meter Meter { get; set; }
		public ESwitchState SwitchState { get; set; }
    }
}
