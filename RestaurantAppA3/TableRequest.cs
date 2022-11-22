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

		public void Add(int customerId, IMenuItem menutype)
		{
			if (customerId > 8)
				throw new Exception("Range of customers up to 8, you cannot submit another order");
			if (table.Length == customerId)
			{
				Array.Resize(ref table[customerId - 1], table[customerId - 1].Length + 1);
				table[customerId-1][table[customerId - 1].Length - 1] = menutype;
			}
			else
			{
				Array.Resize(ref table, table.Length + 1);
				IMenuItem[] newOrder = new IMenuItem[1] { menutype };
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

		public IMenuItem[] this[Type itemType]
		{
			get
			{
				IMenuItem[] items = new MenuItem[0];
				foreach (var eachCustomerOrder in table)
				{
					foreach (var item in eachCustomerOrder)
					{
						if (itemType.IsAssignableFrom(item.GetType()))
						{
							Array.Resize(ref items, items.Length + 1);
							items[items.Length - 1] = item;
						}
					}
				}
				return items;
			}
		}

		public int getTableLength
		{
			get { return table.Length; }
		}
	}
}