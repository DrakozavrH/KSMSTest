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
    /// Interaction logic for AboutMarathonSkillsPage.xaml
    /// </summary>
    public partial class AboutMarathonSkillsPage : Page
    {
        public AboutMarathonSkillsPage()
        {
            InitializeComponent();
        }

        private void MarathonMap_MouseDown(object sender, MouseButtonEventArgs e)
        {
            NavigationService.Navigate(new InteractiveMapPage());
        }
    }
}
