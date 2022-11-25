using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantApp4.classes
{
	internal class Customer
	{
		public static int customerID = 0;
		public string CustomerName { get; set; }
		public List<IMenuItem> MenuOrder = new List<IMenuItem>();

		public Customer(IMenuItem item)
		{
			customerID = customerID + 1;
			MenuOrder.Add(item);
		}
	}
}
