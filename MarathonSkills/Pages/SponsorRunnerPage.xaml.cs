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
	/// Interaction logic for SponsorRunnerPage.xaml
	/// </summary>
	public partial class SponsorRunnerPage : Page
	{

		private string SponsorAmountText;


		public SponsorRunnerPage()
		{
			InitializeComponent();
			var entities = new MarathonSkillsEntities();



			var RunnerQuery = from r in entities.Runner
							  from c in entities.Country
							  from u in entities.User
							  where r.CountryCode == c.CountryCode && r.Email == u.Email
							  orderby r.RunnerId
							  select new { Name = u.FirstName, LastName = u.LastName, Id = r.RunnerId, Country = c.CountryName }
							  ;

			var RunnerList = RunnerQuery.ToList();

			//var RunnerNameList = entities.Runner.Select(x => x.Country.CountryName).ToList();
			//RunnerList = entities.Runner.Where(x => entities.User.Where(y => y.Email.Equals(x.Email))).Country.CountryName;
			List<string> ComboBoxItems = RunnerList.Select(r => r.Name.ToString() + " " + r.LastName.ToString() + "-" + r.Id.ToString() + "(" + r.Country.ToString() + ")").ToList();


			RunnerComboBox.ItemsSource = ComboBoxItems;
			RunnerComboBox.SelectedIndex = 0;


		}

		private void SubtractAmountButton_Click(object sender, RoutedEventArgs e)
		{
			Func<int> SubtractAmount = () =>
			{
				SponsorAmountTextBox.Text = "$" + (Convert.ToInt32(SponsorAmountTextBox.Text.TrimStart('$')) - Convert.ToInt32(AddSubractAmount.Text)).ToString();
				return Convert.ToInt32(SponsorAmountTextBox.Text.TrimStart('$'));
			};



			if (AddSubractAmount.Text == "")
				return;

			if (SubtractAmount() < 0)
				SponsorAmountTextBox.Text = "$0";


		}

		private void AddAmountButton_Click(object sender, RoutedEventArgs e)
		{
			Func<int> AddAmount = () =>
			{
				SponsorAmountTextBox.Text = "$" + (Convert.ToInt32(SponsorAmountTextBox.Text.TrimStart('$')) + Convert.ToInt32(AddSubractAmount.Text)).ToString();
				return Convert.ToInt32(SponsorAmountTextBox.Text.TrimStart('$'));
			};



			if (AddSubractAmount.Text == "")
				return;

			if (AddAmount() > 100000)
				SponsorAmountTextBox.Text = "$100000";
		}

		private void SponsorAmountTextBox_TextChanged(object sender, TextChangedEventArgs e)
		{

			EnsureNumbersOnly(SponsorAmountTextBox, SponsorAmountText);

		}

		private void SponsorAmountTextBox_GotFocus(object sender, RoutedEventArgs e)
		{
			SponsorAmountText = SponsorAmountTextBox.Text;
		}

		private void AddSubractAmount_TextChanged(object sender, TextChangedEventArgs e)
		{
			EnsureNumbersOnly(AddSubractAmount, "0");
		}

		private void CharityinformationButton_Click(object sender, RoutedEventArgs e)
		{
			Window charityInfoWindow = new CharityInformationWindow(CharityNameLabel.Content.ToString());

			charityInfoWindow.ShowDialog();


		}

		private void EnsureNumbersOnly(TextBox textBox, String setText) {

			long amount = 0;
			if (Int64.TryParse(textBox.Text.TrimStart('$'), out amount) == false)
			{

				textBox.Text = setText;

			}

		}

		private void CardNumberTextBox_TextChanged(object sender, TextChangedEventArgs e)
		{
			EnsureNumbersOnly(CardNumberTextBox, "");
		}

		private void MonthTextBox_TextChanged(object sender, TextChangedEventArgs e)
		{
			EnsureNumbersOnly(MonthTextBox, "");
		}

		private void YearTextBox_TextChanged(object sender, TextChangedEventArgs e)
		{
			EnsureNumbersOnly(YearTextBox, "");
		}

		private void CVCTextBox_TextChanged(object sender, TextChangedEventArgs e)
		{
			EnsureNumbersOnly(CVCTextBox, "");
		}

		private void BackButton_Click(object sender, RoutedEventArgs e)
		{
			Window previousWindow = new StartWindow();

			previousWindow.Show();

			Window.GetWindow(this).Close();


		}

		private void PayButton_Click(object sender, RoutedEventArgs e)
		{

			if (SponsorNameTextBox.Text.IsEmpty()) {
				MessageBox.Show("Не введено имя спонсора");
				return;
			}

			if (CardBearerTextBox.Text.IsEmpty())
			{
				MessageBox.Show("Не введено имя владельца карты");
				return;
			}

			if (CardNumberTextBox.Text.IsEmpty() || CardNumberTextBox.Text.Length < 16) {
				MessageBox.Show("Некорректный номер карты");
				return;
			}

			if (MonthTextBox.Text.IsEmpty())
			{
				MessageBox.Show("Месяц окончания действия карты не введен");
				return;

			}

			if (YearTextBox.Text.IsEmpty()) {
				MessageBox.Show("Год окончания действия карты не введен");
				return;
			}

			int CurrentMonth = DateTime.Now.Month;
			int CurrentYear = DateTime.Now.Year;
			if (Int32.Parse(MonthTextBox.Text) < CurrentMonth && Int32.Parse(YearTextBox.Text) < CurrentYear) {
				MessageBox.Show("Истек срок действия карты");
				return;
			}

			if (CVCTextBox.Text.IsEmpty()) {
				MessageBox.Show("Не введен код безопасности");
				return;
			}

			if (Int32.Parse(SponsorAmountTextBox.Text.TrimStart('$')) == 0){
				MessageBox.Show("Сумма спонсорства должна быть больше 0");
				return;
			}




			SponsorConfirmation page = new SponsorConfirmation(RunnerComboBox.SelectedItem.ToString(),CharityNameLabel.Content.ToString(), SponsorAmountTextBox.Text);		
			NavigationService.Navigate(page);

			
		}

		private void SponsorNameTextBox_PreviewTextInput(object sender, TextCompositionEventArgs e)
		{

			Regex regex = new Regex("^[a-zA-Z]");


			if (!regex.IsMatch(e.Text))
				e.Handled = true;

		}

		private void RunnerComboBox_Selected(object sender, RoutedEventArgs e)
		{
			var entities = new MarathonSkillsEntities();

			var CharityQueue = from r in entities.Runner
							   from reg in entities.Registration
							   from c in entities.Charity
							   where r.RunnerId == reg.RunnerId && reg.CharityId == c.CharityId && r.RunnerId == RunnerComboBox.SelectedIndex + 100
							   select c.CharityName;

			var s = RunnerComboBox.SelectedItem.ToString();

			

			CharityNameLabel.Content = CharityQueue.First().ToString();


		}

		private void CardBearerTextBox_PreviewTextInput(object sender, TextCompositionEventArgs e)
		{
			Regex regex = new Regex("^[a-zA-Z]");


			if (!regex.IsMatch(e.Text))
				e.Handled = true;
		}

		private void MonthTextBox_PreviewTextInput(object sender, TextCompositionEventArgs e)
		{
			if (Int32.Parse(MonthTextBox.Text + e.Text) > 12) {
				e.Handled = true;

			}
		}

		
	}
}
