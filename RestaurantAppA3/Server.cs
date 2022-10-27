using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantAppA3
{
	internal class Server
	{
		TableRequest newTable = new TableRequest();
		public void GetNewOrder(int chickenCount, int eggCount, Drinks drink)
		{
			for (int i = 0; i <= chickenCount; i++)
			{
				newTable.Add(newTable.clientNuber, new Chicken());
			}
			for (int i = 0; i < eggCount; i++)
			{
				newTable.Add(newTable.clientNuber, new Egg());
			}
			switch (drink)
			{
				case Drinks.Tea:
					newTable.Add(newTable.clientNuber, new Tea());
					break;
				case Drinks.CocaCola:
					newTable.Add(newTable.clientNuber, new CocaCola());
					break;
				case Drinks.Pepsi:
					newTable.Add(newTable.clientNuber, new Pepsi());
					break;
			}
			newTable.clientNuber++;
		}

		public void PrepareFood()
		{
			var chicken = newTable[new Chicken()];
			var egg = newTable[new Egg()];
			var drink = newTable[new Tea()];
			var drink2 = newTable[new CocaCola()];
			var drink3 = newTable[new Pepsi()];
		}
	}
}
