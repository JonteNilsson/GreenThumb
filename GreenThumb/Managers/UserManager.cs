using GreenThumb.Database;
using GreenThumb.Models;
using GreenThumb.Repositories;

namespace GreenThumb.Managers
{
    public static class UserManager
    {
        public static UserModel? _SignedInUser { get; set; }






        public static UserModel RegisterUser(string username, string password)
        {
            using (GTDbContext context = new())
            {
                GTRepository<UserModel> userToRegister = new(context);

                UserModel newUser = new(username, password);

                userToRegister.Add(newUser);
                userToRegister.Complete();

                return newUser;
            }
        }

        public static UserModel? SignInUser(string username, string password)
        {
            using (GTDbContext context = new())
            {
                GTRepository<UserModel> userToFind = new(context);

                var user = userToFind.FindUser(username);

                if (user?.Username == username && user.Password == password)
                {
                    _SignedInUser = user;
                    return user;
                }

                return null;

            }
        }

        public static void LogOutUser()
        {
            _SignedInUser = null;
        }


    }
}
