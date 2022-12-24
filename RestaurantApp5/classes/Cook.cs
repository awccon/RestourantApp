using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantApp5
{
	internal class Cook
	{
		public event Action? OnProcessFinished;

		public Cook(Server server) => server.OnSubmitEvent += table => this.Process(table);

		private async Task Process(TableRequest currentTable)
		{
			lock (currentTable)
			{
				var CookableItems = currentTable.Get<CookableFood>();

				foreach (CookableFood item in CookableItems)
				{
					item.Obtain();
					item.Cook();
				}
			}
			Thread.Sleep(3000);
			OnProcessFinished?.Invoke();
		}
	}
}
