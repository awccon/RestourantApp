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
			var CookableItems = currentTable[typeof(CookableFood)];

			foreach (CookableFood item in CookableItems)
			{
				item.Obtain();
				item.Cook();
			}

			//CookProcess(CookableItems);
		}

		//private void CookProcess(Array itemList)
		//{
		//	foreach (var item in itemList)
		//	{
		//		if (item is Chicken chicken)
		//		{
		//			chicken.Obtain();
		//			chicken.Cook();
		//		}
		//		else
		//		{
		//			var egg = item as Egg;
		//			egg.Obtain();
		//			egg.Cook();
		//		}
		//		item.
		//	}
		//}
	}
}
