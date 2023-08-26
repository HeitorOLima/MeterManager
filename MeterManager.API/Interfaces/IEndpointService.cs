using EnergyEndpointManager.API.Models;

namespace EnergyEndpointManager.API.Interfaces
{
	public interface IEndpointService
    {
        Task<EnergyEndpoint> CreateAsync(EnergyEndpoint model);
        Task<EnergyEndpoint> UpdateAsync(EnergyEndpoint model);
        Task DeleteAsync(string serialNumber);
        Task<List<EnergyEndpoint>> GetAllAsync();
        Task<EnergyEndpoint> GetBySerialNumberAsync(string serialNumber);
        Task<EnergyEndpoint> GetMeterModelToDelete(string serialNumber);
    }
}
