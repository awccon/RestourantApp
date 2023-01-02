using RestaurantApp5.classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using static System.Windows.Forms.LinkLabel;


namespace RestaurantApp5
{
	internal class Server
	{
		TableRequest tableRequests;
		List<Cook> cooks;

		private Action<string> Printer = null;
		public Server(Action<string> printer)
		{
			this.tableRequests = new TableRequest();
			this.cooks = new List<Cook>() { new Cook(9000), new Cook(12000) };
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

		/// <summary>
		/// This method runs submit event
		/// </summary>
		/// <exception cref="Exception"></exception>
		public async void SendToCook()
		{
			if (tableRequests.GetTableStatus != tableStatus.Submitted)
				throw new Exception("Please submit new order");

			if (!cooks[0].isAvailable)
			{
				Printer?.Invoke($" First Cook is available and preparing a food");
				await cooks[0].Process(tableRequests);
			}
			else if (!cooks[1].isAvailable)
			{
				Printer?.Invoke($" Second Cook is available and preparing a food");
				await cooks[1].Process(tableRequests);
			}

		}

		/// <summary>
		/// Serves food to each customer
		/// </summary>
		/// <returns></returns>
		public async void ServeOrder()
		{
			List<string> customerOrderList = new List<string>();

			foreach (var singleCustomer in tableRequests)
			{
				int chickenCount = 0;
				int eggCount = 0;
				IMenuItem drink = null;

				foreach (var menuItem in singleCustomer)
				{
					if (menuItem is Chicken)
						chickenCount++;
					else if (menuItem is Egg)
						eggCount++;
					else
					{
						menuItem.Obtain();
						drink = menuItem;
					}

					menuItem.Serve();
				}
				Printer?.Invoke($"Customer: {singleCustomer.Name}, Drink: {drink}");
				await Task.Delay(3000);
				Printer?.Invoke($"Customer: {singleCustomer.Name}, Chicken: {chickenCount}, Egg: {eggCount}");
			}
			Printer?.Invoke("Serving customers finished successfully and tableRequest is empty");
		}
	}
}

