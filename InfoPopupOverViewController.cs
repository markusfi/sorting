
using System;

using Foundation;
using UIKit;
using CoreGraphics;

namespace SortingVisualisation
{
	public partial class InfoPopupOverViewController : UIViewController
	{
		public InfoPopupOverViewController () : base ("InfoPopupOverViewController", null)
		{
		}
		public string Sort { get; set; }

		public override void DidReceiveMemoryWarning ()
		{
			// Releases the view if it doesn't have a superview.
			base.DidReceiveMemoryWarning ();
			
			// Release any cached data, images, etc that aren't in use.
		}

		public override void ViewDidLoad ()
		{
			base.ViewDidLoad ();

			this.webView.LoadRequest (new NSUrlRequest (new NSUrl ("https://en.wikipedia.org/wiki/"+this.Sort.Replace(" ","_"))));
		}

		partial void closeClicked (Foundation.NSObject sender)
		{
			DismissViewController(true, null);
		}
	}
}

