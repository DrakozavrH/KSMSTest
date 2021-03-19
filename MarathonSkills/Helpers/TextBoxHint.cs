using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media;

namespace MarathonSkills.Helpers
{
    public static class TextBoxHint
    {

        

        public static void SetHint(this TextBox textBox, string hint) {

            textBox.Text = hint;
            textBox.Foreground = Brushes.LightGray;

            textBox.GotFocus += TextBoxGotFocus;            
            textBox.LostFocus += (sender,e) => TextBoxLostFocus(sender,e,hint);


        }

        private static void TextBoxLostFocus(object sender, System.Windows.RoutedEventArgs e,string hint) {

            TextBox textBox = sender as TextBox;
            

            if (String.IsNullOrEmpty(textBox.Text))
            {
                textBox.Text = hint;
                textBox.Foreground = Brushes.LightGray;
            }
            


        }

        private static void TextBoxGotFocus(object sender, System.Windows.RoutedEventArgs e) {

            TextBox textBox = sender as TextBox;
            textBox.Text = "";
            textBox.Foreground = Brushes.Black;

        }
    }
}
