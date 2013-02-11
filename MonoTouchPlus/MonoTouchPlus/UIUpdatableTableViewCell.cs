using System;
using MonoTouch.UIKit;

namespace MonoTouchPlus
{
	public abstract class UIUpdatableTableViewCell <T> : UITableViewCell
	{
		public UIUpdatableTableViewCell ()
		{
			//throw new NotImplementedException ();
		}

//		public UIUpdatableTableViewCell ()
//		{
//		}
		
		public abstract void Update( T element);
//		{
//			mainLabel.Text = "This is row " + indexPath.Row;
//			subLabel.Text = "... and section " + indexPath.Section;
//		}
	}
}

