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

     //   public static string okeyMessage = "okeyMessage";
        public void msg()
        {
            DisplayAlert("Uyarı!", "Ekran Görüntüsü alma özelliği uygulama tarafından desteklenmemektedir!", "Geri Dön");
        }


        public MainPage()
        {
            InitializeComponent();

        }
        //static void ListenEvent()
        //{

        //    Task.Run(() => { msg(); });
        //}



        private void Button1_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new Page2());
        }


        async private Task msg(object sender, EventArgs e)
        {

            if (Screenshot.IsCaptureSupported)
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
                    await DisplayAlert("Uyarı!", "Yapmak istediğiniz işlem uyg tarafından desteklenmemektedir!", "Geri Dön");
                }
            }
        }




    }

}