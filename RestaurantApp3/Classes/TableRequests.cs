using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantApp3.Classes
{
	/// <summary>
	/// Usefull to set the status of order:
	/// Served, Sent, Ordered
	/// </summary>
	public enum orderStatus
	{
		Ordered,
		Sent,
		Served
	}

	/// <summary>
	/// it can get an orders with method Add, returns an orders with customer id and menu item
	/// </summary>
	internal class TableRequests
	{
		private int customerID = 1;
		private MenuItem[][] customerOrders = new MenuItem[0][];
		public orderStatus status;

		/// <summary>
		/// This method gets customer id and type of menu item and saves to array
		/// </summary>
		/// <param name="customerId"></param>
		/// <param name="menuItem"></param>
		public void Add(int customerId, IMenuItem menuItem)
		{
			//cr: fix this
			if (customerID <= 2)
			{
				MenuItem[] customerMenuItems;
				if (customerOrders.Length >= customerId)
				{
					customerMenuItems = customerOrders[customerId - 1];
				}
				else
				{
					customerMenuItems = new MenuItem[0];
					customerID++;
				}
				if (customerOrders.Length != customerId)
				{
					Array.Resize(ref customerOrders, customerId);
				}
				Array.Resize(ref customerMenuItems, customerMenuItems.Length + 1);
				customerMenuItems[customerMenuItems.Length - 1] = (MenuItem)menuItem;
				customerOrders[customerId - 1] = customerMenuItems;
			}
			else throw new Exception("Range of customers up to 8");
		}

		/// <summary>
		/// indexer for each customer order
		/// </summary>
		/// <param name="customerID">integer value from 1 to 8</param>
		/// <returns>each customer order</returns>
		public MenuItem[] this[int customerID]
		{
			get
			{
				return customerOrders[customerID];
			}
		}

		/// <summary>
		/// indexer for each menu item
		/// </summary>
		/// <param name="menuItemType">gets new instance of menu item</param>
		/// <returns>array of menu items</returns>
		public MenuItem[] this[Type menuItemType]
		{
			get
			{
				MenuItem[] orderItems = new MenuItem[0];
				foreach (var singleCustomerOrder in customerOrders)
				{
					foreach (var customerOrder in singleCustomerOrder)
					{
						if (menuItemType.IsAssignableFrom(customerOrder.GetType()))
						{
							Array.Resize(ref orderItems, orderItems.Length + 1);
							orderItems[orderItems.Length - 1] = customerOrder;
						}
					}
				}
				return orderItems;
			}
		}


		/// <summary>
		/// this method cleans all customers orders from main list
		/// </summary>
		public void CleanCustomersOrder()
		{
			customerID = 1;
			customerOrders = new MenuItem[0][];
		}

		public int GetCustomerId()
		{
			return customerID;
		}
	}
}
