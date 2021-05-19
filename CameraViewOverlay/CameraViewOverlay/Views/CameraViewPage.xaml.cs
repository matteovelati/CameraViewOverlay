using CameraViewOverlay.ViewModels;
using Xamarin.CommunityToolkit.UI.Views;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;


namespace CameraViewOverlay.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CameraViewPage : ContentPage
    {
        public CameraViewPage(){
            InitializeComponent();
            BindingContext = ViewModelLocator.PictureViewModel;
        }

        private void MyCameraView_OnMediaCaptured(object sender, MediaCapturedEventArgs e){
            ViewModelLocator.PictureViewModel.Photo = e.Image;
            ViewModelLocator.PictureViewModel.PhotoRotation = (int) e.Rotation;
        }
    }
}