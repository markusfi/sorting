
using System;

using Foundation;
using UIKit;
using CoreGraphics;

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
	public partial class MainViewController : UIViewController, IUIPopoverPresentationControllerDelegate
	{
		public MainViewController () : base ("MainViewController", null)
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
			
			slider.Value = 30;
			glView.MainViewController = this;
			glView.AnimationInterval = 1.0 / 60.0;
			glView.StartAnimation();

			this.Slider.Value = 30f / 255f;
			this.AnzahlIterationenLabel.Text = "";
		}

		public void SetSortName(string name)
		{
			sortNameLabel.Text = name;
		}

		public UIKit.UISwitch ColorSwitch { get { return this.colorSwitch; } }
		public UIKit.UISlider Slider { get { return this.slider; } }
		public UIKit.UISegmentedControl SegmentedControl { get { return this.segmentedControl; } }
		public UIKit.UILabel AnzahlIterationenLabel { get { return this.anzahlIterationenLabel; } }
		public SortingVisualisation.EAGLView GlView { get { return this.glView; } }

		partial void switchChanged (Foundation.NSObject sender)
		{
			this.glView.Reset();
		}
		partial void termsOfUseClicked (Foundation.NSObject sender)
		{
			UIButton tappedButton = (UIButton)sender;

			TermsOfUse popupViewController = new TermsOfUse();
			popupViewController.Init();
			// popupViewController.View.Frame = new CGRect(0,0,320,200);
			popupViewController.ModalPresentationStyle = UIModalPresentationStyle.Popover;
			//	popupViewController.ContentSizeForViewInPopover = new CGSize(150, 160);
			popupViewController.PreferredContentSize = new CGSize(320, 200);

			// Present the popover from the button that was tapped in the detail view.
			this.PresentViewController(popupViewController,true, null);

			UIPopoverPresentationController popover = popupViewController.PopoverPresentationController;
			popover.Delegate = new MyPopoverDelegate();
			popover.PermittedArrowDirections = UIPopoverArrowDirection.Right;
			popover.SourceView = tappedButton;
			popover.SourceRect = tappedButton.Frame; 
			popover.PopoverLayoutMargins = new UIEdgeInsets (10,10,10,10);
		}
		partial void infoClicked (Foundation.NSObject sender)
		{
			UIButton tappedButton = (UIButton)sender;

			InfoPopupOverViewController popupViewController = new InfoPopupOverViewController();
			popupViewController.Sort = sortNameLabel.Text;
			popupViewController.Init();
			// popupViewController.View.Frame = new CGRect(0,0,320,200);
			popupViewController.ModalPresentationStyle = UIModalPresentationStyle.Popover;
			//	popupViewController.ContentSizeForViewInPopover = new CGSize(150, 160);
			popupViewController.PreferredContentSize = new CGSize(320, 200);

			// Present the popover from the button that was tapped in the detail view.
			this.PresentViewController(popupViewController,true, null);

			UIPopoverPresentationController popover = popupViewController.PopoverPresentationController;
			popover.Delegate = new MyPopoverDelegate();
			popover.PermittedArrowDirections = UIPopoverArrowDirection.Right;
			popover.SourceView = tappedButton;
			popover.SourceRect = tappedButton.Frame; 
			popover.PopoverLayoutMargins = new UIEdgeInsets (10,10,10,10);
		}

		public class MyPopoverDelegate : UIPopoverPresentationControllerDelegate
		{
			public override UIModalPresentationStyle GetAdaptivePresentationStyle (UIPresentationController forPresentationController)
			{
				return UIModalPresentationStyle.None;
			}
			public override UIModalPresentationStyle GetAdaptivePresentationStyle (UIPresentationController controller, UITraitCollection traitCollection)
			{
				return UIModalPresentationStyle.None;
			}
			/*
			public override void PrepareForPopoverPresentation (UIPopoverPresentationController popoverPresentationController)
			{
				popoverPresentationController.AdaptivePresentationStyle = () -> { return  UIModalPresentationStyle.None };
			}
			*/
		}
	}

}

