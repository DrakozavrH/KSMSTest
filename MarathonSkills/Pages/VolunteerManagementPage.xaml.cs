using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;

namespace MarathonSkills
{
    /// <summary>
    /// Interaction logic for VolunteerManagementPage.xaml
    /// </summary>
    public partial class VolunteerManagementPage : Page
    {
        public VolunteerManagementPage()
        {
            InitializeComponent();
        }

        private void ImportVolunteersButton_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new ImportVolunteersPage());
        }
    }
}
