
using System;
using System.Drawing;

using MonoTouch.Foundation;
using MonoTouch.UIKit;
using MonoTouchPlus;

namespace Sample
{
	public partial class Sample_UIWebImageView : UIViewController
	{
		static bool UserInterfaceIdiomIsPhone {
			get { return UIDevice.CurrentDevice.UserInterfaceIdiom == UIUserInterfaceIdiom.Phone; }
		}

//		public Sample_UIWebImageView ()
//			: base (UserInterfaceIdiomIsPhone ? "Sample_UIWebImageView_iPhone" : "Sample_UIWebImageView_iPad", null)
//		{
//		}
		
		public Sample_UIWebImageView (IntPtr handle): base (handle)
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
			//var frame  = UIApplication.SharedApplication.KeyWindow.Frame;
			var frame  = this.View.Frame;

			UIWebImageView view = new UIWebImageView(new RectangleF(new PointF(0,0),frame.Size),"http://upload.wikimedia.org/wikipedia/commons/6/62/Free_American_Bison_Buffalo_on_Antelope_Island_Utah_Creative_Commons.jpg");
			//UIWebImageView view = new UIWebImageView(new RectangleF(new PointF(0,0),frame.Size),"http://2.bp.blogspot.com/_5pkoVwxuN90/TJJBfqZc5hI/AAAAAAAAC0Y/XAVYDtnk0MU/s1600/iphone-wallpaper-free-creative-commons-g1001.jpg");
			this.Add(view);
		}
		
		public override void ViewDidUnload ()
		{
			base.ViewDidUnload ();
			
			// Clear any references to subviews of the main view in order to
			// allow the Garbage Collector to collect them sooner.
			//
			// e.g. myOutlet.Dispose (); myOutlet = null;
			
			ReleaseDesignerOutlets ();
		}
		
		public override bool ShouldAutorotateToInterfaceOrientation (UIInterfaceOrientation toInterfaceOrientation)
		{
			// Return true for supported orientations
			if (UserInterfaceIdiomIsPhone) {
				return (toInterfaceOrientation != UIInterfaceOrientation.PortraitUpsideDown);
			} else {
				return true;
			}
		}
	}
}

