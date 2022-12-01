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
		private Action<string> Printer = null;
		public Server(Action<string> printer)
		{
			this.cook = new Cook(this);
			this.cook.OnProcessFinished += OnCookProcessedCooking;
			Printer = printer;
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
		}

		public void SendToCook()
		{
			OnSubmitEvent?.Invoke(tableRequests);
		}

		/// <summary>
		/// This method runs when Cook processed cooking foods
		/// </summary>
		/// <returns>true once method called</returns>
		private void OnCookProcessedCooking()
		{
			 ServeOrder();
		}

		/// <summary>
		/// Prepares foods to each customer
		/// </summary>
		/// <returns></returns>
		public void ServeOrder()
		{
			List<string> customerOrderList = new List<string>();

			foreach (var singleCustomer in tableRequests)
			{
				int chickenCount = 0;
				int eggCount = 0;
				foreach (var item in singleCustomer.Orders)
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
				Printer?.Invoke($"Customer: {singleCustomer.Name}, Chicken {chickenCount}, Egg {eggCount}");
			}
		}
	}
}
