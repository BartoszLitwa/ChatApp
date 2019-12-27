using System;
using System.Globalization;
using System.Windows;
using ChatApp.Core;

namespace ChatApp
{
    /// <summary>
    /// A converter that takes in a <see cref="BaseViewModel"/> and returns the specific UI control
    /// thats should bind to that type of ViewModel
    /// </summary>
    public class PopupContentConverter : BaseValueConverter<PopupContentConverter>
    {
        public override object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is MenuViewModel basePopup)
                return new VerticalMenu { DataContext = basePopup };

            return null;
        }

        public override object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
