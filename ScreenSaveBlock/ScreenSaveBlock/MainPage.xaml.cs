using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Essentials;

namespace PreventScreenSave
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private void Button1_Clicked(object sender, EventArgs e)
        {
             Navigation.PushAsync(new Page2());
        }

      async  private Task ListenEvent(object sender, EventArgs e)
        {

                if (Screenshot.IsCaptureSupported)
                {
                    try
                    {
                        var screenshot = await Screenshot.CaptureAsync();
                        var stream = await screenshot.OpenReadAsync();

                        var captured = ImageSource.FromStream(() => stream);
                        if (captured != null)
                        {
                            captured = null;
                        }
                    }
                    catch (InvalidOperationException)
                    {
                      await  DisplayAlert("Uyarı!", "Yapmak istediğiniz işlem uyg tarafından desteklenmemektedir!", "Geri Dön");
                    }
                }
        }
            }

        }
    }
}
