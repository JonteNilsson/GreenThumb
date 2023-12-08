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

        // Return till mainwindow om man ändrade sig
        private void btnReturn_Click(object sender, RoutedEventArgs e)
        {
            MainWindow newWindow = new();
            newWindow.Show();
            Close();
        }


        // Registrering
        private void btnRegister_Click(object sender, RoutedEventArgs e)
        {

            // läs textboxar
            string username = txtSelectUsername.Text;
            string password = txtSelectPassword.Password;

            using (GTDbContext context = new())
            {
                GTRepository<UserModel> newUser = new(context);

                // Skicka username för att kolla om det redan finns ( krashar annars ), returnerar en bool
                bool isValid = newUser.FindUsername(username);
                // Om det finns
                if (isValid)
                {
                    MessageBox.Show("Username is taken", "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
                    txtSelectUsername.Text = "";
                    txtSelectPassword.Password = "";
                }
                //Om det inte finns
                else
                {
                    // Skicka username och password för registrering
                    UserManager.RegisterUser(username, password);
                    // Öppna nytt mainwindow för login
                    MainWindow newWindow = new();
                    newWindow.Show();
                    Close();

                }

            }

        }
    }
}
