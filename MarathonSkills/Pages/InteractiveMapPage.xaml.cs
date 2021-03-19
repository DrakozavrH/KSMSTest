using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace MarathonSkills
{
    /// <summary>
    /// Interaction logic for InteractiveMapPage.xaml
    /// </summary>
    public partial class InteractiveMapPage : Page
    {
        public InteractiveMapPage()
        {
            InitializeComponent();
        }


        private void UpdateInfo(string checkpointName, string landmark, double drinks, double energyBars, double toilets, double information, double medical) {
            InfoWindow.Visibility = Visibility.Visible;
            CheckpointTextBlock.Text = checkpointName;
            LandmarkNameTextBlock.Text = landmark;

            ServiceDrinks.Opacity = drinks;
            ServiceEnergyBars.Opacity = energyBars;
            ServiceToilets.Opacity = toilets;
            ServiceInformation.Opacity = information;
            ServiceMedical.Opacity = medical;

            ServicesProvidedTextBlock.Visibility = Visibility.Visible;

        }

        private void Checkpoint1Button_Click(object sender, RoutedEventArgs e)
        {
            UpdateInfo("Checkpoint 1", "Avenida Rudge", 1, 1, 0.3, 0.3, 0.3);
        }

        private void Checkpoint2Button_Click(object sender, RoutedEventArgs e)
        {
            UpdateInfo("Checkpoint 2", "Theatro Municipal", 1, 1, 1, 1, 1);
        }

        private void Checkpoint3Button_Click(object sender, RoutedEventArgs e)
        {
            UpdateInfo("Checkpoint 3", "Parque do Ibirapuera", 1, 1, 1, 0.3, 0.3);
        }

        private void Checkpoint4Button_Click(object sender, RoutedEventArgs e)
        {
            UpdateInfo("Checkpoint 4", "Jardim Luzitania", 1, 1, 1, 0.3, 1);
        }

        private void Checkpoint5Button_Click(object sender, RoutedEventArgs e)
        {
            UpdateInfo("Checkpoint 5", "Iguatemi", 1, 1, 1, 1, 0.3);
        }

        private void Checkpoint6Button_Click(object sender, RoutedEventArgs e)
        {
            UpdateInfo("Checkpoint 6", "Rua Lisboa", 1, 1, 1, 0.3, 0.3);
        }

        private void Checkpoint7Button_Click(object sender, RoutedEventArgs e)
        {
            UpdateInfo("Checkpoint 7", "Cemitério da Consolação", 1, 1, 1, 1, 1);
        }

        private void Checkpoint8Button_Click(object sender, RoutedEventArgs e)
        {
            UpdateInfo("Checkpoint 8", "Cemitério da Consolação", 1, 1, 1, 1, 1);
        }

        private void FullMarathonStartButton_Click(object sender, RoutedEventArgs e)
        {
            UpdateInfo("Race start", "Full Marathon start", 0, 0, 0, 0, 0);
            ServicesProvidedTextBlock.Visibility = Visibility.Hidden;
        }

        private void HalfMarathonStartButton_Click(object sender, RoutedEventArgs e)
        {
            UpdateInfo("Race start", "Half Marathon start", 0, 0, 0, 0, 0);
            ServicesProvidedTextBlock.Visibility = Visibility.Hidden;
        }

        private void FunMarathonStartButton_Click(object sender, RoutedEventArgs e)
        {
            UpdateInfo("Race start", "Fun Run start", 0, 0, 0, 0, 0);
            ServicesProvidedTextBlock.Visibility = Visibility.Hidden;
        }
    }
}
