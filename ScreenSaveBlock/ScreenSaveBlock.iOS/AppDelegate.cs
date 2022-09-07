using System;
using System.Collections.Generic;
using System.Linq;

using Foundation;
using UIKit;

namespace PreventScreenSave.iOS
{
    // The UIApplicationDelegate for the application. This class is responsible for launching the 
    // User Interface of the application, as well as listening (and optionally responding) to 
    // application events from iOS.
    [Register("AppDelegate")]
    public partial class AppDelegate : global::Xamarin.Forms.Platform.iOS.FormsApplicationDelegate
    {
        NSObject _screenshotNotification = null;

        public override void OnActivated(UIApplication application)
        {
            try
            {
                // Start observing screenshot notification
                if (_screenshotNotification == null)
                {
                    _screenshotNotification = NSNotificationCenter.DefaultCenter.AddObserver(UIApplication.UserDidTakeScreenshotNotification,
                                (NSNotification n) => {

                                    Console.WriteLine("UserDidTakeScreenshotNotification");

                                    n.Dispose();
                                }
                    );
                }
            }
            catch (Exception ex)
            {
                //Do something
            }
        }
        public override void OnResignActivation(UIApplication application)
        {
            try
            {
                // Stop observer
                if (_screenshotNotification != null)
                {
                    NSNotificationCenter.DefaultCenter.RemoveObserver(_screenshotNotification);
                    _screenshotNotification.Dispose();
                    _screenshotNotification = null;
                }
            }
            catch (Exception ex)
            {
                TestMessage();
            }
        }
        public override bool FinishedLaunching(UIApplication app, NSDictionary options)
        {
            global::Xamarin.Forms.Forms.Init();
            LoadApplication(new App());

            return base.FinishedLaunching(app, options);
        }

        public void TestMessage()
        {
            var pushView = UIAlertController.Create("Hata", "Uygulama Bu Özelliğe izin vermiyor", UIAlertControllerStyle.Alert);
            pushView.AddAction(UIAlertAction.Create("OK", UIAlertActionStyle.Default, alert => Console.WriteLine("Pushed")));
            //UIApplication.SharedApplication.KeyWindow.RootViewController.PresentViewController(pushView, true, null);

            Window = new UIWindow(UIScreen.MainScreen.Bounds);
            Window.RootViewController = new UIViewController();
            Window.MakeKeyAndVisible();
            Window.RootViewController.PresentViewController(pushView, true, null);
        }

    }
}
