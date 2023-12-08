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

        // Hämta ALLA önskade modeller
        public List<T> GetAll()
        {
            return _dbSet.ToList();
        }


        // Hitta model med ID
        public T? GetById(int id)
        {
            return _dbSet.Find(id);
        }

        // Lägg till model
        public void Add(T entity)
        {
            _dbSet.Add(entity);
        }

        // Delete model med ID
        public void Delete(int id)
        {
            T? entityToDelete = GetById(id);

            if (entityToDelete != null)
            {
                _dbSet.Remove(entityToDelete);
            }
        }

        // Spara ändringar
        public void Complete()
        {
            _context.SaveChanges();
        }

        // Hitta en user med hjälp av användarnamn
        public UserModel? FindUser(string username)
        {

            return _dbSet.OfType<UserModel>().FirstOrDefault(u => u.Username == username);
        }


        // Tar emot ett username och kollar om det redan existerar i databasen, returnerar en bool
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

        // Tar emot ett plantnamn och kollar så att det inte finns i databasen
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

        // Tar emot en lista och ett plantnamn för att kolla så att plantan inte finns i Garden redan. Returnerar en bool
        public bool CheckGardenForPlant(List<PlantModel> plants, string plantName)
        {
            bool result;

            foreach (var plant in plants)
            {
                if (plant.Name == plantName)
                {
                    result = false;
                    return result;
                }
            }
            result = true;
            return result;
        }

    }
}
