using UIKit;
using Foundation;

namespace SortingVisualisation
{
	// The name AppDelegate is referenced in the MainWindow.xib file.
	public partial class SortingVisualisationAppDelegate : UIApplicationDelegate
	{
		// This method is invoked when the application has loaded its UI and its ready to run
		public override bool FinishedLaunching (UIApplication application, NSDictionary launchOptions)
		{
			var rootViewController = new UIViewController {
				View = this.mainView
			};
			window.RootViewController = rootViewController;
			slider.Value = 30;
			glView.AnimationInterval = 1.0 / 60.0;
			glView.StartAnimation();
			glView.appDelegate = this;
			window.MakeKeyAndVisible ();

			this.Slider.Value = 30f / 255f;
			this.AnzahlIterationenLabel.Text = "";
			return true;
		}

		public override void OnResignActivation (UIApplication application)
		{
			glView.AnimationInterval = 1.0 / 5.0;
		}

		// This method is required in iPhoneOS 3.0
		public override void OnActivated (UIApplication application)
		{
			glView.AnimationInterval = 1.0 / 60.0;
		}

		public void SetSortName(string name)
		{
			sortNameLabel.Text = name;
		}

		public UIKit.UISwitch ColorSwitch { get { return this.colorSwitch; } }
		public UIKit.UISlider Slider { get { return this.slider; } }
		public UIKit.UISegmentedControl SegmentedControl { get { return this.segmentedControl; } }
		public UIKit.UILabel AnzahlIterationenLabel { get { return this.anzahlIterationenLabel; } }

		partial void switchChanged (Foundation.NSObject sender)
		{
			this.glView.Reset();
		}
	}
}

