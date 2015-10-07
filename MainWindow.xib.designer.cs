// WARNING
//
// This file has been generated automatically by Xamarin Studio to store outlets and
// actions made in the UI designer. If it is removed, they will be lost.
// Manual changes to this file may not be handled correctly.
//
using Foundation;
using System.CodeDom.Compiler;

namespace SortingVisualisation
{
	[Register ("OpenGLESSampleAppDelegate")]
	partial class SortingVisualisationAppDelegate
	{
		[Outlet]
		UIKit.UILabel anzahlIterationenLabel { get; set; }

		[Outlet]
		UIKit.UISwitch colorSwitch { get; set; }

		[Outlet]
		SortingVisualisation.EAGLView glView { get; set; }

		[Outlet]
		UIKit.UIView mainView { get; set; }

		[Outlet]
		UIKit.UISegmentedControl segmentedControl { get; set; }

		[Outlet]
		UIKit.UISlider slider { get; set; }

		[Outlet]
		UIKit.UILabel sortNameLabel { get; set; }

		[Outlet]
		UIKit.UIWindow window { get; set; }

		[Action ("colorSwitchChanged:")]
		partial void colorSwitchChanged (Foundation.NSObject sender);

		[Action ("switchChanged:")]
		partial void switchChanged (Foundation.NSObject sender);
		
		void ReleaseDesignerOutlets ()
		{
			if (colorSwitch != null) {
				colorSwitch.Dispose ();
				colorSwitch = null;
			}

			if (glView != null) {
				glView.Dispose ();
				glView = null;
			}

			if (mainView != null) {
				mainView.Dispose ();
				mainView = null;
			}

			if (segmentedControl != null) {
				segmentedControl.Dispose ();
				segmentedControl = null;
			}

			if (slider != null) {
				slider.Dispose ();
				slider = null;
			}

			if (sortNameLabel != null) {
				sortNameLabel.Dispose ();
				sortNameLabel = null;
			}

			if (anzahlIterationenLabel != null) {
				anzahlIterationenLabel.Dispose ();
				anzahlIterationenLabel = null;
			}

			if (window != null) {
				window.Dispose ();
				window = null;
			}
		}
	}

	[Register ("EAGLView")]
	partial class EAGLView
	{
		
		void ReleaseDesignerOutlets ()
		{
		}
	}
}
