using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;
using System.Windows;
using System.Windows.Data;

namespace messenger
{
    public class ChatItem
    {
        public string ImageUri { get; set; }
        public string Name { get; set; }
        public string LastMessage { get; set; }
        public bool isRead { get; set; }
        public bool isGroup { get; set; }
        public bool isOnline { get; set; }
    }

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

    /// <summary>
    /// Class representing a message.
    /// </summary>
    public class UserMessage
    {
        public string ImageUri { get; set; }
        public string UserName { get; set; }
        public string Text { get; set; }
        public DateTime TimeStamp { get; set; }
        public bool IsFromSelf { get; set; }
        public bool IsEdited { get; set; }
    }

    public class MessageCollection: ObservableCollection<UserMessage>
    {
    }
    public class Filtered:ObservableCollection<ChatItem>
    {
    };
}
