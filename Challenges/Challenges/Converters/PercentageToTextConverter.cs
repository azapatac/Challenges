using System;
using System.Globalization;
using Xamarin.Forms;

namespace Challenges.Converters
{
	public class PercentageToTextConverter : IValueConverter
	{
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is null)
                return "0%";

            return $"{(double)value * 100}%";
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return value;
        }
    }
}