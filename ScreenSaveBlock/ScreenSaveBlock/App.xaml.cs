using System;
using System.IO;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using System.Threading.Tasks;
namespace PreventScreenSave
{
    public partial class App : Application
    {

        public App()
        {
            InitializeComponent();
            MainPage = new NavigationPage(new MainPage());

             
        }
        private void checkss()
        {

            if (Screenshot.IsCaptureSupported)
            {
                Device.BeginInvokeOnMainThread(async () =>
                {

                try
                {
                    var screenshot = await Screenshot.CaptureAsync();
                    var stream = await screenshot.OpenReadAsync();

                    var captured = ImageSource.FromStream(() => stream);
                    captured = null;
                }
                catch (InvalidOperationException)
                {
                    await Xamarin.Forms.Application.Current.MainPage.DisplayAlert("Hata","Uygulama bu işleme izin vermemektedir","Geri Dön");
            }
                    checkss();
                });
            }
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
