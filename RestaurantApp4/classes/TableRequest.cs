using RestaurantApp4.classes;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantApp4
{
	internal class TableRequest : IEnumerable<Customer>
	{
		List<Customer> table = new List<Customer>();
		private bool isNewClient = false;
		private int tableLength = 8;

		/// <summary>
		/// Add new order
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <param name="Name"></param>
		/// <exception cref="Exception"></exception>
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

		/// <summary>
		/// Gets type of item and returns collections list
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <returns></returns>
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

		public IEnumerator<Customer> GetEnumerator()
		{
			return table.GetEnumerator();
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			return GetEnumerator();
		}
	}
}
