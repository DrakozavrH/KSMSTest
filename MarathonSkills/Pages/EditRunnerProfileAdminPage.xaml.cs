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
    /// Interaction logic for EditRunnerProfileAdminPage.xaml
    /// </summary>
    public partial class EditRunnerProfileAdminPage : Page
    {
        public EditRunnerProfileAdminPage()
        {
            InitializeComponent();
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {

            NavigationService.GoBack();
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


    }
}
