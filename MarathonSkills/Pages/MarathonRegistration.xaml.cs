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
        private RadioButton BundleSelected;

        private MainWindow mainWindow;

        public MarathonRegistration()
        {
            InitializeComponent();

            var entities = new MarathonSkillsEntities();

            

            CharityComboBox.ItemsSource = entities.Charity.Select(i => i.CharityName).ToArray();
            CharityComboBox.SelectedIndex = 0;

            BundleSelected = BundleOption1RadioButton;

            mainWindow = (MainWindow)(Window.GetWindow(this));

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
            BundleSelected = (RadioButton)sender ;
        }

       

        private void BundleOption2RadioButton_Checked(object sender, RoutedEventArgs e)
        {
            BundleSelected = (RadioButton)sender;
            RegistrationFeeTextBox.Text = "$" + (Int32.Parse(RegistrationFeeTextBox.Text.Trim('$')) + 20).ToString();
        }

        private void BundleOption2RadioButton_Unchecked(object sender, RoutedEventArgs e)
        {
            RegistrationFeeTextBox.Text = "$" + (Int32.Parse(RegistrationFeeTextBox.Text.Trim('$')) - 20).ToString();
        }

        private void BundleOption3RadioButton_Checked(object sender, RoutedEventArgs e)
        {
            BundleSelected = (RadioButton)sender;
            RegistrationFeeTextBox.Text = "$" + (Int32.Parse(RegistrationFeeTextBox.Text.Trim('$')) + 45).ToString();
        }

        private void BundleOption3RadioButton_Unchecked(object sender, RoutedEventArgs e)
        {
            RegistrationFeeTextBox.Text = "$" + (Int32.Parse(RegistrationFeeTextBox.Text.Trim('$')) - 45).ToString();
        }

        private void CharityDonationTextBox_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            char character = (char)KeyInterop.VirtualKeyFromKey(e.Key);

            e.Handled = !char.IsDigit(character) && e.Key != Key.Back;
        }

        private void CharityDonationTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (CharityDonationTextBox.Text == "" || CharityDonationTextBox.Text == "0")
                CharityDonationTextBox.Text = "1";
        }

        private void CharityInfoButton_Click(object sender, RoutedEventArgs e)
        {
            var window = new CharityInformationWindow(CharityComboBox.Text);
            window.ShowDialog();
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }

        private void RegisterButton_Click(object sender, RoutedEventArgs e)
        {

            if (!(FullMarathonIsChecked == true || HalfMarathonIsChecked == true || SmallMarathonIsChecked == true)) {

                MessageBox.Show("Должен быть выбран хотя бы один вид марафона");
                return;
            
            }

            var entities = new MarathonSkillsEntities();

            //if (entities.Registration.Where(r => r.RunnerId == mainWindow.UserData.RunnerId).Count() > 0) {


            //    MessageBox.Show("Вы уже зарегистрированы на марафон");
            
            
            //}

            var registration = new Registration
            {

                RunnerId = ((MainWindow)Window.GetWindow(this)).UserData.RunnerId,
                RegistrationDateTime = DateTime.Now,
                RaceKitOptionId = BundleSelected.Tag.ToString(),
                RegistrationStatusId = 1,
                Cost = Convert.ToDecimal(RegistrationFeeTextBox.Text.Trim('$')),
                CharityId = entities.Charity.Where(c => c.CharityName == CharityComboBox.Text).First().CharityId,
                SponsorshipTarget = Convert.ToDecimal(CharityDonationTextBox.Text)

            };

            #region v2

            //RegistrationEvent registrationEvent = new RegistrationEvent {RegistrationId = registration.RegistrationId };

            //if (FullMarathonIsChecked)
            //{

            //    registrationEvent.EventId = "15_5FM";
            //    if (entities.RegistrationEvent.Where(a => a.RegistrationId == registration.RegistrationId && a.EventId == "15_5FM").Count() > 0)
            //    {

            //        MessageBox.Show("Вы уже зарегистрированы на данный марафон");
            //        return;

            //    }
            //    entities.RegistrationEvent.Add(registrationEvent);

            //}


            //if (HalfMarathonIsChecked)
            //{

            //    registrationEvent.EventId = "15_5HM";
            //    if (entities.RegistrationEvent.Where(a => a.RegistrationId == registration.RegistrationId && a.EventId == "15_5HM").Count() > 0)
            //    {

            //        MessageBox.Show("Вы уже зарегистрированы на данный марафон");
            //        return;

            //    }
            //    entities.RegistrationEvent.Add(registrationEvent);
            //}


            //if (SmallMarathonIsChecked)
            //{

            //    registrationEvent.EventId = "15_5FR";
            //    if (entities.RegistrationEvent.Where(a => a.RegistrationId == registration.RegistrationId && a.EventId == "15_5FR").Count() > 0)
            //    {

            //        MessageBox.Show("Вы уже зарегистрированы на данный марафон");
            //        return;

            //    }
            //    entities.RegistrationEvent.Add(registrationEvent);


            //}

            #endregion

            if (FullMarathonIsChecked)
            {
                if(!AddRegistrationEvent("15_5FM", registration, ref entities))
                    return;
            }

            if (HalfMarathonIsChecked) {

                if(!AddRegistrationEvent("15_5HM", registration, ref entities))
                    return;

            }


            if (SmallMarathonIsChecked) {

                if (!AddRegistrationEvent("15_5FR", registration, ref entities))
                    return;


            }
                

            entities.Registration.Add(registration);

            entities.SaveChanges();


            NavigationService.Navigate(new RunnerRegistrationConfirmationPage());
            NavigationService.RemoveBackEntry();
            
        }


        private bool AddRegistrationEvent(string eventID, Registration registration,ref MarathonSkillsEntities entities)
        {

           
            RegistrationEvent registrationEvent = new RegistrationEvent { RegistrationId = registration.RegistrationId };

            var RunnerRegistrations = entities.Registration.Where(r => r.RunnerId == registration.RunnerId).Select(i=> i.RegistrationId);

            registrationEvent.EventId = eventID;


            //if (entities.RegistrationEvent.Where(a => a.RegistrationId ==  && a.EventId == eventID).Count() > 0)
            //{

            //    MessageBox.Show("Вы уже зарегистрированы на данный марафон");
            //    return;

            //}


            if (entities.RegistrationEvent.Any(r => RunnerRegistrations.Contains(r.RegistrationId) && r.EventId == eventID)) {


                MessageBox.Show("Вы уже зарегистрированы на данный марафон");                
                return false;


            }


            entities.RegistrationEvent.Add(registrationEvent);

            return true; 

        }
    }
}
