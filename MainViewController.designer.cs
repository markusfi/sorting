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
	[Register ("MainViewController")]
	partial class MainViewController
	{
		[Outlet]
		UIKit.UILabel anzahlIterationenLabel { get; set; }

		[Outlet]
		UIKit.UISwitch colorSwitch { get; set; }

		[Outlet]
		SortingVisualisation.EAGLView glView { get; set; }

		[Outlet]
		UIKit.UISegmentedControl segmentedControl { get; set; }

		[Outlet]
		UIKit.UISlider slider { get; set; }

		[Outlet]
		UIKit.UILabel sortNameLabel { get; set; }

		[Action ("infoClicked:")]
		partial void infoClicked (Foundation.NSObject sender);

		[Action ("switchChanged:")]
		partial void switchChanged (Foundation.NSObject sender);

		[Action ("termsOfUseClicked:")]
		partial void termsOfUseClicked (Foundation.NSObject sender);
		
		void ReleaseDesignerOutlets ()
		{
			if (anzahlIterationenLabel != null) {
				anzahlIterationenLabel.Dispose ();
				anzahlIterationenLabel = null;
			}

			if (colorSwitch != null) {
				colorSwitch.Dispose ();
				colorSwitch = null;
			}

			if (glView != null) {
				glView.Dispose ();
				glView = null;
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
		}
	}
}
