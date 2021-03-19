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
using System.Windows.Shapes;

namespace MarathonSkills
{
	/// <summary>
	/// Логика взаимодействия для TestingLoginWindow.xaml
	/// </summary>
	public partial class TestingLoginWindow : Window
	{
		public TestingLoginWindow()
		{
			InitializeComponent();
		}

		private void LoginAsRunnerButton_Click(object sender, RoutedEventArgs e)
		{
			MainWindow window = new MainWindow(new RunnerPage());
			window.Show();
			this.Close();

		}

		private void LoginAsCoordinatorButton_Click(object sender, RoutedEventArgs e)
		{
			MainWindow window = new MainWindow(new CoordinatorPage());
			window.Show();
			this.Close();
		}

		private void LoginAsAdministratorButton_Click(object sender, RoutedEventArgs e)
		{
			MainWindow window = new MainWindow(new AdministratorPage());
			window.Show();
			this.Close();
		}
	}
}
