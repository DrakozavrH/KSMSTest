
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace MarathonSkills
{
    /// <summary>
    /// Interaction logic for EditRunnerProfilePage.xaml
    /// </summary>
    public partial class EditRunnerProfilePage : Page
    {
        public EditRunnerProfilePage()
        {
            InitializeComponent();
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

		private void SaveChangesButton_Click(object sender, RoutedEventArgs e)
		{

			Regex EmailRegex = new Regex(@"^(\w+)@{1}(\w+)\.(\w+)");

			

			//Password
			if (PasswordTextBox.Text.IsEmpty())
			{
				MessageBox.Show("Пароль не введен");
				return;
			}

			if (PasswordTextBox.Text.Length >= 6)
			{

				char[] RequiredCharacters = { '!', '@', '#', '$', '%', '^' };
				if (!(PasswordTextBox.Text.Any(char.IsDigit) && PasswordTextBox.Text.Any(char.IsUpper) && RequiredCharacters.Any(PasswordTextBox.Text.Contains)))
				{

					MessageBox.Show("Пароль должен содержать одну цифру, одну прописную букву и один из этих символов : ! @ # $ % ^");

				}

			}
			else
			{
				MessageBox.Show("Пароль должен быть длиннее 6 символов");
			}


			//Repeat Password
			if (RepeatPasswordTextBox.Text != PasswordTextBox.Text)
			{
				MessageBox.Show("Пароли не совпадают");
			}


		}

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
			
			NavigationService.GoBack();
        }
    }
}
