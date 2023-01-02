using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantApp5
{
	internal class Cook
	{
		public bool isAvailable = false;
		private object lockObj = "locker";
		private int prepareTime = 0;
		private TableRequest currentTable = null;
		public Cook(int preparetime) => this.prepareTime = preparetime;

		public async Task<TableRequest> Process(TableRequest tableRequests)
		{
			if (tableRequests is null)
				throw new Exception("Null tableRequests");
			
			currentTable = tableRequests;
			tableRequests.ClearCurrenttable();
			tableRequests.GetTableStatus = tableStatus.Default;
			lock (lockObj)
			{
				isAvailable = true;
				var CookableItems = currentTable.Get<CookableFood>();

				foreach (CookableFood item in CookableItems)
				{
					Thread.Sleep(prepareTime);
					item.Obtain();
					item.Cook();
				}
			}
			isAvailable = false;
			return currentTable;
		}
	}
}
