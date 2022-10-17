using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantApp3.Classes
{
	sealed class Cook
	{
		/// <summary>
		/// method can get item and process them
		/// </summary>
		/// <param name="tableRequests">List of customer orders</param>
		/// <exception cref="Exception">cooking foods completed message</exception>
		public void Process(TableRequests tableRequests)
		{
			//CR: Can we simplify code in this method?
			IMenuItem[] chickenList = tableRequests[typeof(Chicken)];
			IMenuItem[] eggList = tableRequests[typeof(Egg)];

			foreach (var EggItem in eggList)
			{
				Egg egg = (Egg)EggItem;
				egg.Obtain();
				egg.Cook();
			}

			foreach (var ChickenItem in chickenList)
			{
				Chicken chicken = (Chicken)ChickenItem;
				chicken.Obtain();
				chicken.Cook();
			}

			throw new Exception("Cooking foods completed.......");
		}
	}
}
