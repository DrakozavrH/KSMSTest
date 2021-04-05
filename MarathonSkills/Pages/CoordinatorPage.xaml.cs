using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace MarathonSkills
{
	/// <summary>
	/// Логика взаимодействия для CoordinatorPage.xaml
	/// </summary>
	public partial class CoordinatorPage : Page
	{
		public CoordinatorPage()
		{
			InitializeComponent();
		}

        private void RunnersButton_Click(object sender, RoutedEventArgs e)
        {
			NavigationService.Navigate(new RunnerManagementPage());
        }

        private void Sponsorships_Click(object sender, RoutedEventArgs e)
        {
			NavigationService.Navigate(new RunnerManagementPage());
        }
    }
}
