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
		TableRequest tableRequests = new TableRequest();
		Cook cook;

		public delegate void ReadyEvent(TableRequest table);
		public event ReadyEvent? OnSubmitEvent;

		public Server()
		{
			this.cook = new Cook(this);
			this.cook.OnProcessFinished += OnCookProcessedCooking;
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
				tableRequests.Add<Chicken>(Name);
			}
			for (int i = 0; i < EggCount; i++)
			{
				tableRequests.Add<Egg>(Name);
			}
			switch (drink)
			{
				case listOfDrinks.Tea:
					tableRequests.Add<Tea>(Name);
					break;
				case listOfDrinks.CocaCola:
					tableRequests.Add<CocaCola>(Name);
					break;
				case listOfDrinks.Pepsi:
					tableRequests.Add<Pepsi>(Name);
					break;
			}
			OnSubmitEvent?.Invoke(tableRequests);
		}

		public void OnCookProcessedCooking()
		{

		}

		/// <summary>
		/// Prepares foods to each customer
		/// </summary>
		/// <returns></returns>
		public List<string> PrepareFood()
		{
			List<string> customerOrderList = new List<string>();
			foreach (var singleCustomer in tableRequests)
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
				customerOrderList.Add($"Customer: {singleCustomer.Name}, Chicken {chickenCount}, Egg {eggCount}");
			}
			return customerOrderList;
		}
	}
}
