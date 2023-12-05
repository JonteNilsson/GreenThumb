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


            //using (GTDbContext context = new())
            //{

            //    GTRepository<InstructionModel> instruction = new(context);

            //    GTRepository<PlantModel> plant = new(context);

            //};

        }

        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            string username = txtUsername.Text;
            string password = txtPassword.Password;

            var successFullLogin = UserManager.SignInUser(username, password);

            if (successFullLogin != null)
            {
                MessageBox.Show("Login success");
            }
            else
            {
                MessageBox.Show("Login failed");
            }


        }

        private void btnRegister_Click(object sender, RoutedEventArgs e)
        {
            RegisterWindow newWindow = new();
            newWindow.Show();
            Close();
        }
    }
}
