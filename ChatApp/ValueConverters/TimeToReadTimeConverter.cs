using System;
using System.Globalization;
using System.Windows;

namespace ChatApp
{
    /// <summary>
    /// A converter that takes in date and converts it to a user friendly message read time
    /// </summary>
    public class TimeToReadTimeConverter : BaseValueConverter<TimeToReadTimeConverter>
    {
        public override object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            // Get the time passed in
            var time = (DateTimeOffset)value;

            // If it is not read
            if (time == DateTimeOffset.MinValue)
                // Show nothing
                return string.Empty;

            // If it is today
            if (time.Date == DateTimeOffset.UtcNow.Date)
                // Return just time
                return $"Read {time.ToLocalTime().ToString("HH:mm")}";
            else if(time.ToLocalTime().Year == DateTimeOffset.UtcNow.Year)
                // return a full date without a year
                return $"Read {time.ToLocalTime().ToString("HH:mm dd/MMM")}";
            else
                // Otherwise return a full date with year
                return $"Read {time.ToLocalTime().ToString("HH:mm dd/MMM/yyyy")}";
        }

        public override object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
