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
	[Register ("InfoPopupOverViewController")]
	partial class InfoPopupOverViewController
	{
		[Outlet]
		UIKit.UIWebView webView { get; set; }

		[Action ("closeClicked:")]
		partial void closeClicked (Foundation.NSObject sender);
		
		void ReleaseDesignerOutlets ()
		{
			if (webView != null) {
				webView.Dispose ();
				webView = null;
			}
		}
	}
}
