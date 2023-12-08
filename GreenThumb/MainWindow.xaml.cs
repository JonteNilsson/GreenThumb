using GreenThumb.Managers;
using System.Windows;

namespace GreenThumb
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        public MainWindow()
        {
            InitializeComponent();


        }

        // Logga in användare
        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            // Läs textboxar
            string username = txtUsername.Text;
            string password = txtPassword.Password;

            // Skicka username och password för login till metod i UserManager
            var successFullLogin = UserManager.SignInUser(username, password);

            // Nullcheck
            if (successFullLogin != null)
            {
                // Messagebox för att verkligen se man blir inloggad
                MessageBox.Show("Login success");
                // Öppna homepage
                HomeWindow newWindow = new();
                newWindow.Show();
                Close();
            }
            else
            {
                // Login failed, tömmer textboxar och sätter focus på username
                MessageBox.Show("Login failed");
                txtUsername.Text = "";
                txtPassword.Password = "";
                txtUsername.Focus();
            }


        }

        // Öppna register window
        private void btnRegister_Click(object sender, RoutedEventArgs e)
        {
            RegisterWindow newWindow = new();
            newWindow.Show();
            Close();
        }
    }
}
