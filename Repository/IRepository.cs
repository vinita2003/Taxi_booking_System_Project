namespace Taxi_Booking_System.Interface
{
    public interface IRepository<T> where T : class
    {
        Task<IEnumerable<T>> GetAllDataAsync();
        Task<T>? GetByIdAsync(int id);
        Task InsertAsync(T obj);
        Task UpdateAsync(int id, T obj);
        Task DeleteAsync(int id);
        Task SaveAsync();

    }
}
