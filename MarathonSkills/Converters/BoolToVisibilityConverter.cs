using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;
namespace MarathonSkills
{
    public class BoolToVisibilityConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture){

            bool Bool = (bool)value;

            
            

            return Bool == true ? Visibility.Visible : Visibility.Collapsed; 

             
        }
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture) => throw new NotImplementedException();
    }
}
