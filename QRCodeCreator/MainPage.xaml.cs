using Windows.UI;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace QRCodeCreator
{
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();

            var accentColor = Edi.UWP.Helpers.UI.GetAccentColor();
            Edi.UWP.Helpers.UI.SetWindowLaunchSize(720, 360);
            Edi.UWP.Helpers.Mobile.SetWindowsMobileStatusBarColor(accentColor, Colors.White);
        }

        private void BtnAbout_OnClick(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof (About));
        }
    }
}
