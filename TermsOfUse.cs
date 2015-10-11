
using System;

using Foundation;
using UIKit;

/// <summary>
/// 
/// Copyright 2015 Markus Fischer
/// 
/// Permission is hereby granted, free of charge, to any person obtaining a copy
/// of this software and associated documentation files (the "Software"), to deal
/// in the Software without restriction, including without limitation the rights
/// to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
/// copies of the Software, and to permit persons to whom the Software is
/// furnished to do so, subject to the following conditions:
/// 
/// The above copyright notice and this permission notice shall be included in
/// all copies or substantial portions of the Software.
/// 
/// </summary>
namespace SortingVisualisation
{
	public partial class TermsOfUse : UIViewController
	{
		public TermsOfUse () : base ("TermsOfUse", null)
		{
		}

		public override void DidReceiveMemoryWarning ()
		{
			// Releases the view if it doesn't have a superview.
			base.DidReceiveMemoryWarning ();
			
			// Release any cached data, images, etc that aren't in use.
		}

		public override void ViewDidLoad ()
		{
			base.ViewDidLoad ();
			
			// Perform any additional setup after loading the view, typically from a nib.
		}
		partial void closeClicked (Foundation.NSObject sender)
		{
			DismissViewController(true, null);
		}
	}
}

