using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantAppA3
{
	internal class TableRequest
	{
		IMenuItem[][] menuItems = new MenuItem[0][];
		public int clientNuber = 1;
		public void Add(int customerId, IMenuItem menutype)
		{
			if (menuItems.Length == customerId)
			{
				customerId = customerId - 1;
				Array.Resize(ref menuItems[customerId], menuItems[customerId].Length + 1);
				menuItems[customerId][menuItems[customerId].Length - 1] = menutype;
			}
			else
			{
				IMenuItem[] newOrder = new MenuItem[0];
				Array.Resize(ref menuItems, menuItems.Length + 1);
				menuItems[menuItems.Length - 1] = newOrder;
			}
		}

		public IMenuItem[] this[int singleCustomer]
		{
			get
			{
				return menuItems[singleCustomer];
			}
		}

		public IMenuItem[] this[Type type]
		{
			get
			{
				IMenuItem[] items = new MenuItem[0];

				foreach (var eachCustomerOrder in menuItems)
				{
					foreach (var item in eachCustomerOrder)
					{
						if (type.IsAssignableFrom(typeof(MenuItem)))
						{

						}
						//itemType = (MenuItem)itemType;
						//if (item.GetType() == itemType.GetType())
						//{
						//	Array.Resize(ref items, items.Length + 1);
						//	items[items.Length - 1] = item;
						//}
					}
				}
				return items;
			}
		}

		public int getClientId
		{
			get
			{
				return menuItems.Length;
			}
		}
	}
}
