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
    /// Interaction logic for CharityListPage.xaml
    /// </summary>
    public partial class CharityListPage : Page
    {
        public CharityListPage()
        {
            InitializeComponent();
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {

			MarathonSkillsEntities entitites = new MarathonSkillsEntities();

			//List<CharityItem> charities = entitites.Charity.Select(x => new CharityItem()
			//{
			//	HeaderText = x.CharityName,
			//	DescriptionText = x.CharityDescription,
			//	ImageSource = String.Format("/Images/{0}", x.CharityLogo)
			//}).ToList();


			List<CharityItem> charities = entitites.Charity
				.Select(x => new { x.CharityLogo, x.CharityName, x.CharityDescription })
				.AsEnumerable()
				.Select(x => new CharityItem()
				{
					HeaderText = x.CharityName,
					DescriptionText = x.CharityDescription,
					ImageSource = String.Format("/Images/{0}", x.CharityLogo)
				}).ToList();

			//List<CharityItem> charities = new List<CharityItem>();
			//charities.Add(new CharityItem() { ImageSource = "/Images/arise-logo.png", HeaderText = "SampleHeaderText1", DescriptionText = "Descriptionaaaaaaaaaaaa1" });
			//charities.Add(new CharityItem() { ImageSource = "/Images/aves-do-brazil-logo.png", HeaderText = "SampleHeaderText2", DescriptionText = "Descriptionaaaaaaaaaaaa2" });
			//charities.Add(new CharityItem() { ImageSource = "/Images/upbeat-logo.png", HeaderText = "SampleHeaderText3", DescriptionText = "Descriptionaaaaaaaaaaa3" });

			CharityList.ItemsSource = charities;
        }

        public class CharityItem {

            public string ImageSource { get; set; }
            public string HeaderText { get; set; }
            public string DescriptionText { get; set; }
        
        }

    }
}
