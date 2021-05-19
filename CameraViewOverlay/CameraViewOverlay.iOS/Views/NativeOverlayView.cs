using CameraViewOverlay.CustomComponents;
using CoreAnimation;
using CoreGraphics;
using UIKit;

namespace CameraViewOverlay.iOS.Views
{
    public class NativeOverlayView : UIView
    {

        private readonly CGColor _strokeColor = new CGColor(255, 184, 0);
        private bool _showOverlay = true;

        public bool ShowOverlay {
            get => _showOverlay;
            set {
                _showOverlay = value;

                if (_showOverlay)
                    addOverlayLayer();
                else
                    removeOverlayLayer();
            }
        }

        private CAShapeLayer _overlayFillLayer;
        private CAShapeLayer _overlayStrokeLayer;

        public float Opacity { get; set; } = 0.5f;
        public UIColor OverlayBackgroundColor { get; set; } = UIColor.Clear;
        public OverlayShape OverlayShape { get; set; } = OverlayShape.Rect;

        private UIBezierPath getRectangularOverlayPath(){
            var width = Bounds.Width * 0.8f;
            var height = Bounds.Height * 0.4f;
            var radius = 8f;

            var rectanglePath = UIBezierPath.FromRoundedRect(
                new CGRect(Bounds.GetMidX() - width / 2, Bounds.GetMidY() - height / 2, width, height),
                radius
            );
            rectanglePath.ClosePath();
            return rectanglePath;
        }

        private UIBezierPath getOvalOverlayPath(){
            var width = Bounds.Width * 0.6f;
            var height = Bounds.Height * 0.7f;

            var ovalPath = UIBezierPath.FromOval(
                new CGRect(Bounds.GetMidX() - width / 2, Bounds.GetMidY() - height / 2, width, height)
            );
            ovalPath.ClosePath();
            return ovalPath;
        }

        public void addOverlayLayer(){
            var path = UIBezierPath.FromRoundedRect(new CGRect(Frame.X, Frame.Y, Frame.Width, Frame.Height), 0);
            path.AppendPath(OverlayShape == OverlayShape.Rect
                ? getRectangularOverlayPath()
                : getOvalOverlayPath());

            path.UsesEvenOddFillRule = true;

            var fillLayer = new CAShapeLayer {
                Path = path.CGPath,
                FillRule = CAShapeLayer.FillRuleEvenOdd,
                FillColor = OverlayBackgroundColor.CGColor,
                Opacity = Opacity,
            };
            Layer.AddSublayer(fillLayer);
            _overlayFillLayer = fillLayer;

            // sight overlay
            var strokePath = OverlayShape == OverlayShape.Rect ? getRectangularOverlayPath() : getOvalOverlayPath();
            var strokeLayer = new CAShapeLayer {
                Path = strokePath.CGPath,
                FillColor = null,
                StrokeColor = _strokeColor,
                LineWidth = 2
            };
            Layer.AddSublayer(strokeLayer);
            _overlayStrokeLayer = strokeLayer;
        }


        public void updatePath(){
            var path = UIBezierPath.FromRoundedRect(new CGRect(Frame.X, Frame.Y, Frame.Width, Frame.Height), 0);
            var innerPath = OverlayShape == OverlayShape.Rect ? getRectangularOverlayPath() : getOvalOverlayPath();
            path.AppendPath(innerPath);
            
            _overlayFillLayer.Path = path.CGPath;
            _overlayStrokeLayer.Path = innerPath.CGPath;
        }

        public void updateOpacity(){
            if (_overlayFillLayer != null)
                _overlayFillLayer.Opacity = Opacity;
            if (_overlayStrokeLayer != null)
                _overlayStrokeLayer.Opacity = Opacity;
        }

        public void updateFillColor(){
            if (_overlayFillLayer != null)
                _overlayFillLayer.FillColor = OverlayBackgroundColor.CGColor;
            if (_overlayStrokeLayer != null)
                _overlayStrokeLayer.FillColor = OverlayBackgroundColor.CGColor;
        }

        public void removeOverlayLayer(){
            if (Layer.Sublayers != null)
                foreach (var l in Layer.Sublayers) {
                    l.RemoveFromSuperLayer();
                }
            _overlayFillLayer?.RemoveFromSuperLayer();
            _overlayStrokeLayer?.RemoveFromSuperLayer();
        }


    }
}