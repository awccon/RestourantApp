using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestourantAppA1
{
	internal class Server
	{
		public object currentOrder = null;
		private int newRequestCount = 0;
		public object NewRequest(int orderQuantity, string orderType)
		{
			object menuItem;
			if (newRequestCount % 3 == 0)
			{
				menuItem = (orderType == "Chicken") ? new ChickenOrder(orderQuantity) : new EggOrder(orderQuantity);
			}
			else
			{
				menuItem = (orderType == "Chicken") ? new EggOrder(orderQuantity) : new ChickenOrder(orderQuantity);
			}
			currentOrder = menuItem;
			++newRequestCount;
			return menuItem;
		}

		public object? CopyPreviousRequest()
		{
			int quantity;
			string menuItem;
			if (currentOrder == null)
				throw new Exception("There is not previous orders to copy");
			if (currentOrder is ChickenOrder chickenObj)
			{
				quantity = chickenObj.GetQuantity();
				menuItem = chickenObj.GetType().Name;
			}
			else
			{
				var eggObj = currentOrder as EggOrder;
				quantity = eggObj.GetQuantity();
				menuItem = eggObj.GetType().Name;
			}
			return NewRequest(quantity, menuItem);
		}

		public string PrepareFood(object menuItem)
		{
			string food;
			if (menuItem is ChickenOrder chickenObj)
			{
				chickenObj.Cook();
				food = $"Chicken {chickenObj.GetQuantity()}, prepared";
			}
			else
			{
				var eggObj = menuItem as EggOrder;
				eggObj.Cook();
				food = $"Egg {eggObj.GetQuantity()}, prepared";
			}
			return food;
		}

		public string InspectEgg(object menuItem)
		{
			if (menuItem is ChickenOrder)
				return "No inspection required";
			else
			{
				var egg = menuItem as EggOrder;
				if (egg.GetQuality() == null)
					return "Employee forgot to check for quality";
				return (egg.GetQuality() > 25) ? egg.GetQuality().ToString() : "The Egg rotten";
			}
		}
	}

	public class ChickenOrder
	{
		private int quantity { get; set; }
		public ChickenOrder(int quantity)
		{
			this.quantity = quantity;
		}

		public int GetQuantity() => quantity;
		private void CutUp() { }

		public void Cook()
		{
			for (int i = 0; i < quantity; i++)
			{
				CutUp();
			}
		}
	}

	public class EggOrder
	{
		private int random = new Random().Next(101);
		private int quantity { get; set; }
		private static int eggInstanceCount = 0;
		public EggOrder(int quantity)
		{
			this.quantity = quantity;
			eggInstanceCount++;
		}
		public int GetQuantity() => quantity;

		public int? GetQuality()
		{
			return (eggInstanceCount % 2 == 0) ? random : null;
		}

		private void Crack()
		{
		}
		private void DiscardShell() { }
		public void Cook()
		{
			for (int i = 0; i < quantity; i++)
			{
				try
				{
					Crack();
				}
				catch (Exception ex)
				{
					throw new Exception(ex.Message);
				}
				finally
				{
					DiscardShell();
				}
			}
		}
	}
}
