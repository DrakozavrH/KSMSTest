using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
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

        private void NumericTextBox_PreviewKeyDown(object sender, KeyEventArgs e)
        {

            char character = (char)KeyInterop.VirtualKeyFromKey(e.Key);


            e.Handled = !char.IsDigit(character) && e.Key != Key.Back;

            

        }

        private void CalculateButton_Click(object sender, RoutedEventArgs e)
        {

            double BMI;


            try
            {

                BMI = Convert.ToDouble(WeightTextBox.Text) / Math.Pow(Convert.ToDouble(HeightTextBox.Text) / 100, 2);

            }
            catch (Exception)
            {
                MessageBox.Show("Введены неверные значения", "Ошибка", MessageBoxButton.OK,MessageBoxImage.Error);
                return;
            }

            BMIStatusNumber.Text = BMI.ToString("0.0");

            //BMIStatusArrow.RenderTransform = new TranslateTransform(480 * BMI / 40, 0);
            //
            //BMIStatusArrow.RenderTransform = new TranslateTransform(Math.Min(9.7 * BMI, 480), 0);

            switch (BMI) { 
            
            
                case var _ when BMI < 18.5:
                    BMIStatusIcon.Source = new BitmapImage( new Uri("/Images/BMIIcons/bmi-underweight-icon.png", UriKind.Relative));
                    BMIStatusText.Text = "Недостаточный";
                    BMIStatusArrow.RenderTransform = new TranslateTransform(48, 0);
                    break;
                case var _ when BMI < 24.9:
                    BMIStatusIcon.Source = new BitmapImage(new Uri("/Images/BMIIcons/bmi-healthy-icon.png", UriKind.Relative));
                    BMIStatusText.Text = "Здоровый";
                    BMIStatusArrow.RenderTransform = new TranslateTransform(175, 0);
                    break;
                case var _ when BMI < 29.9:
                    BMIStatusIcon.Source = new BitmapImage(new Uri("/Images/BMIIcons/bmi-overweight-icon.png", UriKind.Relative));
                    BMIStatusText.Text = "Избыточный";
                    BMIStatusArrow.RenderTransform = new TranslateTransform(300, 0);
                    break;
                case var _ when BMI > 30:
                    BMIStatusIcon.Source = new BitmapImage(new Uri("/Images/BMIIcons/bmi-obese-icon.png", UriKind.Relative));
                    BMIStatusText.Text = "Ожирение";
                    BMIStatusArrow.RenderTransform = new TranslateTransform(435, 0);
                    break;


            }


        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            BMIStatusIcon.Source = new BitmapImage(new Uri("/Images/BMIIcons/bmi-underweight-icon.png", UriKind.Relative));
            BMIStatusText.Text = "Недостаточный";
            BMIStatusArrow.RenderTransform = new TranslateTransform(48, 0);
            BMIStatusNumber.Text = "0.0";
            HeightTextBox.Clear();
            WeightTextBox.Clear();
        }
    }
}
