﻿using RestaurantApp4.classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;


namespace RestaurantApp4
{
	internal class Server
	{
		TableRequest tableRequests;
		Cook cook;
		tableStatus trStatus = tableStatus.Default;

		public delegate void ReadyEvent(TableRequest table);
		public event ReadyEvent? OnSubmitEvent;
		public event Action? OnFoodServed;

		private Action<string> Printer = null;
		public Server(Action<string> printer)
		{
			this.cook = new Cook(this);
			this.tableRequests = new TableRequest(this);
			this.cook.OnProcessFinished += OnCookProcessedCooking;
			Printer = printer;
		}

		/// <summary>
		/// Submit new client orders
		/// </summary>
		/// <param name="ChickenCount"></param>
		/// <param name="EggCount"></param>
		/// <param name="Name"></param>
		/// <param name="drink"></param>
		public void SubmitNewOrder(int ChickenCount, int EggCount, string Name, listOfDrinks drink)
		{
			for (int i = 0; i < ChickenCount; i++)
			{
				tableRequests.Add<Chicken>(Name);
			}
			for (int i = 0; i < EggCount; i++)
			{
				tableRequests.Add<Egg>(Name);
			}
			switch (drink)
			{
				case listOfDrinks.Tea:
					tableRequests.Add<Tea>(Name);
					break;
				case listOfDrinks.CocaCola:
					tableRequests.Add<CocaCola>(Name);
					break;
				case listOfDrinks.Pepsi:
					tableRequests.Add<Pepsi>(Name);
					break;
			}
			trStatus = tableStatus.Submitted;
		}

		/// <summary>
		/// This method runs submit event
		/// </summary>
		/// <exception cref="Exception"></exception>
		public void SendToCook()
		{
			if (trStatus != tableStatus.Submitted)
				throw new Exception("Please submit new order");
			OnSubmitEvent?.Invoke(tableRequests);
			trStatus = tableStatus.Send;
		}

		/// <summary>
		/// This method runs when Cook processed cooking foods
		/// </summary>
		/// <returns>true once method called</returns>
		private async void OnCookProcessedCooking()
		{
			Printer?.Invoke("Cook processed an orders....");
			await Task.Delay(3000);
			ServeOrder();
		}

		/// <summary>
		/// Serves food to each customer
		/// </summary>
		/// <returns></returns>
		public async void ServeOrder()
		{
			List<string> customerOrderList = new List<string>();

			foreach (var singleCustomer in tableRequests)
			{
				int chickenCount = 0;
				int eggCount = 0;
				IMenuItem drink = null;

				foreach (var menuItem in singleCustomer)
				{
					if (menuItem is Chicken)
						chickenCount++;
					else if (menuItem is Egg)
						eggCount++;
					else
					{
						menuItem.Obtain();
						drink = menuItem;
					}

					menuItem.Serve();
				}
				Printer?.Invoke($"Customer: {singleCustomer.Name}, Drink: {drink}");
				await Task.Delay(3000);
				Printer?.Invoke($"Customer: {singleCustomer.Name}, Chicken: {chickenCount}, Egg: {eggCount}");
			}
			OnFoodServed?.Invoke();
			Printer?.Invoke("Serving customers finished successfully and tableRequest is empty");
		}
	}
}

