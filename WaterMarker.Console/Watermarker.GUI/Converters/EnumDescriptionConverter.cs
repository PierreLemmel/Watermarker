using System;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Windows.Data;

namespace Watermarker.Converters
{
    public abstract class EnumDescriptionConverter<TEnum> : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture) => typeof(TEnum)
                        .GetField(value.ToString())
                        .GetCustomAttributes(false)
                        .OfType<DescriptionAttribute>()
                        .Single()
                        .Description;

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}