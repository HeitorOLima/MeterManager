using MeterManager.API.Interfaces;
using MeterManager.API.Models;
using MeterManager.API.Repositories;
using AutoMapper;

namespace MeterManager.API.Services
{
    public class MeterService : IMeterService
    {
        private readonly IMeterRepository _meterRepository;
        private readonly IMapper _mapper;
        public MeterService(MeterRepository meterRepository, IMapper mapper)
        {
            _meterRepository = meterRepository;
            _mapper = mapper;
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

        public Task UpdateAsync(MeterModel model)
        {
            var meterExist = CheckIfMeterExists(model);
            if (!meterExist)
                return null;
                
            return _meterRepository.UpdateAsync(model);
        }

        private bool CheckIfMeterExists(MeterModel model)
        {
            var isUnique = _meterRepository.GetBySerialNumberAsync(model.SerialNumber) == null ? true : false;
            return isUnique;    
        }

        public Task<MeterModel> GetMeterModelToDelete(string serialNumber)
        {
            var meter = _meterRepository.GetBySerialNumberAsync(serialNumber);
            return meter;
        }
    }
}
