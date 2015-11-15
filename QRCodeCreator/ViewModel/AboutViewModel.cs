using System;
using GalaSoft.MvvmLight;

namespace QRCodeCreator.ViewModel
{
    public class AboutViewModel : ViewModelBase
    {
        public Uri Logo => Edi.UWP.Helpers.Utils.GetAppLogoUri();

        public string DisplayName => Edi.UWP.Helpers.Utils.GetAppDisplayName();

        public string Publisher => Edi.UWP.Helpers.Utils.GetAppPublisher();

        public string Version => Edi.UWP.Helpers.Utils.GetAppVersion();
    }
}
