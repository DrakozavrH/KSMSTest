using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
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
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class StartWindow : Window
    {
        public static string CountdownTime { get; set; }

        
        public StartWindow()
        {
            InitializeComponent();
           
        }


        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            Countown.Start(MarathonTimer);
        }

        private void SponsorRunnerButton_Click(object sender, RoutedEventArgs e)
        {
            DisplayNewPage(new SponsorRunnerPage());

        }

        private void MoreInformationButton_Click(object sender, RoutedEventArgs e)
        {
            DisplayNewPage(new DetailedInformationPage());
        }


        private void LoginButton_Click(object sender, RoutedEventArgs e)
        {
            DisplayNewPage(new LoginPage());
        }

        private void DisplayNewPage(Page page) {

            
            var MainWindow = new MainWindow(page);
            MainWindow.Show();
            this.Close();

        }

		private void BecomeRunnerButton_Click(object sender, RoutedEventArgs e)
		{
			DisplayNewPage(new ExistingRunnersCheckPage());
		}
	}
}
