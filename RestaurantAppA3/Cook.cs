using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantAppA3
{
	internal class Cook
	{
		public void Process(TableRequest currentTable)
		{
			//var CookableItems = currentTable[typeof(CookableFood)];

			//foreach (CookableFood item in CookableItems)
			//{
			//	item.Obtain();
			//	item.Cook();
			//}

			foreach (CookableFood item in currentTable[typeof(CookableFood)])
			{
				item.Obtain();
				item.Cook();
			}
		}
	}
}
