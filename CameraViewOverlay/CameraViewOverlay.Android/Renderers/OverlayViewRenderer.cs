using System.ComponentModel;
using Android.Content;
using CameraViewOverlay;
using CameraViewOverlay.Android.Renderers;
using CameraViewOverlay.Android.Views;
using CameraViewOverlay.CustomComponents;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ExportRenderer(typeof(OverlayView), typeof(OverlayViewRenderer))]

namespace CameraViewOverlay.Android.Renderers
{
    public class OverlayViewRenderer : ViewRenderer<OverlayView, NativeOverlayView>
    {
        public OverlayViewRenderer(Context context) : base(context){ }

        protected override void OnElementChanged(ElementChangedEventArgs<OverlayView> e){
            base.OnElementChanged(e);

            if (Control == null) {
                SetNativeControl(new NativeOverlayView(Context));
            }

            if (e.NewElement != null) {
                Control.Opacity = Element.OverlayOpacity;
                Control.ShowOverlay = Element.ShowOverlay;
                Control.OverlayBackgroundColor = Element.OverlayBackgroundColor.ToAndroid();
                Control.Shape = Element.Shape;
            }

            if (e.OldElement != null) { }
        }

        protected override void OnElementPropertyChanged(object sender, PropertyChangedEventArgs e){
            base.OnElementPropertyChanged(sender, e);

            if (e.PropertyName == OverlayView.OverlayOpacityProperty.PropertyName) {
                Control.Opacity = Element.OverlayOpacity;
            }
            else if (e.PropertyName == OverlayView.OverlayBackgroundColorProperty.PropertyName) {
                Control.OverlayBackgroundColor = Element.OverlayBackgroundColor.ToAndroid();
            }
            else if (e.PropertyName == OverlayView.ShapeProperty.PropertyName) {
                Control.Shape = Element.Shape;
            }
            else if (e.PropertyName == OverlayView.ShowOverlayProperty.PropertyName) {
                Control.ShowOverlay = Element.ShowOverlay;
            }
        }
    }
}