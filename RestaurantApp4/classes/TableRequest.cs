using RestaurantApp4.classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantApp4
{
	internal class TableRequest
	{
		List<Customer> table = new List<Customer>();
		private bool isNewClient = false;
		private int tableLength = 8;
		public void Add<T>(string Name) where T : IMenuItem, new()
		{
			if (table.Count > tableLength)
				throw new Exception("Range up to 8 customer per table");
			if (table.Count == 0)
			{
				table.Add(new Customer(new T()) { CustomerName = Name });
			}
			else
			{
				foreach (var item in table)
				{
					if (item.CustomerName == Name)
					{
						item.MenuOrder.Add(new T());
						isNewClient = false;
						break;
					}
					isNewClient = true;
				}
				if (isNewClient)
				{
					table.Add(new Customer(new T()) { CustomerName = Name });
				}
			}

			//IMenuItem[][] table = new MenuItem[0][];

			//public void Add(int customerId, IMenuItem menutype)
			//{
			//	if (customerId > 8)
			//		throw new Exception("Range of customers up to 8, you cannot submit another order");
			//	if (table.Length == customerId)
			//	{
			//		Array.Resize(ref table[customerId - 1], table[customerId - 1].Length + 1);
			//		table[customerId-1][table[customerId - 1].Length - 1] = menutype;
			//	}
			//	else
			//	{
			//		Array.Resize(ref table, table.Length + 1);
			//		IMenuItem[] newOrder = new IMenuItem[1] { menutype };
			//		table[table.Length - 1] = newOrder;
			//	}
			//}
		}

		public List<IMenuItem> this[string Name]
		{
			get
			{
				List<IMenuItem> singleCustomerOrders = new List<IMenuItem>();

				foreach (var singleClient in table)
				{
					if (singleClient.CustomerName == Name)
					{
						foreach (var item in singleClient.MenuOrder)
						{
							singleCustomerOrders.Add(item);
						}
					}
				}
				return singleCustomerOrders;
			}
		}


		//public IMenuItem[] this[string Name]
		//{
		//	get
		//	{
		//		IMenuItem[] singleCustomerOrders = null;

		//		foreach (var singleClient in table)
		//		{
		//			if (singleClient.CustomerName == Name)
		//			{
		//				singleCustomerOrders = new MenuItem[singleClient.MenuOrder.Count];
		//				int index = 0;
		//				foreach (var item in singleClient.MenuOrder)
		//				{
		//					singleCustomerOrders[index] = item;
		//					index++;
		//				}
		//			}
		//		}
		//		return singleCustomerOrders;
		//	}
		//}

		public List<IMenuItem> Get<T>() where T : IMenuItem
		{
			List<IMenuItem> items = new List<IMenuItem>();
			foreach (var eachCustomerOrder in table)
			{
				foreach (var item in eachCustomerOrder.MenuOrder)
				{
					if (typeof(T).IsAssignableFrom(item.GetType()))
					{
						items.Add(item);
					}
				}
			}
			return items;
		}

		//public IMenuItem[] Get<T>() where T : IMenuItem
		//{
		//	IMenuItem[] items = new MenuItem[0];
		//	foreach (var eachCustomerOrder in table)
		//	{
		//		foreach (var item in eachCustomerOrder.MenuOrder)
		//		{
		//			if (typeof(T).IsAssignableFrom(item.GetType()))
		//			{
		//				Array.Resize(ref items, items.Length + 1);
		//				items[items.Length - 1] = item;
		//			}
		//		}
		//	}
		//	return items;
		//}

		//public IMenuItem[] this[Type itemType]
		//{
		//	get
		//	{
		//		IMenuItem[] items = new MenuItem[0];
		//		foreach (var eachCustomerOrder in table)
		//		{
		//			foreach (var item in eachCustomerOrder.MenuOrder)
		//			{
		//				if (itemType.IsAssignableFrom(item.GetType()))
		//				{
		//					Array.Resize(ref items, items.Length + 1);
		//					items[items.Length - 1] = item;
		//				}
		//			}
		//		}
		//		return items;
		//	}
		//}

		//public int getTableLength
		//{
		//	get { return table.Length; }
		//}
	}
}
