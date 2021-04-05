using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;


namespace MarathonSkills
{
    /// <summary>
    /// Interaction logic for RunnerRegistrationConfirmationPage.xaml
    /// </summary>
    public partial class RunnerRegistrationConfirmationPage : Page
    {
        public RunnerRegistrationConfirmationPage()
        {
            InitializeComponent();
        }

        private void OKButton_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new RunnerPage());
        }
    }
}
