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
		public object NewRequest(int orderQuantity, string orderType)
		{
			object menuItem;
			if (orderType == "Chicken")
			{
				menuItem = new ChickenOrder(orderQuantity);
				currentOrder = menuItem;
				return menuItem;
			}
			else
			{
				menuItem = new EggOrder(orderQuantity);
				currentOrder = menuItem;
				return menuItem;
			}
		}

		public object? CopyPreviousRequest()
		{
			if (currentOrder == null)
				throw new Exception("There is not previous orders to copy");

			return (currentOrder is ChickenOrder chicheknObj) ? chicheknObj : currentOrder as EggOrder;
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

		public int? InspectEgg(object menuItem)
		{
			if (menuItem is ChickenOrder)
				throw new Exception("No inspection required");
			var egg = menuItem as EggOrder;
			return (egg.GetQuality() != null) ? egg.GetQuality() : throw new Exception("Employee forgot to check the egg");
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
		Random random = new Random();
		private int quantity { get; set; }
		public EggOrder(int quantity)
		{
			this.quantity = quantity;
		}
		public int GetQuantity() => quantity;

		public int? GetQuality()
		{
			int? singleEggQuality = null;
			for (int i = 0; i < quantity; i++)
			{
				if ((i % 2) == 1)
				{
					singleEggQuality = random.Next(101);
				}
			}
			return singleEggQuality;
		}

		private void Crack()
		{
			if (GetQuality() < 25)
				throw new Exception("Egg is rotten");
			if (GetQuality() == null)
				throw new Exception("Employee forgot to check for quality");
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
