using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MarathonSkills.Helpers
{
    public static class TextBoxInput
    {

        public static void RestrictToNumbers(object sender, KeyEventArgs e)
        {

            char character = (char)KeyInterop.VirtualKeyFromKey(e.Key);

            e.Handled = !char.IsDigit(character) && e.Key != Key.Back;

        }



    }
}
