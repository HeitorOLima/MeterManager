using MeterManager.API.Interfaces;
using MeterManager.API.Models;

namespace MeterManager.API.Repositories
{
    public class MeterRepository : IBaseRepository<MeterModel>
    {
        public Task<MeterModel> CreateAsync(MeterModel model)
        {
            throw new NotImplementedException();
        }
        public Task<MeterModel> GetAsync(MeterModel model)
        {
            throw new NotImplementedException();
        }
        public Task<MeterModel> UpdateAsync(MeterModel model)
        {
            throw new NotImplementedException();
        }
        public Task<MeterModel> DeleteAsync(MeterModel model)
        {
            throw new NotImplementedException();
        }
        public Task<MeterModel> GetAllAsync()
        {
            throw new NotImplementedException();
        }
        public Task<MeterModel> GetBySerialNumberAsync(string serialNumber)
        {
            throw new NotImplementedException();
        }
    }
}
