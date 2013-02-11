using System;
using MonoTouch.UIKit;
using System.Collections.Generic;
using MonoTouch.Foundation;
using MonoTouch.ObjCRuntime;

namespace MonoTouchPlus
{
	//public class ListTableSource <T , I >: UITableViewSource where I : UIUpdatableTableViewCell<T>//<T> where T : UIUpdatableTableViewCell //
	public class ListTableSource <T>: UITableViewSource 
	{
		private List<T> list=new List<T>();

//		private UpdatableTableCellFactory<I> cellFactory ;//= new TableCellFactory<T>("CustomCell2_ID", "CustomCell2");
		private UpdatableTableCellFactory<T> cellFactory ;

		String nibName;

		string cellIdentifier = "";

		//UIUpdatableTableViewCell<T> defaultCell  ;

		public ListTableSource (List<T> list, String nibName)
		{
			if (nibName == null) {
				Console.WriteLine ("nibName argument in constructor is null");
				throw new ArgumentNullException ("nibName");
			}
//			if (nibName != null) {
			this.nibName = nibName;
//			} else {
//				throw new ArgumentNullException ("nibName");
//			}
			if ( list != null ) 
				this.list = list;
		}
		public ListTableSource (List<T> list, String nibName, String cellIdentifier) //: this(
		{
			if (cellIdentifier == null) {
				throw new ArgumentNullException ("cellIdentifier");
			}
			this.cellIdentifier = cellIdentifier;
			if (nibName == null) {
				Console.WriteLine ("nibName argument in constructor is null");
				throw new ArgumentNullException ("nibName");
			}
			//			if (nibName != null) {
			this.nibName = nibName;
			//			} else {
			//				throw new ArgumentNullException ("nibName");
			//			}
			if ( list != null ) 
				this.list = list;
		}
		
//		public ListTableSource (List<T> list,  UpdatableTableCellFactory<I> cellFactory) 
//		{
//			if (cellFactory == null)
//				Console.WriteLine("cellFactory argument in constructor is null");
//
//			this.cellFactory = cellFactory;
//
//			if ( list != null ) 
//				this.list = list;
//		}

		public override int RowsInSection(UITableView tableview, int section)
		{
			return list.Count;
		}
		
		public override int NumberOfSections(UITableView tableView)
		{
			return 1;
		}
		
//		public override string TitleForHeader(UITableView tableView, int section)
//		{
//			return "Section " + section;
//		}
		
		public override UITableViewCell GetCell (UITableView tableView, NSIndexPath indexPath)
		{
			String cellId = ( cellFactory != null ) ? cellFactory.cellIdentifier : cellIdentifier;
			UIUpdatableTableViewCell<T> cell = tableView.DequeueReusableCell (cellId ) as UIUpdatableTableViewCell<T>;

			//cell = defaultCell ;
//			if ( nibName != null )
//			{
				//var cell = tableView.DequeueReusableCell("CustomCell1_ID") as CustomCell1;

				
			if (cell == null) {
				//cell = new UIUpdatableTableViewCell<T> ();
				if ( nibName != null )
				{
				var views = NSBundle.MainBundle.LoadNib (nibName, cell, null);
				cell = Runtime.GetNSObject (views.ValueAt (0)) as UIUpdatableTableViewCell<T>;
				}
				else if (cellFactory != null)
				{
					cell = cellFactory.GetCell(tableView);
				}
				//cell.set
			}
//			}
//			else if (cellFactory != null)
//			{
//				var cell = cellFactory.GetCell(tableView);
//			}
			cell.Update(list[indexPath.Row]);
			
			return cell;
		}
	}
}

