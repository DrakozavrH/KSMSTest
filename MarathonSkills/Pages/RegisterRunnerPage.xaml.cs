
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace MarathonSkills
{
	/// <summary>
	/// Логика взаимодействия для RegisterRunnerPage.xaml
	/// </summary>
	public partial class RegisterRunnerPage : Page
	{
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

				}
				
			}
			else
			{
				MessageBox.Show("Пароль должен быть длиннее 6 символов");
			}


			//Repeat Password
			if(RepeatPasswordTextBox.Text != PasswordTextBox.Text)
			{
				MessageBox.Show("Пароли не совпадают");
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
	}
}
