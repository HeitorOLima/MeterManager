using EnergyEndpointManager.API.Interfaces;
using EnergyEndpointManager.API.Models;

namespace EnergyEndpointManager.API.Services
{
    public class EndpointService : IEndpointService
    {
        private readonly IEndpointRepository _endpointRepository;
        public EndpointService(IEndpointRepository endpointRepository)
        {
            _endpointRepository = endpointRepository;
        }

        public async Task<EnergyEndpoint> CreateAsync(EnergyEndpoint model)
        {
            var serialNumberIsUnique = await CheckIfMeterExists(model);

            if (serialNumberIsUnique)
                return await _endpointRepository.CreateAsync(model);

            throw new Exception("The energy endpoint you are trying to delete already exist.");
        }

        public async Task DeleteAsync(string endpointSerialNumber)
        {
            var endpoint = await _endpointRepository.GetBySerialNumberAsync(endpointSerialNumber);

            if (endpoint is null)
                throw new Exception("The energy endpoint you are trying to delete does not exist.");

            await _endpointRepository.DeleteAsync(endpoint);
        }

        public Task<List<EnergyEndpoint>> GetAllAsync()
        {
            return _endpointRepository.GetAllAsync();
        }

        public Task<EnergyEndpoint> GetBySerialNumberAsync(string serialNumber)
        {
            return _endpointRepository.GetBySerialNumberAsync(serialNumber);
        }

        public async Task<EnergyEndpoint> UpdateAsync(EnergyEndpoint model)
        {
            var meterFound = await GetMeterModelToUpdate(model.SerialNumber);
            
            if (meterFound == null)
                throw new InvalidOperationException("The energy endpoint you are trying to update does not exist.");
            
            var meterToUpdate = ConciliateMeterData(meterFound, model);
                
            return await _endpointRepository.UpdateAsync(meterToUpdate);
        }

        private async Task<bool> CheckIfMeterExists(EnergyEndpoint model)
        {
            return await _endpointRepository.GetBySerialNumberAsync(model.SerialNumber) == null ? false : true;
        }

        public Task<EnergyEndpoint> GetMeterModelToDelete(string serialNumber)
        {
            var meter = _endpointRepository.GetBySerialNumberAsync(serialNumber);
            return meter;
        }

        public async Task<EnergyEndpoint> GetMeterModelToUpdate(string serialNumber)
        {
            var meter = await _endpointRepository.GetBySerialNumberAsync(serialNumber);
            return meter;
        }

        private EnergyEndpoint ConciliateMeterData(EnergyEndpoint modelFound, EnergyEndpoint newModelData)
        {
            modelFound.SerialNumber = newModelData.SerialNumber;
            modelFound.Meter = newModelData.Meter;
            modelFound.SwitchState= newModelData.SwitchState;

            return modelFound;
        }
	}
}
