using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace MarathonSkills
{
    /// <summary>
    /// Interaction logic for HowLongMarathonPage.xaml
    /// </summary>
    public partial class HowLongMarathonPage : Page
    {
        public HowLongMarathonPage()
        {
            InitializeComponent();
            
        }

        private void SpeedOption_MouseDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            Image image = sender as Image;
            DisplayImage.Source = image.Source;
            DisplayTextBox.Text = image.Tag.ToString().Split(',')[0];

            

            double hours = 42 / Double.Parse(image.Tag.ToString().Split(',')[1],System.Globalization.CultureInfo.InvariantCulture);

            TimeSpan TimeToComplete = new TimeSpan((int)hours, (int)(hours * 60) - 60 * (int)hours, 0);
            //DateTime test = new DateTime(0,0,0, (int)hours, (int)hours* 60 - 60 * (int)hours,0);           
            //DateTime TimeToComplete = new DateTime( 42/ Int32.Parse(image.Tag.ToString().Split(',')[1]));

            if(TimeToComplete.Days > 0)
            {
                InfoTextBlock.Text = String.Format("{0} перемещается со скоростью {1} км/ч. Это займет {2} дней , чтобы завершить 42km марафон",
                DisplayTextBox.Text,
                image.Tag.ToString().Split(',')[1],
                TimeToComplete.Days
                );

            }
            else
            {
                InfoTextBlock.Text = String.Format("{0} перемещается со скоростью {1} км/ч. Это займет {2} часов {3} минут, чтобы завершить 42km марафон",
                DisplayTextBox.Text,
                image.Tag.ToString().Split(',')[1],
                TimeToComplete.Hours,
                TimeToComplete.Minutes);

            }

           


        }

        private void DistanceOption_MouseDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            Image image = sender as Image;
            DisplayImage.Source = image.Source;
            DisplayTextBox.Text = image.Tag.ToString().Split(',')[0];

            

            int AmountToCover =(int)((double)(42000 / Double.Parse(image.Tag.ToString().Split(',')[1],System.Globalization.CultureInfo.InvariantCulture)));

            InfoTextBlock.Text = String.Format("Длина {0} - {1}m. Это займет {2} из них, чтобы покрыть расстояние в 42 км марафона",
                DisplayTextBox.Text,
                image.Tag.ToString().Split(',')[1],
                AmountToCover
                );
        }
    }
}
