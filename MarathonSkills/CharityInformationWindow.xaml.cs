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
using System.Windows.Shapes;

namespace MarathonSkills
{
    /// <summary>
    /// Логика взаимодействия для SponsorInformationWindow.xaml
    /// </summary>
    public partial class CharityInformationWindow : Window
    {
        public CharityInformationWindow(string CharityName)
        {
            InitializeComponent();
			var entities = new MarathonSkillsEntities();


			CharityNameHeader.Text = CharityName;

			var ImageQuery = from i in entities.Charity
							 where i.CharityName == CharityName
							 select i.CharityLogo;

			string imageString = ImageQuery.First();
			CharityImage.Source = new BitmapImage(new Uri( String.Format("/Images/{0}", imageString),UriKind.Relative));

			var DescriptionQuery = from c in entities.Charity
									  where c.CharityName == CharityName
									  select c.CharityDescription;

			CharityDescription.Text = DescriptionQuery.First();



        }
    }
}
