using Microsoft.EntityFrameworkCore;
using Taxi_Booking_System.Interface;

namespace Taxi_Booking_System.Repository
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private TaxiBookingDbContext _context;
        private DbSet<T> _table;
        public Repository(TaxiBookingDbContext context)
        {
            _context = context;
            _table = context.Set<T>();
        }
        public async Task DeleteAsync(int id)
        {
            T? obj = await GetByIdAsync(id);
            if (obj != null)
            {
                _table.Remove(obj);
            }
        }

        public async Task<IEnumerable<T>> GetAllDataAsync()
        {
            return await _table.ToListAsync();
        }

        public async Task<T> GetByIdAsync(int id)
        {
            T? obj = await _table.FindAsync(id);
            return obj;
            
            
        }

        public async Task InsertAsync(T obj)
        {
           await _table.AddAsync(obj);
        }

        public async Task SaveAsync()
        {
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(int id, T updateObject)
        {
            T existingObject = await GetByIdAsync(id);
            if (existingObject != null)
            {
               _table.Attach(existingObject);
                _table.Entry(existingObject).State = EntityState.Modified;
                _table.Entry(existingObject).CurrentValues.SetValues(updateObject);
            }

        }
    }
}
