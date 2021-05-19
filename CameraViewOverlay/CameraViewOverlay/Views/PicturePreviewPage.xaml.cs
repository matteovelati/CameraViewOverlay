using System;
using CameraViewOverlay.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace CameraViewOverlay.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PicturePreviewPage : ContentPage
    {
        public PicturePreviewPage(){
            InitializeComponent();
            BindingContext = ViewModelLocator.PictureViewModel;
        }

        private void Button_OnClicked(object sender, EventArgs e){
            Shell.Current.GoToAsync("///CameraViewPage", true);
        }
    }
}