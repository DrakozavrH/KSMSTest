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
    /// Логика взаимодействия для SponsorConfirmation.xaml
    /// </summary>
    public partial class SponsorConfirmation : Page
    {
        public SponsorConfirmation(string RunnerName,string CharityName, string DonationSum)
        {
            InitializeComponent();


			RunnerNameTextBlock.Text = RunnerName;
			CharityNameTextBlock.Text = CharityName;
			DonationSumTextBlock.Text = DonationSum;



        }

		private void BackButton_Click(object sender, RoutedEventArgs e)
		{
			StartWindow window = new StartWindow();
			window.Show();
			Window.GetWindow(this).Close();
		}
	}
}
