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
			this.ServerLock = new SemaphoreSlim(1);
		}

		/// <summary>
		/// Submit new client orders
		/// </summary>
		/// <param name="ChickenCount"></param>
		/// <param name="EggCount"></param>
		/// <param name="Name"></param>
		/// <param name="drink"></param>
		public void SubmitOrderTask(int ChickenCount, int EggCount, string Name, listOfDrinks drink)
		{
			if (currentTable == null)
			{
				currentTable = restaurant.GetNewTable();
				restaurant.Message?.Invoke($"Server got new table, table number is: {currentTable.ID}");
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
		/// Method to get submitted table
		/// </summary>
		public TableRequest GetCurrentTable()
		{
			return currentTable;
		}


		/// <summary>
		/// Serve each customer with alphabetic order
		/// </summary>
		public void ServeTask(TableRequest tableList)
		{
			ServerLock.Wait();
			restaurant.Message("_______________");
			restaurant.Message($"Server serving the table number: {tableList.ID}");
			foreach (var item in tableList.OrderBy(c => c.Name))
			{
				var customerName = item.Name;
				var chickenCount = item.Orders.Count(c => c is Chicken);
				var eggCount = item.Orders.Count(c => c is Egg);
				var drinkCount = item.Orders.Count(c => c is Drink);
				restaurant.Message?.Invoke($"{customerName} ordered {drinkCount} drink, {eggCount} egg and {chickenCount} chicken");
			}
			restaurant.Message("Server has been served the customers order");
			ServerLock.Release();
		}

		/// <summary>
		/// Removes table in server
		/// </summary>
		public void RemoveTable()
		{
			currentTable = null;
		}

		#region
		private TableRequest currentTable { get; set; } = null;
		private Restaurant restaurant;
		public SemaphoreSlim ServerLock;
		#endregion
	}
}

