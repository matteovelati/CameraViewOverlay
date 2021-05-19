namespace CameraViewOverlay.ViewModels
{
    public static class ViewModelLocator
    {
        private static PictureViewModel _pictureViewModel;

        public static PictureViewModel PictureViewModel {
            get {
                if (_pictureViewModel == null) 
                    _pictureViewModel = new PictureViewModel();
                
                return _pictureViewModel;
            }
        }
        
    }
}