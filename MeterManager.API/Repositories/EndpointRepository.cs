using EnergyEndpointManager.API.ApplicationContext;
using EnergyEndpointManager.API.Interfaces;
using EnergyEndpointManager.API.Models;
using Microsoft.EntityFrameworkCore;

namespace EnergyEndpointManager.API.Repositories
{
	public class EndpointRepository : IEndpointRepository
    {
        private readonly EnergyEndpointManagerDbContext _dbContext;

        public EndpointRepository(EnergyEndpointManagerDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<EnergyEndpoint> CreateAsync(EnergyEndpoint endpoint)
        {
            _dbContext.Meters.Add(endpoint);
            await _dbContext.SaveChangesAsync();

            return endpoint;
        }

        public async Task DeleteAsync(EnergyEndpoint endpoint)
        {
            await _dbContext.SaveChangesAsync();
        }

        public Task<List<EnergyEndpoint>> GetAllAsync()
        {
            return _dbContext.Meters.AsNoTracking().ToListAsync();
        }

        public async Task<EnergyEndpoint> GetBySerialNumberAsync(string serialNumber)
        {
            return await _dbContext.Meters.FindAsync(serialNumber);
        }

        public async Task<EnergyEndpoint> UpdateAsync(EnergyEndpoint endpoint)
        {
            _dbContext.Meters.Update(endpoint);
            await _dbContext.SaveChangesAsync();

            return endpoint;
        }
    }
}
