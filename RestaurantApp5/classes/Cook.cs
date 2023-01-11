using RestaurantApp5.classes;
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
		//public bool isAvailable = false;
		private object lockObj;
		private int foodPrepairTime = 1000;

		public Cook(int yearOfExperience = 6)
		{
			this.foodPrepairTime *= yearOfExperience;
			lockObj = Guid.NewGuid();
		}

		public Task<TableRequest> Process(TableRequest tableRequests)
		{
			if (tableRequests is null)
				throw new Exception("Null tableRequests");

			lock (lockObj)
			{
				//isAvailable = true;

				//Setting table request status
				tableRequests.GetTableStatus = tableStatus.Processing;

				var CookableItems = tableRequests.Get<CookableFood>();

				foreach (CookableFood item in CookableItems)
				{
					item.Obtain();
					Task.Delay(foodPrepairTime);
					item.Cook();
				}
			}
			//isAvailable = false;
			tableRequests.GetTableStatus = tableStatus.Send;
			return Task.FromResult(tableRequests);
		}
	}
}
