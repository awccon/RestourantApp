using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantApp3.Classes
{
	sealed class Cook
	{
		public void Process(TableRequests tableRequests)
		{
			var chick = tableRequests[typeof(Chicken)];

			var egg = tableRequests[typeof(Egg)];

			foreach (var eggItem in egg)
			{
				var eg = (Egg)eggItem;
				eg.Obtain();
				eg.Cook();

			}


			foreach (var ch in chick)
			{
				var chicken = (Chicken)ch;
				chicken.Obtain();
				chicken.Cook();
			}

			throw new Exception("Cooking foods completed.......");
		}
	}
}
