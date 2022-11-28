using RestaurantApp4.classes;
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

		public delegate void ReadyEvent(TableRequest table);
		public event ReadyEvent OnSubmitEvent;

		public Server()
		{
			this.OnSubmitEvent += table => chefCook.Process(table);
			this.chefCook.OnProcessFinished += OnCookProcessedCooking;
		}

		/// <summary>
		/// Submit new client orders
		/// </summary>
		/// <param name="ChickenCount"></param>
		/// <param name="EggCount"></param>
		/// <param name="Name"></param>
		/// <param name="drink"></param>
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

		/// <summary>
		/// Serve drinks first
		/// </summary>
		/// <returns></returns>
		public List<string> ServeDrinks()
		{
			List<string> ClientDrinks = new List<string>();
			foreach (var item in newTable)
			{
				Drink drinkItem = null;
				foreach (var menuItem in item.MenuOrder)
				{
					if (menuItem is Drink drink)
					{
						drink.Obtain();
						drink.Serve();
						drinkItem = drink;
					}
				}
				ClientDrinks.Add($"Client: {item.CustomerName}, Drink: {drinkItem}");
			}
			OnSubmitEvent?.Invoke(newTable);
			return ClientDrinks;
		}


		public void OnCookProcessedCooking()
		{

		}

		//public void SendToCook()
		//{
		//	chefCook.Process(newTable);
		//}

		/// <summary>
		/// Prepares foods to each customer
		/// </summary>
		/// <returns></returns>
		public List<string> PrepareFood(string Name)
		{
			if (Name.Trim() == "")
			{
				List<string> customerOrderList = new List<string>();
				foreach (var singleCustomer in newTable)
				{
					int chickenCount = 0;
					int eggCount = 0;
					foreach (var item in singleCustomer.MenuOrder)
					{
						if (item is CookableFood food)
						{
							if (food is Chicken)
							{
								food.Obtain();
								chickenCount++;
							}
							else
							{
								var egg = food as Egg;
								food.Obtain();
								eggCount++;
							}
							food.Serve();
						}
					}
					customerOrderList.Add($"Customer: {singleCustomer.CustomerName}, Chicken {chickenCount}, Egg {eggCount}");
				}
				return customerOrderList;
			}
			else
			{
				List<string> customerOrderList = new List<string>();
				//List<IMenuItem> items = newTable[Name];
				int chickenCount = 0;
				int eggCount = 0;
				foreach (var singleCustomer in newTable[Name])
				{
					//foreach (var item in singleCustomer)
					//{
					if (singleCustomer is CookableFood food)
					{
						if (food is Chicken)
						{
							food.Obtain();
							chickenCount++;
						}
						else
						{
							var egg = food as Egg;
							food.Obtain();
							eggCount++;
						}
						food.Serve();
					}
					//}
				}
				customerOrderList.Add($"Customer: {Name}, Chicken {chickenCount}, Egg {eggCount}");
				return customerOrderList;
			}
		}
	}
}
