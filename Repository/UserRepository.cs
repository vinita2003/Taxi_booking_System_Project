using Microsoft.EntityFrameworkCore;
using Taxi_Booking_System.Interface;
using Microsoft.Extensions.Logging;

namespace Taxi_Booking_System.Repository
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly TaxiBookingDbContext _context;
        private readonly DbSet<T> _table;
        private readonly ILogger<Repository<T>> _logger;

        public Repository(TaxiBookingDbContext context, ILogger<Repository<T>> logger)
        {
            _context = context;
            _table = context.Set<T>();
            _logger = logger;
        }

        public async Task DeleteAsync(int id)
        {
            try
            {
                T? obj = await GetByIdAsync(id);
                if (obj != null)
                {
                    _table.Remove(obj);
                }
                else
                {
                    _logger.LogWarning("DeleteAsync: Record with ID {Id} not found", id);
                }
            }
            catch (InvalidOperationException ex)
            {
                _logger.LogError(ex, "DeleteAsync: Invalid operation while deleting ID {Id}", id);
                throw;
            }
            catch (DbUpdateException ex)
            {
                _logger.LogError(ex, "DeleteAsync: DB update failed while deleting ID {Id}", id);
                throw;
            }
        }

        public async Task<IEnumerable<T>> GetAllDataAsync()
        {
            try
            {
                return await _table.ToListAsync();
            }
            catch (InvalidOperationException ex)
            {
                _logger.LogError(ex, "GetAllDataAsync: Invalid query on table {Table}", typeof(T).Name);
                throw;
            }
            catch (DbUpdateException ex)
            {
                _logger.LogError(ex, "GetAllDataAsync: DB update issue on table {Table}", typeof(T).Name);
                throw;
            }
        }

        public async Task<T> GetByIdAsync(int id)
        {
            try
            {
                var result = await _table.FindAsync(id);
                if (result == null)
                {
                    _logger.LogWarning("GetByIdAsync: No record found with ID {Id}", id);
                }
                return result!;
            }
            catch (InvalidOperationException ex)
            {
                _logger.LogError(ex, "GetByIdAsync: Invalid operation while fetching ID {Id}", id);
                throw;
            }
            catch (DbUpdateException ex)
            {
                _logger.LogError(ex, "GetByIdAsync: DB update issue while fetching ID {Id}", id);
                throw;
            }
        }

        public async Task InsertAsync(T obj)
        {
           
            try
            {
                await _table.AddAsync(obj);
            }
            catch (InvalidOperationException ex)
            {
                _logger.LogError(ex, "InsertAsync: Invalid operation while inserting object of type {Type}", typeof(T).Name);
                throw;
            }
            catch (DbUpdateException ex)
            {
                _logger.LogError(ex, "InsertAsync: DB update failed while inserting object of type {Type}", typeof(T).Name);
                throw;
            }
           
        }

        public async Task SaveAsync()
        {
            try
            {
                await _context.SaveChangesAsync();
            }
            
            catch (DbUpdateException ex)
            {
                _logger.LogError(ex, "SaveAsync: DB update failed");
                throw;
            }
           
        }

        public async Task UpdateAsync(int id, T updateObject)
        {
            try
            {
                T existingObject = await GetByIdAsync(id);
                if (existingObject == null)
                {
                    _logger.LogWarning("UpdateAsync: Record with ID {Id} not found", id);
                    return;
                }

                _context.Entry(existingObject).State = EntityState.Modified;
                _context.Entry(existingObject).CurrentValues.SetValues(updateObject);
            }
            catch (InvalidOperationException ex)
            {
                _logger.LogError(ex, "UpdateAsync: Invalid operation while updating record with ID {Id}", id);
                throw;
            }
            catch (DbUpdateException ex)
            {
                _logger.LogError(ex, "UpdateAsync: DB update failed while updating record with ID {Id}", id);
                throw;
            }
        }
    }
}
