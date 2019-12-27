using ChatApp.Core;
using System;
using System.Globalization;
using System.Windows;

namespace ChatApp
{
    /// <summary>
    /// A converter that takes in a <see cref="IconType"/> and returns a FontAwesome string for that icon
    /// </summary>
    public class IconTypeToFontAwesomeConverter : BaseValueConverter<IconTypeToFontAwesomeConverter>
    {
        public override object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return ((IconType)value).ToFontAwesome();
        }

        public override object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
