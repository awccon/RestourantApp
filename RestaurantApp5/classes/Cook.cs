using RestaurantApp5.classes;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Sockets;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantApp5
{
	internal class Cook
	{
		public Cook(Restaurant restaurant, string name = null, int yearOfExperience = 6)
		{
			this.restaurant = restaurant;
			this.foodPrepairTime *= yearOfExperience;
			lockObj = Guid.NewGuid();
			Name = name;
		}

		/// <summary>
		/// This method gets table and prepaires a customer food
		/// </summary>
		/// <param name="tableRequests">Table request</param>
		/// <returns>prepaired orders</returns>
		/// <exception cref="Exception">throws an exception when parameter is null</exception>
		public async Task<TableRequest> Process(TableRequest tableRequests)
		{
			if (tableRequests is null)
				throw new Exception("Null tableRequests");
			
			lock (lockObj)
			{
				restaurant.Message?.Invoke($"Cook {this.Name} is processing {tableRequests.ID} tables foods");
				isAvailable = false;
				tableRequests.CurrentTableStatus = TableStatus.Processing;

				var CookableItems = tableRequests.Get<CookableFood>();

				foreach (CookableFood item in CookableItems)
				{
					item.Obtain();
					item.Cook();
				}
				tableRequests.CurrentTableStatus = TableStatus.Send;
			}
			await Task.Delay(foodPrepairTime);
			restaurant.Message?.Invoke($"Cook {this.Name} has been prepaired {tableRequests.ID} tables foods");
			isAvailable = false;
			return tableRequests;
		}

		#region
		private Restaurant restaurant { get; }
		public bool isAvailable { get; private set; } = true;
		private object lockObj;
		private readonly string Name;
		private int foodPrepairTime = 2000;
		#endregion
	}
}
