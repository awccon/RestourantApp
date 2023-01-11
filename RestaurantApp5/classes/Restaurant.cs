using RestaurantApp5;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TrackBar;

namespace RestaurantApp5.classes
{
	internal class Restaurant
	{
		private List<TableRequest> tableRequestList = null;
		private List<Cook> cooks = null;

		public Restaurant()
		{
			tableRequestList = new List<TableRequest>() { new TableRequest(), new TableRequest() };
			cooks = new List<Cook>() { new Cook(8), new Cook() };
		}

		public Task<TableRequest> GetAvailableTable()
		{
			var availableTable = tableRequestList.FirstOrDefault(c => c.GetTableStatus == tableStatus.Default);
			return Task.FromResult(availableTable ?? new TableRequest());
		}


		public async Task<List<TableRequest>> SendTableToCook(TableRequest table)
		{
			if (table == null)
				throw new Exception("Please pass with tableRequest");

			List<TableRequest> listOfTables = new List<TableRequest>();
			SemaphoreSlim semaphoreSlim = new SemaphoreSlim(cooks.Count);
			Task[] tasks = new Task[cooks.Count];
			for (int i = 0; i < cooks.Count - 1; i++)
			{
				tasks[i] = Task.Run(async () =>
				{
					listOfTables.Add(await cooks[i].Process(table));
					Thread.Sleep(10000);
					semaphoreSlim.Wait();
				});
				//tasks[i].Wait();
			}
			//semaphoreSlim.Release();
			//Task.WaitAll(tasks);
			return listOfTables;

			//Task task1 = Task.Run(async () =>
			//{
			//	tables.Add(await cooks[0].Process(table));
			//	semaphoreSlim.Wait();
			//});

			//Task task2 = Task.Run(async () =>
			//{
			//	tables.Add(await cooks[2].Process(table));
			//	semaphoreSlim.Wait();
			//});






			//foreach (var cook in cooks)
			//{
			//	tables.Add(await cook.Process(table));
			//	await Task.Delay(10000);
			//	semaphoreSlim.Wait();
			//}

			//semaphoreSlim.Release();
			//for (int i = 0; i < cooks.Count; i++)
			//{
			//	tasks.Add(cooks[i].Process(table));
			//	semaphoreSlim.Wait();
			//}
			//semaphoreSlim.Release();
			//Task.WaitAll(tasks[0], tasks[1]);
			//semaphoreSlim.Dispose();
			//return tables;
		}
	}
}
