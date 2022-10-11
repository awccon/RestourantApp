using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantApp3.Classes
{
	internal class TableRequests
	{
		public MenuItem[][] orderStore = new MenuItem[0][];

		public void Add(int customerId, IMenuItem menuItem)
		{
			MenuItem[] customerMenuItems = null;
			if (orderStore.Length >= customerId)
			{
				customerMenuItems = orderStore[customerId-1];
			}
			else {
				customerMenuItems = new MenuItem[0];
			}
			if (orderStore.Length != customerId)
			{
				Array.Resize(ref orderStore, customerId);
			}
			Array.Resize(ref customerMenuItems, customerMenuItems.Length + 1);
			customerMenuItems[customerMenuItems.Length - 1] = (MenuItem)menuItem;
			orderStore[customerId-1] = customerMenuItems;
		}


		public MenuItem[] this[int customerID]
		{
			get
			{
				return orderStore[customerID];
			}
		}
		public MenuItem[] this[Type menuItemType]
		{
			get
			{
				MenuItem[] orderItems = new MenuItem[0];
				foreach (var singleCustomerOrder in orderStore)
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
	}
}
