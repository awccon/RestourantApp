using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantApp4.classes
{
	internal class Customer
	{
		public string Name { get; set; }
		public List<IMenuItem> MenuOrder { get; set; } = new List<IMenuItem>();

		public Customer(string Name)
		{
			this.Name = Name;
		}
	}
}
