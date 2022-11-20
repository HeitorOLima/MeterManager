using MeterManager.API.ApplicationContext;
using MeterManager.API.Interfaces;
using MeterManager.API.Models;
using MeterManager.API.Models.Enums;
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

        public async Task DeleteAsync(string serialNumber)
        {
            var modelToDelete = await _dbContext.Meters.FindAsync(serialNumber);
            _dbContext.Meters.Remove(modelToDelete);
            await _dbContext.SaveChangesAsync();
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

        public async Task UpdateAsync(MeterModel model)
        {
            _dbContext.Meters.Update(model);
            await _dbContext.SaveChangesAsync();
        }
    }
}
