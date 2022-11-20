using System.Threading.Tasks;
using System.Threading;
using MeterManager.API.Models;

namespace MeterManager.API.Interfaces
{
    public interface IMeterService
    {
        Task<MeterModel> CreateAsync(MeterModel model);
        Task UpdateAsync(MeterModel model);
        Task DeleteAsync(string serialNumber);
        Task<List<MeterModel>> GetAllAsync();
        Task<MeterModel> GetBySerialNumberAsync(string serialNumber);
        Task<MeterModel> GetMeterModelToDelete(string serialNumber);
    }
}
