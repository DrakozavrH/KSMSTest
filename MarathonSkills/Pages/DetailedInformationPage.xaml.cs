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
    /// Interaction logic for DetailedInformationPage.xaml
    /// </summary>
    public partial class DetailedInformationPage : Page
    {
        public DetailedInformationPage()
        {
            InitializeComponent();
        }

        private void CharityListButton_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new CharityListPage());
        }

        

        private void HowLongMarathonButton_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new HowLongMarathonPage());
        }

        private void AboutMarathon_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new AboutMarathonSkillsPage());
        }
    }
}
