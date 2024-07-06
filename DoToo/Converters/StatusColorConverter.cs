﻿using System.Globalization;

namespace DoToo.Converters;
public class StatusColorConverter : IValueConverter
{
    public object Convert(object value, Type targetType, object parameter, CultureInfo culture) 
        => (Color)Application.Current.Resources[(bool)value ? "CompletedColor" : "ActiveColor"];
    public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture) 
        => null;
}