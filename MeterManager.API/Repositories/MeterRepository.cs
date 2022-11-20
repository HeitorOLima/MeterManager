using MeterManager.API.ApplicationContext;
using MeterManager.API.Interfaces;
using MeterManager.API.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace MeterManager.API.Repositories
{
    public class MeterRepository : IMeterRepository
    {
        private readonly MeterManagerDbContext _dbContext;

        public MeterRepository(MeterManagerDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<MeterModel> CreateAsync(MeterModel model)
        {
            _dbContext.Meters.Add(model);
            await _dbContext.SaveChangesAsync();

            return model;
        }

        public Task DeleteAsync(string serialNumber)
        {
            var modelToDelete = _dbContext.Meters.Find(serialNumber);

            _dbContext.Meters.Remove(modelToDelete);
            _dbContext.SaveChangesAsync();

            return Task.CompletedTask;
        }

        public Task<List<MeterModel>> GetAllAsync()
        {
            return _dbContext.Meters.AsNoTracking().ToListAsync();
        }

        public async Task<MeterModel> GetBySerialNumberAsync(string serialNumber)
        {
            var meter = await _dbContext.Meters.FindAsync(serialNumber);            
            return meter;
        }

        public Task UpdateAsync(MeterModel model)
        {
            _dbContext.Meters.Update(model);
            _dbContext.SaveChangesAsync();

            return Task.CompletedTask;
        }
    }
}
