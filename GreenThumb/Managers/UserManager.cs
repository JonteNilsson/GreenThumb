using GreenThumb.Database;
using GreenThumb.Models;
using GreenThumb.Repositories;

namespace GreenThumb.Managers
{
    public static class UserManager
    {
        public static UserModel? _SignedInUser { get; set; }





        // Registrerar användaren 
        public static void RegisterUser(string username, string password)
        {
            using (GTDbContext context = new())
            {
                GTRepository<UserModel> userToRegister = new(context);

                UserModel newUser = new(username, password);

                userToRegister.Add(newUser);
                userToRegister.Complete();

            }
        }

        // Tar emot 2 strängar och skickar tillbaks en UserModel
        public static UserModel? SignInUser(string username, string password)
        {
            using (GTDbContext context = new())
            {
                GTRepository<UserModel> userToFind = new(context);

                // Hitta usern med hjälp av username (är unikt i databasen)
                var user = userToFind.FindUser(username);

                if (user?.Username == username && user.Password == password)
                {
                    _SignedInUser = user;
                    return user;
                }

                return null;

            }
        }

        // Loggar ut användaren
        public static void LogOutUser()
        {
            _SignedInUser = null;
        }


    }
}
