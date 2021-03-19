
using System.Windows.Controls;


namespace MarathonSkills
{
	/// <summary>
	/// Логика взаимодействия для ExistingRunnersCheckPage.xaml
	/// </summary>
	public partial class ExistingRunnersCheckPage : Page
	{
		public ExistingRunnersCheckPage()
		{
			InitializeComponent();
		}

		private void RegisterButton_Click(object sender, System.Windows.RoutedEventArgs e)
		{
			NavigationService.Navigate(new RegisterRunnerPage());
		}
	}
}
