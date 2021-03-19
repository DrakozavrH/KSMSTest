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
	/// Логика взаимодействия для AdministratorPage.xaml
	/// </summary>
	public partial class AdministratorPage : Page
	{
		public AdministratorPage()
		{
			InitializeComponent();
		}

        private void InventoryButton_Click(object sender, RoutedEventArgs e)
        {
			NavigationService.Navigate(new InventoryPage());
        }

        private void CharitiesButton_Click(object sender, RoutedEventArgs e)
        {
			NavigationService.Navigate(new ManageCharitiesPage());
		}

        private void VolunteerButton_Click(object sender, RoutedEventArgs e)
        {
			NavigationService.Navigate(new VolunteerManagementPage());
		}
    }
}
