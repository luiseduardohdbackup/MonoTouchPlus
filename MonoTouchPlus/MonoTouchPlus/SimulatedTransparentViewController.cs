using System;

using MonoTouch.Foundation;
using MonoTouch.UIKit;
using System.Collections.Generic;
using MonoTouchPlus;
using System.Drawing;

namespace MonoTouchPlus
{
	
	[Register("SimulatedTransparentViewController")]
	public class SimulatedTransparentViewController : UIViewController
	{
		//http://stackoverflow.com/questions/587681/how-to-use-presentmodalviewcontroller-to-create-a-transparent-view
		public SimulatedTransparentViewController (IntPtr handle) : base (handle)
		{
			Console.Out.WriteLine("SimulatedTransparentViewController");
		}

		public SimulatedTransparentViewController (String  nibName, NSBundle bundle) : base (nibName,bundle)
		{
			Console.Out.WriteLine("SimulatedTransparentViewController");
		}
		public override void LoadView ()
		{
			base.LoadView();

			/*
			 * UIGraphicsBeginImageContext(objAppDelegate.window.frame.size);
    [objAppDelegate.window.layer renderInContext:UIGraphicsGetCurrentContext()];
    UIImage *viewImage = UIGraphicsGetImageFromCurrentImageContext();
    UIGraphicsEndImageContext();

    UIViewController *controllerForBlackTransparentView=[[[UIViewController alloc] init] autorelease];
    [controllerForBlackTransparentView setView:viewForProfanity];

    UIImageView *imageForBackgroundView=[[UIImageView alloc] initWithFrame:CGRectMake(0, -20, 320, 480)];
    [imageForBackgroundView setImage:viewImage];

    [viewForProfanity insertSubview:imageForBackgroundView atIndex:0];

    [self.navigationController presentModalViewController:controllerForBlackTransparentView animated:YES];
			 */
			
			UIGraphics.BeginImageContext( UIApplication.SharedApplication.Delegate.Window.Frame.Size );
			UIApplication.SharedApplication.Delegate.Window.Layer.RenderInContext(UIGraphics.GetCurrentContext());
			UIImage image = UIGraphics.GetImageFromCurrentImageContext();
			UIGraphics.EndImageContext();
			
			//backgroundImageView = new UIImageView(new RectangleF(0,-20,320,480));
			//backgroundImageView = new UIImageView(new RectangleF(0,-20,this.View.Frame.Width,this.View.Frame.Height));
			//backgroundImageView = new UIImageView(new RectangleF(0,0,this.View.Frame.Width,this.View.Frame.Height));
			var width =UIApplication.SharedApplication.Delegate.Window.Frame.Width;
			var height =UIApplication.SharedApplication.Delegate.Window.Frame.Height;
			backgroundImageView = new UIImageView(new RectangleF(0,-20,width,height));
			backgroundImageView.Image=image;
			
		}
		public UIImageView backgroundImageView;
		public UIView transparentBlankMask;
		
		public override void ViewDidAppear (bool animated)
		{
			Console.Out.WriteLine ("ViewDidAppear");
			
			this.View.InsertSubview(backgroundImageView,0);
			transparentBlankMask = new UIView(backgroundImageView.Frame);
			transparentBlankMask.BackgroundColor = UIColor.Black;
			transparentBlankMask.Alpha = 0.0f;
			this.View.InsertSubview(transparentBlankMask,1);
			
			UIView.BeginAnimations("transparentBlankMask");
			UIView.SetAnimationDuration( 1.00);
			transparentBlankMask.Alpha = 0.75f;
			UIView.CommitAnimations();
		}
		
		
		public override void DismissViewController (bool animated, NSAction completionHandler)
		{
			backgroundImageView.RemoveFromSuperview();
			transparentBlankMask.RemoveFromSuperview();
			base.DismissViewController(animated, completionHandler);
		}
	}
}
