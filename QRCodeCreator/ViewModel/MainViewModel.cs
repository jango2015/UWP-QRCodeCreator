using System;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;
using Windows.Storage.Pickers;
using Windows.Storage.Provider;
using Windows.UI.Popups;
using Windows.UI.Xaml.Media.Imaging;
using Edi.UWP.Helpers;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using ZXing;
using ZXing.Common;

namespace QRCodeCreator.ViewModel
{
    public class MainViewModel : ViewModelBase
    {
        private string _sourceText;

        public string SourceText
        {
            get { return _sourceText; }
            set { _sourceText = value; RaisePropertyChanged(); }
        }

        private WriteableBitmap _bitmap;

        public WriteableBitmap Bitmap
        {
            get { return _bitmap; }
            set { _bitmap = value; RaisePropertyChanged(); }
        }


        public RelayCommand CommandGetQRCode { get; set; }

        public RelayCommand CommandSave { get; set; }

        public MainViewModel()
        {
            SourceText = "http://edi.wang";
            CommandGetQRCode = new RelayCommand(GetQRCode);
            CommandSave = new RelayCommand(async ()=> await SaveToPic());
        }

        public void GetQRCode()
        {
            IBarcodeWriter writer = new BarcodeWriter()
            {
                Format = BarcodeFormat.QR_CODE,
                Options = new EncodingOptions
                {
                    Height = 800,
                    Width = 800
                }
            };
            var data = writer.Write(SourceText.Trim());

            var bitmap = (WriteableBitmap)(data.ToBitmap());
            Bitmap = bitmap;
        }

        public async Task SaveToPic()
        {
            try
            {
                var fileName = $"QRCODE_{DateTime.Now.ToString("yyyy-MM-dd-HHmmss")}";
                var result = await Bitmap.SaveToPngImage(PickerLocationId.PicturesLibrary, fileName);

                if (result == FileUpdateStatus.Complete)
                {
                    var dig = new MessageDialog($"{fileName}.png","保存成功");
                    await dig.ShowAsync();
                }
                else
                {
                    var dig = new MessageDialog($"{result}", "保存失败");
                    await dig.ShowAsync();
                }
            }
            catch (Exception ex)
            {
                var dig = new MessageDialog($"{ex.Message}", "保存失败");
                await dig.ShowAsync();
            }
        }
    }
}
