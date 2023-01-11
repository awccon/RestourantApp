using RestaurantApp5.classes;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantApp5
{
	public enum tableStatus
	{
		Default,
		Ordered,
		Send,
		Processing
	}

	internal class TableRequest : IEnumerable<Customer>, IDisposable
	{
		List<Customer> listOfCustomers = new List<Customer>();
		private int tableLength = 8;
		public tableStatus GetTableStatus = tableStatus.Default;
		public readonly int ID;
		public TableRequest()
		{
			this.ID = new Random().Next(2);
		}

		public TableRequest(List<Customer> cutomer)
		{
			listOfCustomers = cutomer;
		}

		/// <summary>
		/// Add new order
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <param name="name"></param>
		/// <exception cref="Exception"></exception>
		public void Add<T>(string name) where T : IMenuItem, new()
		{
			if (listOfCustomers.Count > tableLength)
			{
				throw new Exception("Range up to 8 customer per table");
			}

			Customer? customer = this.listOfCustomers.FirstOrDefault(c => c.Name == name);
			if (customer == null)
			{
				customer = new Customer(name);
				listOfCustomers.Add(customer);
			}
			customer.Orders.Add(new T());
			GetTableStatus = tableStatus.Ordered;
		}

		public List<IMenuItem> this[string Name]
		{
			get
			{
				List<IMenuItem> customerOrders = new List<IMenuItem>();
				var singleCustomer = listOfCustomers.FirstOrDefault(c => c.Name == Name);
				if (singleCustomer != null)
				{
					customerOrders = singleCustomer.Orders;
				}
				return customerOrders;
			}
		}

		/// <summary>
		/// Gets type of item and returns collections list
		/// </summary>
		/// <typeparam name="T">Type of Foods or Drinks</typeparam>
		/// <returns></returns>
		public List<T> Get<T>() where T : IMenuItem
		{
			List<T> customersMenuItems = new List<T>();
			foreach (var eachCustomerOrder in listOfCustomers)
			{
				foreach (var currentMenuItem in eachCustomerOrder.Orders)
				{
					if (currentMenuItem is T a)
					{
						customersMenuItems.Add(a);
					}
				}
			}
			return customersMenuItems;
		}

		public IEnumerator<Customer> GetEnumerator()
		{
			return listOfCustomers.GetEnumerator();
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			return GetEnumerator();
		}

		//public void ClearCurrenttable()
		//{
		//	listOfCustomers.Clear();
		//}

		public void Dispose()
		{
			listOfCustomers = new List<Customer>();
		}

		~TableRequest()
		{
			Dispose();
		}

	}
}
