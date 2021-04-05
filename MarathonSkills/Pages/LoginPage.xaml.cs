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
    /// Interaction logic for LoginPage.xaml
    /// </summary>
    public partial class LoginPage : Page
    {
        public LoginPage()
        {
            InitializeComponent();
        }

		private void LoginButton_Click(object sender, RoutedEventArgs e)
		{
			//TestingLoginWindow window = new TestingLoginWindow();
			//window.Show();
			//Window.GetWindow(this).Close();

            if (EmailTextBox.Text == String.Empty || PasswordTextBox.Password == String.Empty)
            {

                MessageBox.Show("Все данные должны быть введены");
                return;


            }

            var entities = new MarathonSkillsEntities();

            var User = entities.User.Where(i => i.Email == EmailTextBox.Text && i.Password == PasswordTextBox.Password);

            if (User.Count() == 0)
            {

                MessageBox.Show("Пользователя с такими данными не существует");
                return;

            }
            else
            {

                MainWindow mainWindow;

                switch (User.First().RoleId)
                {

                    case "R":
                        mainWindow = new MainWindow(new RunnerPage());
                        break;
                    case "C":
                        mainWindow = new MainWindow(new CoordinatorPage());
                        break;
                    case "A":
                        mainWindow = new MainWindow(new AdministratorPage());
                        break;
                    default:
                        mainWindow = null;
                        break;

                }


                if (mainWindow == null)
                {


                    MessageBox.Show("Пользователя с такой ролью не существует");
                    return;

                }

                mainWindow.Show();
                Window.GetWindow(this).Close();


            }


        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            if (NavigationService.CanGoBack)
            {
                NavigationService.GoBack();

            }
            else
            {

                StartWindow startWindow = new StartWindow();
                startWindow.Show();
                Window.GetWindow(this).Close();

            }
        }
    }
}
