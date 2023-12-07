using GreenThumb.Database;
using GreenThumb.Managers;
using GreenThumb.Models;
using GreenThumb.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking.Internal;
using System.Windows;
using System.Windows.Controls;

namespace GreenThumb
{
    /// <summary>
    /// Interaction logic for HomeWindow.xaml
    /// </summary>
    public partial class HomeWindow : Window
    {
        UserModel? currentUser = UserManager._SignedInUser;
        private List<PlantModel> _allPlants = new();
        private List<PlantModel> _filteredPlants = new();
        public HomeWindow()
        {
            InitializeComponent();
            lblSignedInUser.Content = currentUser?.Username;

            FillListWithPlants();
            LoadMyGarden();

        }

        private void LoadMyGarden()
        {
            using (GTDbContext context = new())
            {
                lstMyGarden.Items.Clear();
                GTRepository<GardenModel> gardenPlants = new(context);

                // Hämta current user garden
                GardenModel? garden = context.Gardens.Where(u => u.UserId == currentUser!.Id).Include(p => p.Plants).FirstOrDefault();

                // Kolla om user har en garden
                if (garden != null)
                {
                    // Sätt textbox my garden till users garden name
                    txtMyGardenName.Text = garden.Name;

                    btnCreateGarden.Visibility = Visibility.Hidden;
                    lblGardenEmpty.Visibility = Visibility.Hidden;
                    lblCreateOne.Visibility = Visibility.Hidden;
                    // Hämta alla planter i den gardenen
                    var plants = garden.Plants.ToList();

                    if (plants != null)
                    {
                        foreach (var plant in plants)
                        {
                            ListViewItem item = new();
                            item.Tag = plant;
                            item.Content = plant.Name;

                            lstMyGarden.Items.Add(item);
                        }
                    }
                    else
                    {
                        ListViewItem listIsEmpty = new();
                        listIsEmpty.Content = $"{currentUser!.Username} has no plants in garden";
                    }

                }
                else
                {
                    lblCreateOne.Visibility = Visibility.Visible;
                    lblGardenEmpty.Visibility = Visibility.Visible;
                    btnCreateGarden.Visibility = Visibility.Visible;
                    txtMyGardenName.Text = $"{currentUser!.Username} has no garden!";
                }




            }
        }

        private void FillListWithPlants()
        {

            lstAllPlants.Items.Clear();
            using (GTDbContext context = new())
            {
                GTRepository<PlantModel> allPlants = new(context);

                var everyPlant = allPlants.GetAll();

                foreach (var plant in everyPlant)
                {
                    ListViewItem item = new();
                    item.Tag = plant;
                    item.Content = plant.Name;
                    lstAllPlants.Items.Add(item);
                }


            }
        }

        private void txtSearchPlant_TextChanged(object sender, TextChangedEventArgs e)
        {
            string searchPlant = txtSearchPlant.Text;


            _filteredPlants = _allPlants.Where(p => p.Name.Contains(searchPlant)).ToList();
            lstAllPlants.Items.Clear();

            using (GTDbContext context = new())
            {
                GTRepository<PlantModel> allPlants = new(context);

                _allPlants = allPlants.GetAll();
                _filteredPlants = _allPlants.Where(p => p.Name.StartsWith(searchPlant, StringComparison.OrdinalIgnoreCase)).ToList();

                //_filteredPlants = _allPlants;

                foreach (var plant in _filteredPlants)
                {
                    ListViewItem item = new();
                    item.Tag = plant;
                    item.Content = plant.Name;

                    lstAllPlants.Items.Add(item);
                }

            }


        }

        private void btnAddPlantToGarden_Click(object sender, RoutedEventArgs e)
        {
            ListViewItem selectedItem = (ListViewItem)lstAllPlants.SelectedItem;

            lstMyGarden.Items.Clear();

            if (selectedItem != null)
            {
                using (GTDbContext context = new())
                {

                    PlantModel plantToAdd = (PlantModel)selectedItem.Tag;

                    GardenModel? garden = context.Gardens.Where(u => u.UserId == currentUser!.Id).FirstOrDefault();

                    if (plantToAdd != null)
                    {
                        ListViewItem item = new();
                        item.Tag = plantToAdd;
                        item.Content = plantToAdd.Name;
                        lstMyGarden.Items.Add(item);

                        if (garden != null)
                        {
                            garden.Plants.Add(plantToAdd);
                            context.SaveChanges();
                            LoadMyGarden();
                        }
                        else
                        {
                            MessageBox.Show($"{currentUser!.Username} has no garden, create one", "Warning");
                        }
                    }
                }

            }
            else
            {
                MessageBox.Show("Select a plant", "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        private void btnCreateGarden_Click(object sender, RoutedEventArgs e)
        {
            AddGardenWindow newWindow = new();
            newWindow.Show();
            Close();
        }

        private void btnAddPlant_Click(object sender, RoutedEventArgs e)
        {
            AddPlantWindow newWindow = new();
            newWindow.Show();
            Close();
        }

        private void btnDeletePlant_Click(object sender, RoutedEventArgs e)
        {
            ListViewItem selectedItem = (ListViewItem)lstAllPlants.SelectedItem;

            if (selectedItem != null)
            {
                PlantModel plantToDelete = (PlantModel)selectedItem.Tag;

                using (GTDbContext context = new())
                {
                    GTRepository<PlantModel> plantToRemove = new(context);

                    int id = plantToDelete.Id;

                    plantToRemove.Delete(id);
                    plantToRemove.Complete();

                }
                FillListWithPlants();
            }
            else
            {
                MessageBox.Show("Select a plant", "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        private void btnDetailsPlant_Click(object sender, RoutedEventArgs e)
        {
            ListViewItem selectedItem = (ListViewItem)lstAllPlants.SelectedItem;
            if (selectedItem != null)
            {
                PlantModel plantToSend = (PlantModel)selectedItem.Tag;

                DetailsWindow newWindow = new(plantToSend);
                newWindow.Show();
                Close();

            }
        }

        private void btnLogOut_Click(object sender, RoutedEventArgs e)
        {
            UserManager.LogOutUser();

            MainWindow newWindow = new();
            newWindow.Show();
            Close();
        }

        private void btnDeleteGarden_Click(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("Are you sure?", "Warning", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                using (GTDbContext context = new())
                {
                    GTRepository<GardenModel> gardenRepository = new(context);

                    GardenModel? garden = context.Gardens.Where(u => u.UserId == currentUser!.Id).FirstOrDefault();

                    if (garden != null)
                    {
                        int gardenId = garden.Id;
                        gardenRepository.Delete(gardenId);
                        gardenRepository.Complete();

                        LoadMyGarden();
                    }
                }
            }




        }

        // TODO: Ge user möjlighet att ta bort plantor från sin garden

        private void btnDeletePlantFromGarden_Click(object sender, RoutedEventArgs e)
        {
            ListViewItem selectedItem = (ListViewItem)lstMyGarden.SelectedItem;

            if (selectedItem != null)
            {
                using (GTDbContext context = new())
                {

                    PlantModel plantToDeleteFromGarden = (PlantModel)selectedItem.Tag;

                    var garden = context.Gardens.Where(u => u.UserId == currentUser!.Id).Include(p => p.Plants).FirstOrDefault();


                    if (garden != null)
                    {

                        garden.Plants.Remove(plantToDeleteFromGarden);
                        context.SaveChanges();

                    }

                }

            }
            else
            {
                MessageBox.Show("Select a plant", "Warning!", MessageBoxButton.OK, MessageBoxImage.Warning);
            }

        }
    }
}
