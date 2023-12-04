using GreenThumb.Database;
using Microsoft.EntityFrameworkCore;

namespace GreenThumb.Repositories
{
    internal class GTRepository<T> where T : class
    {
        private readonly GTDbContext _context;
        private readonly DbSet<T> _dbSet;

        public GTRepository(GTDbContext context)
        {
            _context = context;
            _dbSet = context.Set<T>();
        }

        // Get all for each model
        public List<T> GetAll()
        {
            return _dbSet.ToList();
        }

        // Find chosen model by ID
        public T? GetById(int id)
        {
            return _dbSet.Find(id);
        }

        // Add entity sent to method
        public void Add(T entity)
        {
            _dbSet.Add(entity);
        }

        // Delete chosen model for deletion
        public void Delete(int id)
        {
            T? entityToDelete = GetById(id);

            if (entityToDelete != null)
            {
                _dbSet.Remove(entityToDelete);
            }
        }

        // Saving changes
        public void Save()
        {
            _context.SaveChanges();
        }
    }
}
