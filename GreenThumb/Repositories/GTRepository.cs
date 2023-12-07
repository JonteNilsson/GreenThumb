using GreenThumb.Database;
using GreenThumb.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking.Internal;

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

        // Delete chosen model
        public void Delete(int id)
        {
            T? entityToDelete = GetById(id);

            if (entityToDelete != null)
            {
                _dbSet.Remove(entityToDelete);
            }
        }

        // Saving changes
        public void Complete()
        {
            _context.SaveChanges();
        }

        public UserModel? FindUser(string username)
        {

            return _dbSet.OfType<UserModel>().FirstOrDefault(u => u.Username == username);
        }


        public bool FindUsername(string username)
        {
            bool result = true;

            var doesUsernameExist = _dbSet.OfType<UserModel>().FirstOrDefault(u => u.Username == username);
            if (doesUsernameExist != null)
            {

                return result;
            }

            result = false;
            return result;


        }

        public bool ValidatePlantName(string plantName)
        {
            bool result = true;

            var doesPlantExist = _dbSet.OfType<PlantModel>().FirstOrDefault(u => u.Name == plantName);

            if (doesPlantExist != null)
            {
                return result;
            }

            result = false;
            return result;


        }


    }
}
