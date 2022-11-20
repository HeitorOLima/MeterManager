using MeterManager.API.Models;

namespace MeterManager.API.Interfaces
{
    public interface IMeterRepository
    {
        Task<MeterModel> CreateAsync(MeterModel model);
        Task<MeterModel> UpdateAsync(MeterModel model);
        Task DeleteAsync(string serialNumber);
        Task<List<MeterModel>> GetAllAsync();
        Task<MeterModel> GetBySerialNumberAsync(string serialNumber);
    }
}
