using GreenThumb.Database;
using GreenThumb.Managers;
using GreenThumb.Models;
using GreenThumb.Repositories;
using System.Windows;

namespace GreenThumb
{
    /// <summary>
    /// Interaction logic for RegisterWindow.xaml
    /// </summary>
    public partial class RegisterWindow : Window
    {
        public RegisterWindow()
        {
            InitializeComponent();
        }

        private void btnReturn_Click(object sender, RoutedEventArgs e)
        {
            MainWindow newWindow = new();
            newWindow.Show();
            Close();
        }

        private void btnRegister_Click(object sender, RoutedEventArgs e)
        {
            string username = txtSelectUsername.Text;
            string password = txtSelectPassword.Password;

            using (GTDbContext context = new())
            {
                GTRepository<UserModel> newUser = new(context);


                UserManager.RegisterUser(username, password);
            }

            MainWindow newWindow = new();
            newWindow.Show();
            Close();
        }
    }
}
