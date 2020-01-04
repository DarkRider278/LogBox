﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows.Media;
using MahApps.Metro.IconPacks;

namespace LogBox
{
    /// <summary>
    /// Convert LogTypes enum values to GeometryDrawing representation of the LogType icon
    /// </summary>
    [ValueConversion(typeof(LogTypes), typeof(GeometryDrawing))]
    public class LogTypesToIconGeometryConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            string iconDataStr = null;
            Brush foregroundBrush = null;
            Brush strokeBrush = null;

            switch ((LogTypes)value)
            {
                case LogTypes.INFO:
                    iconDataStr = (new PackIconModern() { Kind = PackIconModernKind.InformationCircle }).Data; foregroundBrush = new SolidColorBrush(Colors.Blue); strokeBrush = new SolidColorBrush(Colors.LightBlue); break;
                case LogTypes.WARNING:
                    iconDataStr = (new PackIconModern() { Kind = PackIconModernKind.Warning }).Data; foregroundBrush = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FFE4E44C")); strokeBrush = new SolidColorBrush(Colors.Orange); break;
                case LogTypes.ERROR:
                    iconDataStr = (new PackIconEntypo() { Kind =  PackIconEntypoKind.CircleWithCross }).Data; foregroundBrush = new SolidColorBrush(Colors.Red); strokeBrush = foregroundBrush; break;
                case LogTypes.IMAGE:
                    iconDataStr = (new PackIconModern() { Kind = PackIconModernKind.Image }).Data; foregroundBrush = new SolidColorBrush(Colors.Gray); strokeBrush = foregroundBrush; break;
                default:
                    return null;
            }

            Geometry iconGeometry = Geometry.Parse(iconDataStr);
            GeometryDrawing iconGeometryDrawing = new GeometryDrawing(foregroundBrush, new Pen(strokeBrush, 1), iconGeometry);
            return iconGeometryDrawing;
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotSupportedException();
        }
    }
}
