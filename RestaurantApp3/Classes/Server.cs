using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantApp3.Classes
{
	/// <summary>
	/// Tea, CocaCola, Pepsi
	/// </summary>
	public enum drinksList
	{
		Tea,
		CocaCola,
		Pepsi
	}

	/// <summary>
	/// Server can Receive and order, Send the orders to the cook and Serve the orders to the customers.
	/// </summary>
	sealed class Server
	{
		TableRequests tableRequestObject = new TableRequests();
		Cook cookObject = new Cook();

		//CR: Status should be in TableRequest

		/// <summary>
		/// Receives count of menu items and type of drink
		/// </summary>
		/// <param name="chickenCount">integet value</param>
		/// <param name="eggCount">integet value</param>
		/// <param name="drink">gets Enum type of drinks</param>
		/// <exception cref="Exception">throws message when customer count up to 8</exception>
		public void Receive(int chickenCount, int eggCount, drinksList drink)
		{
			if (tableRequestObject.status != orderStatus.Sent)
			{
				IMenuItem DrinkItem;
				int customerCount = tableRequestObject.GetCustomerId();
				for (int i = 0; i < chickenCount; i++)
				{
					tableRequestObject.Add(customerCount, new Chicken());
				}
				for (int i = 0; i < eggCount; i++)
				{
					tableRequestObject.Add(customerCount, new Egg());
				}
				if (drink == drinksList.Tea)
				{
					DrinkItem = new Tea();
					tableRequestObject.Add(customerCount, DrinkItem);
				}
				else if (drink == drinksList.CocaCola)
				{
					DrinkItem = new CocaCola();
					tableRequestObject.Add(customerCount, DrinkItem);
				}
				else
				{
					DrinkItem = new Pepsi();
					tableRequestObject.Add(customerCount, DrinkItem);
				}
			}
			else throw new Exception("Please serve a current order");
			tableRequestObject.status = orderStatus.Ordered;
		}

		/// <summary>
		/// it will call Cook. Cook will obtain all menu items except drinks
		/// </summary>
		/// <exception cref="Exception">throws message if order not submitted and when cook completed cooking process</exception>
		public void SendToCook()
		{
			if (tableRequestObject.status == orderStatus.Ordered)
			{
				tableRequestObject.status = orderStatus.Sent;
				cookObject.Process(tableRequestObject);
			}
			else throw new Exception("Please submit an order from the customers");
		}

		/// <summary>
		/// this method will get all menu items and serve them to each customer
		/// </summary>
		/// <returns>string array of customers order info</returns>
		/// <exception cref="Exception">throws when order isn't send to the cook</exception>
		public string[] Serve()
		{
			if (tableRequestObject.status == orderStatus.Sent)
			{
				int customerCount = tableRequestObject.GetCustomerId();
				string[] customerOrdersList = new string[customerCount];

				for (int i = 0; i < customerCount - 1; i++)
				{
					IMenuItem[] eachCustomer = tableRequestObject[i];
					IMenuItem drinkItem = null;
					int chickenCount = 0, eggCount = 0;
					foreach (var item in eachCustomer)
					{
						if (item is Chicken chicken)
						{
							chickenCount++;
						}
						else if (item is Egg egg)
						{
							eggCount++;
						}
						else
						{
							item.Obtain();
							drinkItem = item;
						}
						item.Serve();
					}
					customerOrdersList[i] = $"Customer: {i}, Chicken: {chickenCount}, Egg: {eggCount}, Drinks: {drinkItem}";
				}
				customerOrdersList[customerCount - 1] = "Please enjoy your food!";
				tableRequestObject.CleanCustomersOrder();
				tableRequestObject.status = orderStatus.Served;
				GC.Collect();
				return customerOrdersList;
			}
			else throw new Exception("Please send an orders to the Cook");
		}
	}
}
