using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantApp5.classes
{
	internal class Customer : IEnumerable<IMenuItem>
	{
		public string Name { get; set; }
		public List<IMenuItem> Orders { get; set; } = new List<IMenuItem>();

		public Customer(string Name) => this.Name = Name;

		public IEnumerator<IMenuItem> GetEnumerator()
		{
			var drink = Orders.FirstOrDefault(c => c is Drink);
			if(drink != null)
			{
				yield return drink;
			}
			foreach (var food in Orders)
			{
				if(food is Drink)
				{
					continue;
				}
				yield return food;
			}
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			return GetEnumerator();
		}
	}
}
