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
	/// Логика взаимодействия для RunnerPage.xaml
	/// </summary>
	public partial class RunnerPage : Page
	{
		public RunnerPage()
		{
			InitializeComponent();
		}

		private void ContactsButton_Click(object sender, RoutedEventArgs e)
		{
			MessageBox.Show("Для получения дополнительной информации пожалуйста свяжитесь с координаторами \n Телефон +55 11 9988 7766 \n Email: coordinators@marathonskills.org", "Контакты");
		}

        private void MarathonRegistrationButton_Click(object sender, RoutedEventArgs e)
        {
			NavigationService.Navigate(new MarathonRegistration());
        }

        private void EditProfileButton_Click(object sender, RoutedEventArgs e)
        {
			NavigationService.Navigate(new EditRunnerProfilePage());
		}

        private void MyResultsButton_Click(object sender, RoutedEventArgs e)
        {
			NavigationService.Navigate(new MyRaceResultsPage());
		}
    }
}
