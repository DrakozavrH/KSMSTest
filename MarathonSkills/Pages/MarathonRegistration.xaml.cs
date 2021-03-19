using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
    /// Interaction logic for MarathonRegistration.xaml
    /// </summary>
    public partial class MarathonRegistration : Page
    {
        private bool FullMarathonIsChecked;
        private bool HalfMarathonIsChecked;
        private bool SmallMarathonIsChecked;
        private int BundleSelected = 1;


        public MarathonRegistration()
        {
            InitializeComponent();
        }

        private void FullMarathonCheckBox_Checked(object sender, RoutedEventArgs e)
        {
            FullMarathonIsChecked = true;
            RegistrationFeeTextBox.Text = "$" + (Int32.Parse(RegistrationFeeTextBox.Text.Trim('$')) + 145).ToString();
        }

        private void FullMarathonCheckBox_Unchecked(object sender, RoutedEventArgs e)
        {
            FullMarathonIsChecked = false;
            RegistrationFeeTextBox.Text = "$" + (Int32.Parse(RegistrationFeeTextBox.Text.Trim('$')) - 145).ToString();
        }

        private void HalfMarathonCheckBox_Checked(object sender, RoutedEventArgs e)
        {
            HalfMarathonIsChecked = true;
            RegistrationFeeTextBox.Text = "$" + (Int32.Parse(RegistrationFeeTextBox.Text.Trim('$')) + 70).ToString();
        }

        private void HalfMarathonCheckBox_Unchecked(object sender, RoutedEventArgs e)
        {
            HalfMarathonIsChecked = false;
            RegistrationFeeTextBox.Text = "$" + (Int32.Parse(RegistrationFeeTextBox.Text.Trim('$')) - 70).ToString();
        }

        private void SmallMarathonCheckBox_Checked(object sender, RoutedEventArgs e)
        {
            SmallMarathonIsChecked = true;
            RegistrationFeeTextBox.Text = "$" + (Int32.Parse(RegistrationFeeTextBox.Text.Trim('$')) + 20).ToString();
        }

        private void SmallMarathonCheckBox_Unchecked(object sender, RoutedEventArgs e)
        {
            SmallMarathonIsChecked = false;
            RegistrationFeeTextBox.Text = "$" + (Int32.Parse(RegistrationFeeTextBox.Text.Trim('$')) - 20).ToString();
        }

        private void BundleOption1RadioButton_Checked(object sender, RoutedEventArgs e)
        {
            BundleSelected = 1;
        }

       

        private void BundleOption2RadioButton_Checked(object sender, RoutedEventArgs e)
        {
            BundleSelected = 2;
            RegistrationFeeTextBox.Text = "$" + (Int32.Parse(RegistrationFeeTextBox.Text.Trim('$')) + 20).ToString();
        }

        private void BundleOption2RadioButton_Unchecked(object sender, RoutedEventArgs e)
        {
            RegistrationFeeTextBox.Text = "$" + (Int32.Parse(RegistrationFeeTextBox.Text.Trim('$')) - 20).ToString();
        }

        private void BundleOption3RadioButton_Checked(object sender, RoutedEventArgs e)
        {
            BundleSelected = 3;
            RegistrationFeeTextBox.Text = "$" + (Int32.Parse(RegistrationFeeTextBox.Text.Trim('$')) + 45).ToString();
        }

        private void BundleOption3RadioButton_Unchecked(object sender, RoutedEventArgs e)
        {
            RegistrationFeeTextBox.Text = "$" + (Int32.Parse(RegistrationFeeTextBox.Text.Trim('$')) - 45).ToString();
        }

        private void CharityDonationTextBox_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            Regex regex = new Regex("[0-9]");

            if (!regex.IsMatch(e.Key.ToString()) && e.Key != Key.Back)
                e.Handled = true;

            


        }

        private void CharityDonationTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (CharityDonationTextBox.Text == "")
                CharityDonationTextBox.Text = "1";
        }
    }
}
