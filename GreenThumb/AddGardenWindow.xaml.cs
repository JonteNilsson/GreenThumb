using GreenThumb.Database;
using GreenThumb.Managers;
using GreenThumb.Models;
using GreenThumb.Repositories;
using System.Windows;

namespace GreenThumb
{
    /// <summary>
    /// Interaction logic for AddGardenWindow.xaml
    /// </summary>
    public partial class AddGardenWindow : Window
    {
        UserModel? currentUser = UserManager._SignedInUser;
        public AddGardenWindow()
        {
            InitializeComponent();

            lblLoggedInUser.Content = currentUser?.Username;
        }

        private void btnAddGarden_Click(object sender, RoutedEventArgs e)
        {
            string gardenName = txtGardenName.Text;

            if (txtGardenName.Text != "")
            {
                using (GTDbContext context = new())
                {
                    GTRepository<GardenModel> gardenRepository = new(context);

                    GardenModel newGarden = new()
                    {
                        Name = gardenName,
                        UserId = currentUser!.Id

                    };

                    gardenRepository.Add(newGarden);
                    gardenRepository.Complete();

                    MessageBox.Show("Garden created");

                    HomeWindow newWindow = new();
                    newWindow.Show();
                    Close();


                }
            }
            else
            {
                MessageBox.Show("Fill in name", "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
                txtGardenName.Focus();
            }
        }

        private void btnReturnToHome_Click(object sender, RoutedEventArgs e)
        {
            HomeWindow newWindow = new();
            newWindow.Show();
            Close();

        }
    }
}
