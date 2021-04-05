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
using MarathonSkills.Helpers;
using MarathonSkills;

namespace MarathonSkills
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow(Page page)
        {
            InitializeComponent();

            MainFrame.Content = page;

            

                      
            

        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            Countown.Start(MarathonTimer);
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.GoBack();
        }
    }
}
