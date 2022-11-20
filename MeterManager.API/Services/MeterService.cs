using MeterManager.API.Interfaces;
using MeterManager.API.Models;

namespace MeterManager.API.Services
{
    public class MeterService : IMeterService
    {
        private readonly IMeterRepository _meterRepository;
        public MeterService(IMeterRepository meterRepository)
        {
            _meterRepository = meterRepository;
        }

        public async Task<MeterModel> CreateAsync(MeterModel model)
        {
            var serialNumberIsUnique = CheckIfMeterExists(model);

            if (!serialNumberIsUnique)
                return null;
            
            return await _meterRepository.CreateAsync(model);
        }

        public async Task DeleteAsync(string serialNumber)
        {
            await _meterRepository.DeleteAsync(serialNumber);
        }

        public Task<List<MeterModel>> GetAllAsync()
        {
            return _meterRepository.GetAllAsync();
        }

        public Task<MeterModel> GetBySerialNumberAsync(string serialNumber)
        {
            return _meterRepository.GetBySerialNumberAsync(serialNumber);
        }

        public async Task<MeterModel> UpdateAsync(MeterModel model)
        {
            var meterExist = CheckIfMeterExists(model);
            if (!meterExist)
                return null;
                
            return await _meterRepository.UpdateAsync(model);
        }

        private bool CheckIfMeterExists(MeterModel model)
        {
            var isUnique = _meterRepository.GetBySerialNumberAsync(model.SerialNumber) == null ? false : true;
            return isUnique;    
        }

        public Task<MeterModel> GetMeterModelToDelete(string serialNumber)
        {
            var meter = _meterRepository.GetBySerialNumberAsync(serialNumber);
            return meter;
        }
    }
}
