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
    /// Interaction logic for ManageCharitiesPage.xaml
    /// </summary>
    public partial class ManageCharitiesPage : Page
    {
        public ManageCharitiesPage()
        {
            InitializeComponent();
        }

        private void AddNewCharityButton_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new AddEditCharityPage());
        }
    }
}
