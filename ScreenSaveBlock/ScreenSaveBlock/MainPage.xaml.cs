using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Essentials;
using System.IO;

namespace PreventScreenSave
{
    public partial class MainPage : ContentPage
    {

        public static bool IsCaptureSupported
            => PlatformIsCaptureSupported;

        public static Task<ScreenshotResult> CaptureAsync()
        {
            if (!IsCaptureSupported)
                throw new FeatureNotSupportedException();

            return PlatformCaptureAsync();
        }

        public partial class ScreenshotResult
        {
            public int Width { get; }

            public int Height { get; }

            public Task<Stream> OpenReadAsync(ScreenshotFormat format = ScreenshotFormat.Png) =>
                PlatformOpenReadAsync(format);
        }

        public enum ScreenshotFormat
        {
            Png,
            Jpeg
        }
        public MainPage()
        {
            InitializeComponent();

        }

        private void Button1_Clicked(object sender, EventArgs e)
        {
             Navigation.PushAsync(new Page2());
        }

      //async  private Task ListenEvent(object sender, EventArgs e)
      //  {

      //          if (Screenshot.IsCaptureSupported)
      //          {
      //              try
      //              {
      //                  var screenshot = await Screenshot.CaptureAsync();
      //                  var stream = await screenshot.OpenReadAsync();

      //                  var captured = ImageSource.FromStream(() => stream);
      //                  captured = null;
      //              }
      //              catch (InvalidOperationException)
      //              {
      //                await  DisplayAlert("Uyarı!", "Yapmak istediğiniz işlem uyg tarafından desteklenmemektedir!", "Geri Dön");
      //              }
      //          }
      //  }


            }

        }