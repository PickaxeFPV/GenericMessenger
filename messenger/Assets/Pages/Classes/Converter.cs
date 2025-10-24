﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;
using System.Windows;
using System.Windows.Data;


namespace messenger.Assets.Pages.Classes
{
    class Converter
    {
        public class BooleanToVisibilityConverter : IValueConverter
        {
            /// <summary>
            /// Converts a value.
            /// </summary>
            /// <param name="value">The value produced by the binding source.</param>
            /// <param name="targetType">The type of the binding target property.</param>
            /// <param name="parameter">The converter parameter to use.</param>
            /// <param name="culture">The culture to use in the converter.</param>
            /// <returns>A converted value. Returns Visible if the value is true; otherwise, collapsed.</returns>
            public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
            {
                return (bool)value ? Visibility.Visible : Visibility.Collapsed;
            }

            public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
            {
                throw new NotImplementedException();
            }
        }

        public class StringToVisibilityConverter : IValueConverter
        {
            public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
            {
                string inputString = value as string;
                if (inputString == "True")
                    return Visibility.Visible;
                else
                    return Visibility.Collapsed;
            }

            public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
            {
                throw new NotImplementedException();
            }
        }
    }
}
