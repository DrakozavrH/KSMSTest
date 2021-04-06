using Microsoft.Win32;
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
    /// Interaction logic for AddEditCharityPage.xaml
    /// </summary>
    public partial class AddEditCharityPage : Page
    {
        public AddEditCharityPage()
        {
            InitializeComponent();
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }

        private void SelectImageButton_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog fileDialog = new OpenFileDialog();
            fileDialog.Filter = "Image files (*.png) | *.png; *.jpg";


            if (fileDialog.ShowDialog() == true) {

                ImagePathTextBox.Text = fileDialog.FileName;
                CharityLogoImage.Source = new BitmapImage(new Uri(fileDialog.FileName, UriKind.Absolute));
                
                        
            }

        }
    }
}
