﻿using System;
using System.Globalization;
using System.Windows;
using System.Windows.Media;

namespace ChatApp
{
    /// <summary>
    /// A converter that takes in an RGB string such as ff00ff and converts it to a WPF brush
    /// </summary>
    public class StringRGBToBrushConverter : BaseValueConverter<StringRGBToBrushConverter>
    {
        public override object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return (SolidColorBrush)(new BrushConverter().ConvertFrom($"#{value}"));
        }

        public override object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
