using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Windows.Forms.LinkLabel;

namespace RestaurantApp4
{
	internal class Server
	{
		TableRequest newTable = new TableRequest();
		Cook chefCook = new Cook();

		public void SubmitNewOrder(int ChickenCount, int EggCount, string Name, listOfDrinks drink)
		{
			for (int i = 0; i < ChickenCount; i++)
			{
				newTable.Add<Chicken>(Name);
			}
			for (int i = 0; i < EggCount; i++)
			{
				newTable.Add<Egg>(Name);
			}
			switch (drink)
			{
				case listOfDrinks.Tea:
					newTable.Add<Tea>(Name);
					break;
				case listOfDrinks.CocaCola:
					newTable.Add<CocaCola>(Name);
					break;
				case listOfDrinks.Pepsi:
					newTable.Add<Pepsi>(Name);
					break;
			}
		}

		public void TableTest()
		{
			var singleCustomerOrders = newTable.Get<CookableFood>();
			foreach (CookableFood item in singleCustomerOrders)
			{
				item.Obtain();
				item.Cook();
				item.Serve();
			}
		}

		/// <summary>
		/// Submit new order, gets Chicken and Egg quantity and type of drink
		/// </summary>
		/// <param name="chickenCount">type integet count of item</param>
		/// <param name="eggCount">type integet count of item</param>
		/// <param name="drink">type Enum drink item</param>
		//public void GetNewOrder(int chickenCount, int eggCount, listOfDrinks drink)
		//{
		//	int clientCount = newTable.getTableLength + 1;
		//	for (int i = 0; i < chickenCount; i++)
		//	{
		//		newTable.Add(clientCount, new Chicken());
		//	}
		//	for (int i = 0; i < eggCount; i++)
		//	{
		//		newTable.Add(clientCount, new Egg());
		//	}
		//	switch (drink)
		//	{
		//		case listOfDrinks.Tea:
		//			newTable.Add(clientCount, new Tea());
		//			break;
		//		case listOfDrinks.CocaCola:
		//			newTable.Add(clientCount, new CocaCola());
		//			break;
		//		case listOfDrinks.Pepsi:
		//			newTable.Add(clientCount, new Pepsi());
		//			break;
		//	}
		//}

		//public void SendToCook()
		//{
		//	chefCook.Process(newTable);
		//}

		//public string[] PrepareFood()
		//{
		//	string[] customerOrderList = new string[0];
		//	for (int i = 0; i < newTable.getTableLength; i++)
		//	{
		//		int chickenCount = 0;
		//		int eggCount = 0;
		//		IMenuItem drink = null;
		//		foreach (var item in newTable[i])
		//		{
		//			if (item is Chicken)
		//			{
		//				chickenCount++;
		//			}
		//			else if (item is Egg)
		//			{
		//				eggCount++;
		//			}
		//			else drink = item;
		//			item.Obtain();
		//			item.Serve();
		//		}
		//		Array.Resize(ref customerOrderList, customerOrderList.Length + 1);
		//		customerOrderList[i] = $"Customer: {i}, Chicken {chickenCount}, Egg {eggCount}, Drink {drink}";
		//	}
		//	return customerOrderList;
		//}
	}
}
