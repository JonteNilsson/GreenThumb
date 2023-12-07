using GreenThumb.Database;
using GreenThumb.Models;
using GreenThumb.Repositories;
using System.Windows;
using System.Windows.Controls;

namespace GreenThumb
{
    /// <summary>
    /// Interaction logic for AddPlantWindow.xaml
    /// </summary>
    public partial class AddPlantWindow : Window
    {
        public AddPlantWindow()
        {
            InitializeComponent();
        }

        // Lägger till planta, inget konstigt
        private void btnAddPlant_Click(object sender, RoutedEventArgs e)
        {
            string plantName = txtPlantName.Text;

            if (txtPlantName.Text != "")
            {
                List<InstructionModel> instructions = new();

                foreach (var newInstruction in lstInstructions.Items)
                {
                    ListViewItem item = (ListViewItem)newInstruction;
                    InstructionModel newModel = (InstructionModel)item.Tag;

                    instructions.Add(newModel);
                }


                using (GTDbContext context = new())
                {

                    GTRepository<PlantModel> newPlant = new(context);

                    // Skickar plantnamn för att se om det redan finns i listan, returnerar en bool
                    if (newPlant.ValidatePlantName(plantName) == true)
                    {
                        MessageBox.Show("Plant already exists", "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
                        txtPlantInstruction.Text = "";
                        txtPlantName.Text = "";
                        txtPlantName.Focus();
                        lstInstructions.Items.Clear();
                    }
                    else
                    {
                        PlantModel plant = new(plantName, instructions);


                        newPlant.Add(plant);
                        newPlant.Complete();

                        HomeWindow newWindow = new();
                        newWindow.Show();
                        Close();

                    }
                }

            }
            else
            {
                MessageBox.Show("Name is empty!", "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
            }



        }

        // Lägger till instrucktion till planta, inget konstigt.
        private void btnAddInstruction_Click(object sender, RoutedEventArgs e)
        {

            string instruction = txtPlantInstruction.Text;
            if (txtPlantInstruction.Text != "")
            {
                InstructionModel newInstruction = new(instruction);

                ListViewItem item = new();
                item.Tag = newInstruction;
                item.Content = newInstruction.Instruction;

                lstInstructions.Items.Add(item);

                txtPlantInstruction.Text = "";

            }
            else
            {
                MessageBox.Show("Field is empty!", "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        // Öppnar ny homepage
        private void btnReturnToHome_Click(object sender, RoutedEventArgs e)
        {
            HomeWindow newWindow = new();
            newWindow.Show();
            Close();
        }
    }
}
