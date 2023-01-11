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
		private TableRequest currentTable = null;
		private List<TableRequest> tableList = null;
		private Restaurant restaurant;
		private Action<string> Printer = null;

		public Server(Action<string> printer)
		{
			restaurant = new Restaurant();
			Printer = printer;
		}

		/// <summary>
		/// Submit new client orders
		/// </summary>
		/// <param name="ChickenCount"></param>
		/// <param name="EggCount"></param>
		/// <param name="Name"></param>
		/// <param name="drink"></param>
		public async void SubmitNewOrder(int ChickenCount, int EggCount, string Name, listOfDrinks drink)
		{
			if (currentTable == null)
				currentTable = await restaurant.GetAvailableTable();

			for (int i = 0; i < ChickenCount; i++)
			{
				currentTable.Add<Chicken>(Name);
			}
			for (int i = 0; i < EggCount; i++)
			{
				currentTable.Add<Egg>(Name);
			}
			switch (drink)
			{
				case listOfDrinks.Tea:
					currentTable.Add<Tea>(Name);
					break;
				case listOfDrinks.CocaCola:
					currentTable.Add<CocaCola>(Name);
					break;
				case listOfDrinks.Pepsi:
					currentTable.Add<Pepsi>(Name);
					break;
			}
		}

		/// <summary>
		/// This method runs submit event
		/// </summary>
		/// <exception cref="Exception"></exception>
		public async void SendToCook()
		{
			try
			{
				currentTable.GetTableStatus = tableStatus.Send;
				tableList = await restaurant.SendTableToCook(currentTable);
				currentTable = null;
			}
			catch (Exception ex)
			{
				Printer?.Invoke(ex.Message);
			}
			finally
			{
				Printer?.Invoke("Has been finished");
			}


			//if (tableRequests.GetTableStatus != tableStatus.Ordered)
			//	throw new Exception("Please submit new order");

			//if (!cooks[0].isAvailable)
			//{
			//	Printer?.Invoke($" First Cook is available and preparing a food");
			//	var ss = await cooks[0].Process(tableRequests); // in this code we are awaiting this method and taking returned object from current cook

			//}
			//else if (!cooks[1].isAvailable)
			//{
			//	Printer?.Invoke($" Second Cook is available and preparing a food");
			//	await cooks[1].Process(tableRequests);
			//}
		}

		/// <summary>
		/// Serves food to each customer
		/// </summary>
		/// <returns></returns>
		//public async void ServeOrder()
		//{
		//	List<string> customerOrderList = new List<string>();

		//	foreach (var singleCustomer in tableList)
		//	{
		//		int chickenCount = 0;
		//		int eggCount = 0;
		//		IMenuItem drink = null;

		//		foreach (var menuItem in singleCustomer)
		//		{
		//			if (menuItem is Chicken)
		//				chickenCount++;
		//			else if (menuItem is Egg)
		//				eggCount++;
		//			else
		//			{
		//				menuItem.Obtain();
		//				drink = menuItem;
		//			}

		//			menuItem.Serve();
		//		}
		//		Printer?.Invoke($"Customer: {singleCustomer.Name}, Drink: {drink}");
		//		await Task.Delay(3000);
		//		Printer?.Invoke($"Customer: {singleCustomer.Name}, Chicken: {chickenCount}, Egg: {eggCount}");
		//	}
		//	Printer?.Invoke("Serving customers finished successfully and tableRequest is empty");
		//}
	}
}

