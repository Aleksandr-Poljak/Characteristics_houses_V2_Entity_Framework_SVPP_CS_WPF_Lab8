﻿using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace SVPP_CS_WPF_Lab8_Characteristics_houses_Db_V2_Entity_Framework_.OtherWindows
{
    public class NullToStringConverter: IValueConverter
    {
        public object? Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is null) return string.Empty;
            return value.ToString()!;
        }

        public object? ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            string valueStr = (string)value;
            if (valueStr.Length == 0) return null;
            return value;
        }
    }
}
