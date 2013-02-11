//http://code.google.com/p/cookbooksamples/downloads/detail?name=C08%20-%20Controls.zip&can=2&q=
using System;
using MonoTouch.UIKit;
using MonoTouch.Foundation;

namespace MonoTouchPlus
{
	[Register("UICustomSwitch")]
	public class UICustomSwitch: UISwitch
	{
		public UICustomSwitch ():base()
		{
		}
		public UICustomSwitch (IntPtr handle) : base (handle)
		{
		}

		public _UISwitchSlider slider()
		{
			//return [[self subviews] lastObject]; 
			return (_UISwitchSlider)this.Subviews[ this.Subviews.Length];
		}
		private UIView textHolder ()
		{
			//return [[[self slider] subviews] objectAtIndex:2]; 
			return this.slider().Subviews[2]; 
		}

		public UILabel LeftLabelText 
		{
			get { return (UILabel)this.textHolder().Subviews[0];  }
			//set { this.LeftLabelText.Text = value; }
		}
		
		public UILabel RightLabelText 
		{
			get { return (UILabel)this.textHolder().Subviews[1];  }
			//set { this.LeftLabelText.Text = value; }
		}

//		public UILabel getLeftLabelText()
//		{
//			//return [[[self textHolder] subviews] objectAtIndex:0]; 
//			return (UILabel)this.textHolder().Subviews[0];
//		}
//		public UILabel getRightLabelText()
//		{
//			//return [[[self textHolder] subviews] objectAtIndex:0]; 
//			return (UILabel)this.textHolder().Subviews[0];
//		}
////		- (void) setLeftLabelText: (NSString *) labelText { 
////			[[self leftLabel] setText:labelText]; 
////		}
////		- (void) setRightLabelText: (NSString *) labelText { 
////			[[self rightLabel] setText:labelText]; 
////		}
//		public void setLeftLabelText( String labelText )
//		{
//			//return [[[self textHolder] subviews] objectAtIndex:0]; 
//			this.getLeftLabelText().Text = labelText;
//		}
//		public void setRightLabelText( String labelText )
//		{
//			//return [[[self textHolder] subviews] objectAtIndex:0]; 
//			return this.getRightLabelText().Text = labelText;
//		}
		


	}

	public class _UISwitchSlider : UIView
	{

	}

	
//	public class UISwitchExtensions
//	{
//		//- (void) setAlternateColors:(BOOL) boolean;
//
////		bool AlternateColors
////		{
////			set { base.alternate colr}
////		}
//	}
}

