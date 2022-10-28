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
			var chickenObjList = currentTable[new Chicken()];
			var eggObjList = currentTable[new Egg()];
			CookProcess(chickenObjList);
			CookProcess(eggObjList);
		}

		private void CookProcess(Array itemList)
		{
			foreach (var item in itemList)
			{
				if (item is Chicken chicken)
				{
					chicken.Obtain();
					chicken.Cook();
				}
				else
				{
					var egg = item as Egg;
					egg.Obtain();
					egg.Cook();
				}
			}
		}
	}
}
