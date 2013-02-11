using System;
using MonoTouch.Foundation;
using MonoTouch.UIKit;
//using MonoTouch.Dialog;
using System.Drawing;
using MonoTouch.CoreGraphics;

namespace MonoTouchPlus
{
	
	public static class UIViewExtensions
	{
		public static void DrawRoundRectangle(this UIView view, RectangleF rrect, float radius, UIColor color)
		{
			var context = UIGraphics.GetCurrentContext();
			
			color.SetColor();
			
			float minx = rrect.Left;
			float midx = rrect.Left + (rrect.Width) / 2;
			float maxx = rrect.Right;
			float miny = rrect.Top;
			float midy = (rrect.Y + rrect.Size.Width) / 2;
			float maxy = rrect.Bottom;
			
			context.MoveTo(minx, midy);
			context.AddArcToPoint(minx, miny, midx, miny, radius);
			context.AddArcToPoint(maxx, miny, maxx, midy, radius);
			context.AddArcToPoint(maxx, maxy, midx, maxy, radius);
			context.AddArcToPoint(minx, maxy, minx, midy, radius);
			context.ClosePath();
			context.DrawPath(CGPathDrawingMode.Fill); // test others?
		}
		
		public static void FillRoundedRectangle(this UIView view, RectangleF rect, float radius, UIColor color)
		{
			//UIGraphics.BeginImageContext (image.Size);
			float imgWidth = rect.Width;
			float imgHeight = rect.Height;
			
			var c = UIGraphics.GetCurrentContext();
			
			c.BeginPath();
			c.MoveTo(imgWidth, imgHeight / 2);
			c.AddArcToPoint(imgWidth, imgHeight, imgWidth / 2, imgHeight, radius);
			c.AddArcToPoint(0, imgHeight, 0, imgHeight / 2, radius);
			c.AddArcToPoint(0, 0, imgWidth / 2, 0, radius);
			c.AddArcToPoint(imgWidth, 0, imgWidth, imgHeight / 2, radius);
			c.ClosePath();
			//c.Clip ();
			
			c.SetFillColor(1, 1, 1, 1);
			c.FillPath();
			//image.Draw (new PointF (0, 0));
			//converted = UIGraphics.GetImageFromCurrentImageContext ();
			// UIGraphics.EndImageContext ();
		}
	}
}
