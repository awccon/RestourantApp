using Microsoft.VisualBasic;
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
			this.server = new Server(restaurant: this);
			cooks.Add(new Cook(restaurant: this, name: "Stive", yearOfExperience: 10));
			cooks.Add(new Cook(restaurant: this, name: "Glenn", yearOfExperience: 8));
			Message = printer;
		}

		public int TableCount { get; private set; }

		/// <summary>
		/// Creates and inserts new table
		/// </summary>
		/// <returns>New table</returns>
		public TableRequest GetNewTable()
		{
			server.ServerLock.Wait();
			TableCount++;
			var availableTable = new TableRequest(TableCount);
			return availableTable;
		}

		public void SubmitNewOrder(int ChickenCount, int EggCount, string Name, listOfDrinks drink)
		{
			server.SubmitOrderTask(ChickenCount, EggCount, Name, drink);
		}

		/// <summary>
		/// Gets table from server, checks available cook and invokes it
		/// </summary>
		public async void SendToCook()
		{
			var currentTable = server.GetCurrentTable();
			if (currentTable != null)
			{
				Cook availableCook = null;
				server.ServerLock.Release();
				server.RemoveTable();
				await cookLock.WaitAsync();
				availableCook = cooks.FirstOrDefault(c => c.isAvailable);
				await availableCook.Process(currentTable).ContinueWith((t) =>
				{
					server.ServeTask(t.Result);
				});
				cookLock.Release();
			}
			else this.Message("Please submit new order");
		}

		#region
		private List<Cook> cooks { get; set; } = new List<Cook>();
		private Server server { get; set; }
		public Action<string> Message { get; }
		private SemaphoreSlim cookLock = new SemaphoreSlim(2);
		#endregion
	}
}
