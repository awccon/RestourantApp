using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantApp4.classes
{
	internal class Customer
	{
		public int customerID = 0;
		public string NameOfCustomer { get; set; }
		public List<IMenuItem> MenuOrder = new List<IMenuItem>();

		public Customer(IMenuItem item)
		{
			customerID++;
			MenuOrder.Add(item);
		}
	}
}
