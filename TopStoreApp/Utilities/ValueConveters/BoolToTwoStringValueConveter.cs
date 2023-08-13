using System.Globalization;

using Microsoft.Maui;
using Microsoft.Maui.Controls;

namespace TopStoreApp.Utilities.ValueConveters;

public class BoolToTwoStringValueConveter : IValueConverter
{
    public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
    {
        var parameterForTrueOrFlase = parameter.ToString().Split(',');
        return (bool)value ? parameterForTrueOrFlase[0] : parameterForTrueOrFlase[1];
    }

    public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
    {
        return string.IsNullOrEmpty((string)value);
    }
}