using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;

namespace flower.Views
{
    public class WidthToVisibilityConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is double width)
                return width > 100 ? Visibility.Visible : Visibility.Collapsed;
            return Visibility.Visible;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture) => throw new NotImplementedException();
    }
}