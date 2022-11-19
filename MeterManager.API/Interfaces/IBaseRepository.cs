namespace MeterManager.API.Interfaces
{
    public interface IBaseRepository<T> where T : class
    {
        Task<T> CreateAsync(T model);
        Task<T> GetAsync(T model);
        Task<T> UpdateAsync(T model);
        Task<T> DeleteAsync(T model);
        Task<T> GetAllAsync();
    }
}
