using EnergyEndpointManager.API.Models;

namespace EnergyEndpointManager.API.Interfaces
{
    public interface IEndpointRepository
    {
        Task<EnergyEndpoint> CreateAsync(EnergyEndpoint model);
        Task<EnergyEndpoint> UpdateAsync(EnergyEndpoint model);
        Task DeleteAsync(EnergyEndpoint model);
        Task<List<EnergyEndpoint>> GetAllAsync();
        Task<EnergyEndpoint> GetBySerialNumberAsync(string serialNumber);
    }
}
