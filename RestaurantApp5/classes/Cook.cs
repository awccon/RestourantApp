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
			lock (lockObj)
			{
				isAvailable = false;
				restaurant.Message?.Invoke($"Cook: {this.Name} got table number: {tableRequests.ID}");
				var CookableItems = tableRequests.Get<CookableFood>();

				foreach (CookableFood item in CookableItems)
				{
					item.Obtain();
					item.Cook();
				}
			}
			await Task.Delay(foodPrepairTime);
			restaurant.Message?.Invoke($"Cook: {this.Name} processed foods table number: {tableRequests.ID}");
			isAvailable = true;
			return tableRequests;
		}

		#region
		private Restaurant restaurant { get; }
		public bool isAvailable { get; private set; } = true;
		private object lockObj;
		private readonly string Name;
		private int foodPrepairTime = 1500;
		#endregion
	}
}
