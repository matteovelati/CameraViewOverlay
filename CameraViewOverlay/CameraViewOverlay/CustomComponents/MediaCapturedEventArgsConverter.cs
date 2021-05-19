using System;
using System.Globalization;
using Xamarin.CommunityToolkit.Extensions.Internals;
using Xamarin.CommunityToolkit.UI.Views;
using Xamarin.Forms;

namespace CameraViewOverlay.CustomComponents
{
    public class MediaCapturedEventArgsConverter : ValueConverterExtension, IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture) =>
            value is MediaCapturedEventArgs changedEventArgs
                ? changedEventArgs.Image
                : throw new ArgumentException("Expected value to be of type MediaCapturedEventArgs", nameof(value));

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture){
            throw new NotImplementedException();
        }
    }
}