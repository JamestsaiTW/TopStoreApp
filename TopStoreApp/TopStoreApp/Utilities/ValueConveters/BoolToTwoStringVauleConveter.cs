﻿using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using Xamarin.Forms;

namespace TopStoreApp.Utilities.ValueConveters
{
    public class BoolToTwoStringVauleConveter : IValueConverter
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
}
