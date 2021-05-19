using CameraViewOverlay.CustomComponents;
using Xamarin.CommunityToolkit.UI.Views;
using Xamarin.Forms;

namespace CameraViewOverlay.ViewModels
{
    public class PictureViewModel : BaseViewModel
    {
        public PictureViewModel(){
            MediaCapturedCommand = new Command<ImageSource>(saveImage);
        }

        // Shape 
        private OverlayShape _overlayShape = OverlayShape.Rect;

        public OverlayShape OverlayShape {
            get => _overlayShape;
            set => setProperty(ref _overlayShape, value);
        }

        private bool _isShapeToggled;

        public bool IsShapeToggled {
            get => _isShapeToggled;
            set {
                _isShapeToggled = value;
                OverlayShape = value ? OverlayShape.Oval : OverlayShape.Rect;
            }
        }

        // Flash
        private CameraFlashMode _cameraFlashMode;

        public CameraFlashMode CameraFlashMode {
            get => _cameraFlashMode;
            set => setProperty(ref _cameraFlashMode, value);
        }

        private bool _isFlashToggled;

        public bool IsFlashToggled {
            get => _isFlashToggled;
            set {
                _isFlashToggled = value;
                CameraFlashMode = value ? CameraFlashMode.Torch : CameraFlashMode.Off;
            }
        }

        // Camera
        private bool _isCameraAvailable;

        public bool IsCameraAvailable {
            get => _isCameraAvailable;
            set {
                _isCameraAvailable = value;
                IsSnapButtonEnabled = value;
            }
        }

        private bool _isCameraBusy;

        public bool IsCameraBusy {
            get => _isCameraBusy;
            set {
                _isCameraBusy = value;
                IsSnapButtonEnabled = !value;
            }
        }


        private bool _isSnapButtonEnabled;

        public bool IsSnapButtonEnabled {
            get => _isSnapButtonEnabled;
            set => setProperty(ref _isSnapButtonEnabled, value);
        }

        private ImageSource _photo;

        public ImageSource Photo {
            get => _photo;
            set => setProperty(ref _photo, value);
        }

        private int _photoRotation;

        public int PhotoRotation {
            get => _photoRotation;
            set => setProperty(ref _photoRotation, value);
        }

        public Command<ImageSource> MediaCapturedCommand { get; }

        private async void saveImage(ImageSource image){
            Photo = image;


            // Shell: Failed to Navigate Back: System.NullReferenceException: Object reference not set to an instance of an object.
            // TODO shell is bugged when navigating back..
            /*
            var stopWatch = new Stopwatch();
            stopWatch.Start();
            try {
                await Shell.Current.GoToAsync("..", true);
            }
            catch (NullReferenceException) {
                Trace.WriteLine("outerException " + stopWatch.ElapsedMilliseconds);
                while (true) {
                    await Task.Delay(100);
                    try {
                        await Shell.Current.GoToAsync("..", true);
                        stopWatch.Stop();
                        break;
                    }
                    catch (NullReferenceException) {
                        Trace.WriteLine("innerException " + stopWatch.ElapsedMilliseconds);
                    }
                }
            }
            */
        }
    }
}