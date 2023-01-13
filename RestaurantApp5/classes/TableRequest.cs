using RestaurantApp5.classes;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantApp5
{
	internal class TableRequest : IEnumerable<Customer>
	{
		public TableRequest(int id)
		{
			this.ID = id;
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
			CurrentTableStatus = TableStatus.Ordered;
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

		#region
		private List<Customer> listOfCustomers { get; set; } = new List<Customer>();
		private const int tableLength = 8;
		public TableStatus CurrentTableStatus = TableStatus.Default;
		public readonly int ID;
		#endregion
	}

	public enum TableStatus
	{
		Default,
		Ordered,
		Send,
		Processing,
		Processed
	}
}
