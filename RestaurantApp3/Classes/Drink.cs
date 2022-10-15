using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantApp3.Classes
{
	abstract class Drink : MenuItem
	{
		public override string ToString()
		{
			return this.GetType().Name;
		}

	}

	sealed class Tea : Drink
	{

	}

	sealed class CocaCola : Drink
	{

	}

	sealed class Pepsi : Drink
	{

	}
}
