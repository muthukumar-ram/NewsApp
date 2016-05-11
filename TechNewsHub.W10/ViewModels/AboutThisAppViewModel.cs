using System;
using AppStudio.Uwp;
using Windows.ApplicationModel;
using Windows.UI.Xaml.Media.Imaging;
using Windows.ApplicationModel.Resources;

namespace TechNewsHub.ViewModels
{
    public class AboutThisAppViewModel : ObservableBase
    {
		private ResourceLoader _resourceLoader;
        private ResourceLoader ResourceLoader
        {
            get
            {
                if (_resourceLoader == null)
                {
                    _resourceLoader = new ResourceLoader();
                }
                return _resourceLoader;
            }
        }

        public string PageTitle
        {
            get
            {
                return ResourceLoader.GetString("NavigationPaneAbout");
            }
        }

        public string Publisher
        {
            get
            {
                return "AppStudio";
            }
        }

        public string AppVersion
        {
            get
            {
                return string.Format("{0}.{1}.{2}.{3}", Package.Current.Id.Version.Major, Package.Current.Id.Version.Minor, Package.Current.Id.Version.Build, Package.Current.Id.Version.Revision);
            }
        }

        public string AboutText
        {
            get
            {
                return "Use this to create an app from scratch.";
            }
        }
		
        public string AppName
        {
            get
            {
                return "Tech News Hub";
            }
        }

		public BitmapImage AppLogo
        {
            get
            {
                return new BitmapImage(new Uri("ms-appx:///Assets/ApplicationLogo.png"));
            }
        }
    }
}

