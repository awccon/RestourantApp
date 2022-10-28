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
		Cook chefCook = new Cook();

		/// <summary>
		/// Submit new order, gets Chicken and Egg quantity and type of drink
		/// </summary>
		/// <param name="chickenCount">type integet count of item</param>
		/// <param name="eggCount">type integet count of item</param>
		/// <param name="drink">type Enum drink item</param>
		public void GetNewOrder(int chickenCount, int eggCount, Drinks drink)
		{
			for (int i = 0; i <= chickenCount; i++)
			{
				newTable.Add(newTable.getClientId, new Chicken());
			}
			for (int i = 0; i < eggCount; i++)
			{
				newTable.Add(newTable.getClientId, new Egg());
			}
			switch (drink)
			{
				case Drinks.Tea:
					newTable.Add(newTable.getClientId, new Tea());
					break;
				case Drinks.CocaCola:
					newTable.Add(newTable.getClientId, new CocaCola());
					break;
				case Drinks.Pepsi:
					newTable.Add(newTable.getClientId, new Pepsi());
					break;
			}
			newTable.clientNumber++;
		}

		public void SendToCook()
		{
			chefCook.Process(newTable);
		}

		public string[] PrepareFood()
		{
			string[] customerOrderList = new string[0];
			for (int i = 0; i < newTable.getTableLength; i++)
			{
				int chickenCount = 0;
				int eggCount = 0;
				IMenuItem drink = null;
				foreach (var item in newTable[i])
				{
					if (item is Chicken)
					{
						chickenCount++;
					}
					else if (item is Egg)
					{
						eggCount++;
					}
					else drink = item;
					item.Obtain();
					item.Serve();
				}
				Array.Resize(ref customerOrderList, customerOrderList.Length + 1);
				customerOrderList[i] = $"Customer: {i}, Chicken {chickenCount}, Egg {eggCount}, Drink {drink}";
			}
			return customerOrderList;
		}
	}
}
