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
    /// Логика взаимодействия для BMICalculatorPage.xaml
    /// </summary>
    public partial class BMICalculatorPage : Page
    {
        public BMICalculatorPage()
        {
            InitializeComponent();
        }

        private void Icon_MouseDown(object sender, MouseButtonEventArgs e)
        {
            Image icon = sender as Image;

            switch (icon.Name) {

                case "MaleIcon":
                    MaleIcon.Opacity = 1;
                    FemaleIcon.Opacity = 0.5;
                    break;

                case "FemaleIcon":
                    MaleIcon.Opacity = 0.5;
                    FemaleIcon.Opacity = 1;
                    break;

            }

        }
    }
}
