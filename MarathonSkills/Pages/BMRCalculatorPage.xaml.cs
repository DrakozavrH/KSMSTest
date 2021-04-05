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
using MarathonSkills.Helpers;

namespace MarathonSkills
{
    /// <summary>
    /// Interaction logic for BMRCalculatorPage.xaml
    /// </summary>
    public partial class BMRCalculatorPage : Page
    {



        public BMRCalculatorPage()
        {
            InitializeComponent();
        }


        

        private void Icon_Click(object sender, RoutedEventArgs e)
        {
            Button icon = sender as Button;

            switch (icon.Name)
            {

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
            TextBoxInput.RestrictToNumbers(sender, e);
        }

        private void CalculateButton_Click(object sender, RoutedEventArgs e)
        {
            double BMR;

            try
            {

                BMR = MaleIcon.Opacity == 1 ?
                66 + (13.7 * Convert.ToDouble(WeightTextBox.Text)) + (5 * Convert.ToDouble(HeightTextBox.Text) - (6.8 * Convert.ToDouble(AgeTextBox.Text))) :
                655 + (9.6 * Convert.ToDouble(WeightTextBox.Text)) + (1.8 * Convert.ToDouble(HeightTextBox.Text) - (4.7 * Convert.ToDouble(AgeTextBox.Text))); ;

            }
            catch (FormatException)
            {
                MessageBox.Show("Не все значения введены", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            


            BMRTextBlock.Text = $"{ BMR:0.}";

            SittingActivityTextBlock.Text = $"Сидячий образ: {BMR * 1.2:0.}";
            LowActivityTextBlock.Text = $"Маленькая активность: {BMR * 1.375:0.}";
            MediumActivityTextBlock.Text = $"Средняя активность: {BMR * 1.55:0.}";
            HighActivityTextBlock.Text =$"Высокая активность: {BMR * 1.725:0.}";
            MaxActivityTextBlock.Text = $"Максимальная активность {BMR * 1.9:0.}";


        }

        private void InfoButton_Click(object sender, RoutedEventArgs e)
        {

            BMRInfoWindow window = new BMRInfoWindow();
            window.ShowDialog();

        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            BMRTextBlock.Text = "0";

            SittingActivityTextBlock.Text = $"Сидячий образ: 0";
            LowActivityTextBlock.Text = $"Маленькая активность: 0";
            MediumActivityTextBlock.Text = $"Средняя активность: 0";
            HighActivityTextBlock.Text = $"Высокая активность: 0";
            MaxActivityTextBlock.Text = $"Максимальная активность 0";

            HeightTextBox.Clear();
            WeightTextBox.Clear();
            AgeTextBox.Clear();

        }
    }
}
