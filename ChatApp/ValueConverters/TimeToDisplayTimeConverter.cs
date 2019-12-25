using System;
using System.Globalization;
using System.Windows;

namespace ChatApp
{
    /// <summary>
    /// A converter that takes in date and converts it to a user friendly time
    /// </summary>
    public class TimeToDisplayTimeConverter : BaseValueConverter<TimeToDisplayTimeConverter>
    {
        public override object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            // Get the time passed in
            var time = (DateTimeOffset)value;

            // If it is today
            if (time.Date == DateTimeOffset.UtcNow.Date)
                // Return just time
                return time.ToLocalTime().ToString("HH:mm");
            else if(time.ToLocalTime().Year == DateTimeOffset.UtcNow.Year)
                // return a full date without a year
                return time.ToLocalTime().ToString("HH:mm dd/MMM");
            else
                // Otherwise return a full date with year
                return time.ToLocalTime().ToString("HH:mm dd/MMM/yyyy");
        }

        public override object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
