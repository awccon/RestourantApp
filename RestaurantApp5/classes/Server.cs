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


		public Server(Restaurant restaurant)
		{
			this.restaurant = restaurant;
			//this.ServerStatus = new SemaphoreSlim(2);
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
			{
				currentTable = await restaurant.GetAvailableTable();
				restaurant.Message?.Invoke("Server got a table.");
			}

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
		public TableRequest GetCurrentTable()
		{
			currentTable.CurrentTableStatus = TableStatus.Send;
			return currentTable;
		}


		/// <summary>
		/// Serves food to each customer
		/// </summary>
		/// <returns></returns>
		public void Serve(TableRequest tableList)
		{
			foreach (var item in tableList.OrderBy(c => c.Name))
			{
				var customerName = item.Name;
				var chickenCount = item.Orders.Count(c => c is Chicken);
				var eggCount = item.Orders.Count(c => c is Egg);
				var drinkCount = item.Orders.Count(c => c is Drink);
				restaurant.Message?.Invoke($"{customerName} ordered {drinkCount} drink, {eggCount} egg and {chickenCount} chicken");
			}
		}

		public void RemoveTable()
		{
			currentTable = null;
		}

		#region

		private TableRequest currentTable { get; set; } = null;
		private Restaurant restaurant;
		//public SemaphoreSlim ServerStatus;

		#endregion
	}
}

