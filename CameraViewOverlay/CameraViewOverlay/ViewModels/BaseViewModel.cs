using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace CameraViewOverlay.ViewModels
{
    public class BaseViewModel : INotifyPropertyChanged
    {

        protected bool setProperty<T>(ref T storage, T value, [CallerMemberName] string propertyName = null){
            if (EqualityComparer<T>.Default.Equals(storage, value)) {
                return false;
            }
            storage = value;
            onPropertyChanged(propertyName);
            return true;
        }
        
        public event PropertyChangedEventHandler PropertyChanged;
        
        protected void onPropertyChanged([CallerMemberName] string propertyName = null){
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
    
}