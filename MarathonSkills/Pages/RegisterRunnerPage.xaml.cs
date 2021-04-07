
using Microsoft.Win32;
using System;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media.Imaging;

namespace MarathonSkills
{
	/// <summary>
	/// Логика взаимодействия для RegisterRunnerPage.xaml
	/// </summary>
	public partial class RegisterRunnerPage : Page
	{

		private byte[] ImageByteArray;

		public RegisterRunnerPage()
		{
			InitializeComponent();


			MarathonSkillsEntities entities = new MarathonSkillsEntities();


			var CountryList = entities.Country
				.Select(x => x.CountryName)
				.Distinct()
				.ToList();
			CountryPickerComboBox.ItemsSource = CountryList;

			var GenderList = entities.Gender
				.Select(x => x.Gender1)
				.Distinct()
				.ToList();
			GenderPickerComboBox.ItemsSource = GenderList;

		}

		private void RegisterButton_Click(object sender, RoutedEventArgs e)
		{
			
			

			Regex EmailRegex = new Regex(@"^(\w+)@{1}(\w+)\.(\w+)");

			//Email
			if (EmailTextBox.Text.IsEmpty())
			{
				MessageBox.Show("Email не введен");
				return;
			}

			if (!EmailRegex.IsMatch(EmailTextBox.Text))
			{
				MessageBox.Show("Неверный формат Email");
				return;
			}

			//Password
			if (PasswordTextBox.Text.IsEmpty()) {
				MessageBox.Show("Пароль не введен");
				return;
			}

			if (PasswordTextBox.Text.Length >= 6) {

				char[] RequiredCharacters = { '!', '@', '#', '$', '%', '^' };
				if (!(PasswordTextBox.Text.Any(char.IsDigit) && PasswordTextBox.Text.Any(char.IsUpper) && RequiredCharacters.Any(PasswordTextBox.Text.Contains))) {

					MessageBox.Show("Пароль должен содержать одну цифру, одну прописную букву и один из этих символов : ! @ # $ % ^");
					return;
				}

				
			}
			else
			{
				MessageBox.Show("Пароль должен быть длиннее 6 символов");
				return;
			}


			//Repeat Password
			if(RepeatPasswordTextBox.Text != PasswordTextBox.Text)
			{
				MessageBox.Show("Пароли не совпадают");
				return;
			}


			if (DateTime.Now - BirthDatePicker.SelectedDate < TimeSpan.FromDays(365 * 10) || BirthDatePicker.SelectedDate > DateTime.Now) { 
				MessageBox.Show("Некорректная дата рождения"); 
				return; 
			}

			MarathonSkillsEntities entities = new MarathonSkillsEntities();

			if(entities.User.Where(i => i.Email == EmailTextBox.Text).Count() !=0)
            {
				MessageBox.Show("Пользователь с таким именем уже существует");
				return;
            }


			if (ImageByteArray.Count() > 0)
			{
				

				
				

				entities.User.Add(new User
				{
					Email = EmailTextBox.Text,
					Password = PasswordTextBox.Text,
					FirstName = FirstNameTextBox.Text,
					LastName = LastNameTextBox.Text,
					RoleId = "R"
					
				});


				Runner NewRunner = new Runner 
				{

					Email = EmailTextBox.Text,
					Gender = GenderPickerComboBox.Text,
					DateOfBirth = BirthDatePicker.SelectedDate,
					CountryCode = entities.Country.Where(i => i.CountryName == CountryPickerComboBox.Text).FirstOrDefault().CountryCode

				};

				entities.Runner.Add(NewRunner);
				
									

				entities.RunnerImages.Add(new RunnerImages
				{

					ImageBytes = ImageByteArray,
					runnerId = NewRunner.RunnerId


				});


				entities.SaveChanges();

				NavigationService.Navigate(new LoginPage());
				NavigationService.RemoveBackEntry();

			}
			else {


				MessageBox.Show("Изображение не выбрано");
				return;
			
			}



		}

		private void TextBox_PreviewTextInput(object sender, TextCompositionEventArgs e)
		{
			
			Regex onlyCharacters = new Regex(@"[^a-zA-Z]");
			if (onlyCharacters.IsMatch(e.Text))
				e.Handled = true;
		}

		private void TextBox_PreviewKeyDown(object sender, KeyEventArgs e)
		{
			TextBox textBox = sender as TextBox;
			if (e.Key == Key.Space)
				e.Handled = true;
		}

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
			NavigationService.GoBack();
        }

        private void SelectImageButton_Click(object sender, RoutedEventArgs e)
        {
			
			OpenFileDialog fileDialog = new OpenFileDialog();
			fileDialog.Filter = "Image files (*.png) | *.png; *.jpg" ;
			if (fileDialog.ShowDialog() == true) {

				ImagePathTextBox.Text = fileDialog.FileName;
				RunnerImage.Source = new BitmapImage(new Uri(fileDialog.FileName,UriKind.Absolute));
				ImageByteArray = File.ReadAllBytes(fileDialog.FileName);
			}
        }
    }
}
