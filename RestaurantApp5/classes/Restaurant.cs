using RestaurantApp5;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TrackBar;

namespace RestaurantApp5.classes
{
	internal class Restaurant : IRestaurant
	{
		public Restaurant(Action<string> printer)
		{
			this.server = new Server(this);
			tableRequestList = new List<TableRequest>();
			cooks.Add(new Cook(this, name: "Stive", yearOfExperience: 25));
			cooks.Add(new Cook(this, name: "Glenn", yearOfExperience: 10));
			Message = printer;
		}

		/// <summary>
		/// Finds available table if it's available or it will create a new table
		/// </summary>
		/// <returns>Current or new Table</returns>
		public Task<TableRequest> GetAvailableTable()
		{
			Message?.Invoke("Restaurant is checking available table....");
			var availableTable = tableRequestList.FirstOrDefault(c => c.CurrentTableStatus == TableStatus.Default);
			if (availableTable == null)
			{
				availableTable = new TableRequest(this.tableRequestList.Count + 1);
				tableRequestList.Add(availableTable);
			}
			Message?.Invoke($"Available Table provided, table number is: {availableTable.ID}");
			return Task.FromResult(availableTable);
		}

		public void SubmitNewOrder(int ChickenCount, int EggCount, string Name, listOfDrinks drink)
		{
			this.server.SubmitNewOrder(ChickenCount, EggCount, Name, drink);
		}

		/// <summary>
		/// Gets table from server, checks available cook and invokes it
		/// </summary>
		public async void SendTableToCook()
		{
			await semaphore.WaitAsync();
			TableRequest? currentTable = server.GetCurrentTable();
			var currentCook = cooks.FirstOrDefault(c => c.isAvailable == true);
			if (currentCook != null)
			{
				server.RemoveTable();
				var prepairedFood = await currentCook.Process(currentTable);
				currentTable = null;
				server.Serve(prepairedFood);
				DiscardCurrentTable(prepairedFood);
			}
			semaphore.Release();
		}

		private void DiscardCurrentTable(TableRequest currentTable)
		{
			this.tableRequestList.Remove(currentTable);
		}

		#region
		private List<TableRequest> tableRequestList { get; set; } = null;
		private List<Cook> cooks { get; set; } = new List<Cook>();
		private Server server { get; set; }
		public Action<string> Message { get; }
		private SemaphoreSlim semaphore = new SemaphoreSlim(2);
		//private SemaphoreSlim semaphore2 = new SemaphoreSlim(2);
		private Task task { get; set; }
		#endregion
	}
}
