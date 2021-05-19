using System;
using System.Collections.Generic;
using CameraViewOverlay.Views;
using Xamarin.Forms;

namespace CameraViewOverlay
{
    public partial class AppShell : Xamarin.Forms.Shell
    {
        public Dictionary<string, Type> Routes { get; private set; } = new Dictionary<string, Type>();

        public AppShell(){
            InitializeComponent();
            registerRoutes();
            BindingContext = this;
        }

        /**
         * Pages that are at level 2 or more in the hierarchy of the application.
         * The pages listed here will have a Back Button available.
         */
        private void registerRoutes(){
            
            //Routes.Add("PicturePreviewPage/CameraViewPage", typeof(CameraViewPage));

            foreach (var item in Routes) {
                Routing.RegisterRoute(item.Key, item.Value);
            }
        }
    }
}