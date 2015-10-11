using UIKit;
using Foundation;
using CoreGraphics;

namespace SortingVisualisation
{
	[Register ("AppDelegate")]
	public partial class AppDelegate : UIApplicationDelegate
	{
		// class-level declarations
		UIWindow window;

		//
		// This method is invoked when the application has loaded and is ready to run. In this
		// method you should instantiate the window, load the UI into it and then make the window
		// visible.
		//
		// You have 17 seconds to return from this method, or iOS will terminate your application.
		//
		public override bool FinishedLaunching (UIApplication app, NSDictionary options)
		{
			// create a new window instance based on the screen size
			window = new UIWindow (UIScreen.MainScreen.Bounds);

			// If you have defined a root view controller, set it here:
			window.RootViewController = this.MainViewController = new MainViewController();

			// make the window visible
			window.MakeKeyAndVisible ();

			return true;
		}

		public SortingVisualisation.MainViewController MainViewController { get; set; }

		public override void OnResignActivation (UIApplication application)
		{
//			this.MainViewController.GlView.StopAnimation ();
//			this.MainViewController.GlView.AnimationInterval = 1.0 / 5.0;
		}

		// This method is required in iPhoneOS 3.0
		public override void OnActivated (UIApplication application)
		{
	//		this.MainViewController.GlView.AnimationInterval = 1.0 / 60.0;
		}
		public override void DidEnterBackground (UIApplication application)
		{
	//		this.MainViewController.GlView.StopAnimation ();
		}
	}
}

