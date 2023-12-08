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
        // Fältvariabler för att nå lite olika saker :)
        UserModel? currentUser = UserManager._SignedInUser;
        private List<PlantModel> _allPlants = new();
        private List<PlantModel> _filteredPlants = new();
        public HomeWindow()
        {
            InitializeComponent();
            lblSignedInUser.Content = currentUser?.Username;

            // Fyller lista med plantor
            FillListWithPlants();
            // Uppdaterar garden för user
            LoadMyGarden();

        }

        public void LoadMyGarden()
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

                    // Gömmer och visar grejor beroende på om user har garden eller ej.
                    btnCreateGarden.Visibility = Visibility.Hidden;
                    lblGardenEmpty.Visibility = Visibility.Hidden;
                    lblCreateOne.Visibility = Visibility.Hidden;
                    btnAddPlantToGarden.Visibility = Visibility.Visible;
                    lblAddPlantToGarden.Visibility = Visibility.Visible;
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
                        // Om user inte har en garden
                        ListViewItem listIsEmpty = new();
                        listIsEmpty.Content = $"{currentUser!.Username} has no plants in garden";
                        lstMyGarden.Items.Add(listIsEmpty);
                    }

                }
                else
                {
                    // Gömmer och visar grejor beroende på om user har garden eller ej.
                    lblCreateOne.Visibility = Visibility.Visible;
                    lblGardenEmpty.Visibility = Visibility.Visible;
                    btnCreateGarden.Visibility = Visibility.Visible;
                    btnAddPlantToGarden.Visibility = Visibility.Hidden;
                    lblAddPlantToGarden.Visibility = Visibility.Hidden;
                    txtMyGardenName.Text = $"{currentUser!.Username} has no garden!";
                }




            }
        }

        // Lik Loadmygarden fast mer generell
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

        // Dynamisk sökningar av plantor
        private void txtSearchPlant_TextChanged(object sender, TextChangedEventArgs e)
        {
            string searchPlant = txtSearchPlant.Text;


            _filteredPlants = _allPlants.Where(p => p.Name.Contains(searchPlant)).ToList();
            lstAllPlants.Items.Clear();

            using (GTDbContext context = new())
            {
                GTRepository<PlantModel> allPlants = new(context);

                _allPlants = allPlants.GetAll();
                // Filterar bokstav för bokstav man matar in och uppdaterar listan efter det.
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
                    GTRepository<PlantModel> plantsRepository = new(context);

                    PlantModel plantToAdd = (PlantModel)selectedItem.Tag;
                    // Hämta usergarden
                    GardenModel? garden = context.Gardens.Where(u => u.UserId == currentUser!.Id).Include(p => p.Plants).FirstOrDefault();

                    // Kolla om plantan redan finns i garden

                    var allGardenPlants = garden?.Plants.ToList();
                    // Kolla om plantan finns i garden, skicka till metod, returnerar bool
                    bool plantDontExist = plantsRepository.CheckGardenForPlant(allGardenPlants!, plantToAdd.Name);

                    if (plantDontExist == true)
                    {
                        // Om true lägg till planta till garden
                        ListViewItem item = new();
                        item.Tag = plantToAdd;
                        item.Content = plantToAdd.Name;
                        lstMyGarden.Items.Add(item);

                        garden!.Plants.Add(plantToAdd);
                        context.SaveChanges();
                        LoadMyGarden();
                    }
                    else
                    {
                        // Planta finns, ladda om listan och ge meddelande.
                        LoadMyGarden();
                        MessageBox.Show("Plant already exist in garden!", "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
                    }



                }
            }
            else
            {
                // Ingen planta har valts i listview
                LoadMyGarden();
                MessageBox.Show("Select a plant", "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        // Öppna nytt fönster för Garden create
        private void btnCreateGarden_Click(object sender, RoutedEventArgs e)
        {
            AddGardenWindow newWindow = new();
            newWindow.Show();
            Close();
        }

        // Öppna nytt fönster för addplant
        private void btnAddPlant_Click(object sender, RoutedEventArgs e)
        {
            AddPlantWindow newWindow = new();
            newWindow.Show();
            Close();
        }

        // Ta bort planta
        private void btnDeletePlant_Click(object sender, RoutedEventArgs e)
        {
            // Kolla selectade item
            ListViewItem selectedItem = (ListViewItem)lstAllPlants.SelectedItem;
            // nullchecka
            if (selectedItem != null)
            {
                // packa upp
                PlantModel plantToDelete = (PlantModel)selectedItem.Tag;

                using (GTDbContext context = new())
                {
                    GTRepository<PlantModel> plantToRemove = new(context);

                    int id = plantToDelete.Id;
                    // Delete via ID
                    plantToRemove.Delete(id);
                    plantToRemove.Complete();

                }
                // Ladda om lista
                FillListWithPlants();
            }
            else
            {
                // Om inget selectat, visa varning
                MessageBox.Show("Select a plant", "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        private void btnDetailsPlant_Click(object sender, RoutedEventArgs e)
        {
            // Läs selectat item från lista
            ListViewItem selectedItem = (ListViewItem)lstAllPlants.SelectedItem;
            // nullcheck
            if (selectedItem != null)
            {
                // Packa upp och skicka till details window
                PlantModel plantToSend = (PlantModel)selectedItem.Tag;

                DetailsWindow newWindow = new(plantToSend);
                newWindow.Show();
                Close();

            }
        }

        // Logga ut!
        private void btnLogOut_Click(object sender, RoutedEventArgs e)
        {
            UserManager.LogOutUser();

            MainWindow newWindow = new();
            newWindow.Show();
            Close();
        }

        // Deleta garden
        private void btnDeleteGarden_Click(object sender, RoutedEventArgs e)
        {
            // Messsagebow med 2 val, yes/no, om yes, deleta garden, om nej för inget.
            if (MessageBox.Show("Are you sure?", "Warning", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                using (GTDbContext context = new())
                {
                    GTRepository<GardenModel> gardenRepository = new(context);

                    // Hämta user garden
                    GardenModel? garden = context.Gardens.Where(u => u.UserId == currentUser!.Id).FirstOrDefault();

                    if (garden != null)
                    {
                        // Deleta garden
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
                    var garden = context.Gardens.Where(u => u.UserId == currentUser!.Id).Include(p => p.Plants).FirstOrDefault();

                    PlantModel? plantToDelete = garden.Plants.FirstOrDefault(p => p.Id == ((PlantModel)selectedItem.Tag).Id);


                    if (garden != null && plantToDelete != null)
                    {


                        garden.Plants.Remove(plantToDelete);
                        context.SaveChanges();
                        LoadMyGarden();
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
