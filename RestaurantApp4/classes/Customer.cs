using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantApp4.classes
{
	internal class Customer
	{
		private static int customerID;
		public string CustomerName { get; set; }
		public List<IMenuItem> MenuOrder = new List<IMenuItem>();
		public int id
		{
			get
			{
				return customerID;
			}
		}

		public Customer(IMenuItem item)
		{
			customerID++;
			MenuOrder.Add(item);
		}
	}
}
