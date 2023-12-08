using GreenThumb.Database;
using GreenThumb.Models;
using GreenThumb.Repositories;
using System.Windows;
using System.Windows.Controls;

namespace GreenThumb
{
    /// <summary>
    /// Interaction logic for DetailsWindow.xaml
    /// </summary>
    public partial class DetailsWindow : Window
    {
        public DetailsWindow(PlantModel plant)
        {
            InitializeComponent();
            // Sätter plantnamnet i textbox
            txtPlantName.Text = plant.Name;

            using (GTDbContext context = new())
            {
                GTRepository<InstructionModel> instructions = new(context);
                // Hämtar instruktioner för ne specifik planta
                List<InstructionModel> instructionsList = instructions.GetAll();
                var plantInstructions = instructionsList.Where(p => p.PlantId == plant.Id).ToList();

                // Plantor kan skapas utan instruktioner
                if (plantInstructions.Count <= 0)
                {
                    lstInstructions.Items.Add("Plant has no instructions");
                }

                // Lägger in instruktioner i listan
                foreach (var instruction in plantInstructions)
                {
                    ListViewItem item = new();
                    item.Tag = instruction;
                    item.Content = instruction.Instruction;

                    lstInstructions.Items.Add(item);
                }

            }

        }

        // öpnnar nytt homewindow
        private void btnReturnToHome_Click(object sender, RoutedEventArgs e)
        {
            HomeWindow newWindow = new();
            newWindow.Show();
            Close();
        }
    }
}
