using System;
using MonoTouch.UIKit;
using MonoTouch.Foundation;
using MonoTouch.ObjCRuntime;

namespace MonoTouchPlus
{
	public class UpdatableTableCellFactory <T> //where T : UIUpdatableTableViewCell <T>
	{
		public string cellIdentifier="";
		private string nibName;
		public UpdatableTableCellFactory (string nibName)
		{
			this.nibName = nibName;
		}
		
		public UpdatableTableCellFactory(string cellIdentifier, string nibName)
		{
			this.cellIdentifier = cellIdentifier;
			this.nibName = nibName;
		}

//		public object GetCell (UITableView tableView)
//		{
//			throw new NotImplementedException ();
//		}
		
		public UIUpdatableTableViewCell <T> GetCell(UITableView tableView)
		{
			var cell = tableView.DequeueReusableCell(cellIdentifier) as UIUpdatableTableViewCell <T>;
			
			if (cell == null)
			{
				cell = Activator.CreateInstance<UIUpdatableTableViewCell <T>>();
				var views = NSBundle.MainBundle.LoadNib(nibName, cell, null);
				cell = Runtime.GetNSObject( views.ValueAt(0) ) as UIUpdatableTableViewCell <T>;
			}
			
			return cell;
		}
	}
}

