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

        }

        private void btnRegister_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
