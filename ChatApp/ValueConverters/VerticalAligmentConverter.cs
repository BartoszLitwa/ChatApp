using System;
using System.Globalization;
using System.Windows;

namespace ChatApp
{
    /// <summary>
    /// A converter that takes in the core vertical alignment enum and converts to it WPF alignment
    /// </summary>
    public class VerticalAligmentConverter : BaseValueConverter<VerticalAligmentConverter>
    {
        public override object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return (VerticalAlignment)value;
        }

        public override object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
