using System.ComponentModel;
using CameraViewOverlay;
using CameraViewOverlay.CustomComponents;
using CameraViewOverlay.iOS.Renderers;
using CameraViewOverlay.iOS.Views;
using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

[assembly: ExportRenderer(typeof(OverlayView), typeof(OverlayViewRenderer))]

namespace CameraViewOverlay.iOS.Renderers
{
    public class OverlayViewRenderer : ViewRenderer<OverlayView, NativeOverlayView>
    {
        protected override void OnElementChanged(ElementChangedEventArgs<OverlayView> e){
            base.OnElementChanged(e);

            if (Control == null) {
                var view = new NativeOverlayView {ContentMode = UIViewContentMode.ScaleToFill};
                SetNativeControl(view);
            }

            if (e.NewElement == null)
                return;
            Control.Opacity = Element.OverlayOpacity;
            Control.ShowOverlay = Element.ShowOverlay;
            Control.OverlayBackgroundColor = Element.OverlayBackgroundColor.ToUIColor();
            Control.OverlayShape = Element.Shape;
        }

        protected override void OnElementPropertyChanged(object sender, PropertyChangedEventArgs e){
            base.OnElementPropertyChanged(sender, e);

            if (e.PropertyName == OverlayView.OverlayOpacityProperty.PropertyName) {
                Control.Opacity = Element.OverlayOpacity;
                Control.updateOpacity();
            }
            else if (e.PropertyName == OverlayView.OverlayBackgroundColorProperty.PropertyName) {
                Control.OverlayBackgroundColor = Element.OverlayBackgroundColor.ToUIColor();
                Control.updateFillColor();
            }
            else if (e.PropertyName == OverlayView.ShapeProperty.PropertyName) {
                Control.OverlayShape = Element.Shape;
                Control.updatePath();
            }
            else if (e.PropertyName == OverlayView.ShowOverlayProperty.PropertyName) {
                Control.ShowOverlay = Element.ShowOverlay;
            }
        }

        private bool _rendered;

        public override void LayoutSubviews(){
            base.LayoutSubviews();
            if (_rendered || !Control.ShowOverlay)
                return;
            Control.addOverlayLayer();
            _rendered = true;
        }

    }
}