using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantApp3.Classes
{
	public enum drinksList
	{
		Tea,
		CocaCola,
		Pepsi
	}

	public enum orderStatus
	{
		Ordered,
		Sent,
		Served
	}

	sealed class Server
	{

		TableRequests tr = new TableRequests();
		Cook ck = new Cook();
		private int customerID = 1;
		orderStatus status;
		public void Receive(int chickenCount, int eggCount, drinksList drink)
		{
			if (status != orderStatus.Sent)
			{
				if (tr.orderStore.Length < 8)
				{
					if (chickenCount >= 0 || eggCount >= 0)
					{
						Drinks item;
						for (int i = 0; i < chickenCount; i++)
						{
							tr.Add(customerID, new Chicken());
						}
						for (int i = 0; i < eggCount; i++)
						{
							tr.Add(customerID, new Egg());
						}
						if (drink == drinksList.Tea)
						{
							item = new Tea();
							tr.Add(customerID, item);
						}
						else if (drink == drinksList.CocaCola)
						{
							item = new CocaCola();
							tr.Add(customerID, item);
						}
						else
						{
							item = new Pepsi();
							tr.Add(customerID, item);
						}
						customerID++;
					}
				}
				else { throw new Exception("Range of customers up to 8"); }
			}
			status = orderStatus.Ordered;
		}

		public void Obtain()
		{
			if (status == orderStatus.Ordered)
			{
				status = orderStatus.Sent;
				ck.Process(tr);
			}
			else throw new Exception("Please submit an order from the customers");
		}

		public string[] Serve()
		{
			if (status == orderStatus.Sent)
			{
				string[] orderResutl = new string[customerID];

				for (int i = 0; i < customerID - 1; i++)
				{
					var eachCustomer = tr[i];
					int chickenCount = 0, eggCount = 0;
					string DisposedCount = "";
					MenuItem drink = null;
					foreach (var item in eachCustomer)
					{
						if (item is Chicken chicken)
						{
							chicken.Serve();
							chickenCount++;
						}
						else if (item is Egg egg)
						{
							egg.Serve();
							eggCount++;
							DisposedCount = egg.ToString();
						}
						else
						{
							item.Serve();
							drink = item;
						}
					}
					orderResutl[i] = $"Customer: {i}, Chicken: {chickenCount}, Egg: {eggCount} 'Dispose' {DisposedCount}, Drinks: {drink.ToString()}";
				}
				orderResutl[customerID - 1] = "Please enjoy your food!";
				customerID = 1;
				tr.orderStore = new MenuItem[0][];
				status = orderStatus.Served;
				return orderResutl;
			}
			else throw new Exception("Please send an orders to the Cook");
		}
	}
}
