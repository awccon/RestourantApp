using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantAppA3
{
	internal class TableRequest
	{
		IMenuItem[][] table = new MenuItem[0][];
		public int clientNumber = 1;
		public void Add(int customerId, IMenuItem menutype)
		{
			if (customerId > 8)
				throw new Exception("Range of customers up to 8, you cannot submit another order");
			if (table.Length == customerId)
			{
				customerId = customerId - 1;
				Array.Resize(ref table[customerId], table[customerId].Length + 1);
				table[customerId][table[customerId].Length - 1] = menutype;
			}
			else
			{
				Array.Resize(ref table, table.Length + 1);
				IMenuItem[] newOrder = new MenuItem[0];
				table[table.Length - 1] = newOrder;
			}
		}

		public IMenuItem[] this[int singleCustomer]
		{
			get
			{
				return table[singleCustomer];
			}
		}

		public IMenuItem[] this[IMenuItem itemType]
		{
			get
			{
				IMenuItem[] items = new MenuItem[0];

				foreach (var eachCustomerOrder in table)
				{
					foreach (var item in eachCustomerOrder)
					{
						itemType = (MenuItem)itemType;
						if (item.GetType() == itemType.GetType())
						{
							Array.Resize(ref items, items.Length + 1);
							items[items.Length - 1] = item;
						}
					}
				}
				return items;
			}
		}

		public int getClientId
		{
			get
			{
				return clientNumber;
			}
		}
		public int getTableLength
		{
			get { return table.Length; }
		}
	}
}