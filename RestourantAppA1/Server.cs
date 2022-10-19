using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestourantAppA1
{
	internal class Server
	{
		public void SubmitNewRequest()
		{

		}

		public void CopyPreviousRequest()
		{

		}

		public void PrepareFood()
		{

		}
	}

	public class ChickenOrder
	{
		private int quantity { get; set; }
		public ChickenOrder(int quantity)
		{
			this.quantity = quantity;
		}

		public int GetQuantity()
		{
			return quantity;
		}

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
		private int quantity { get; set; }
		public EggOrder(int quantity)
		{
			this.quantity = quantity;
		}
		public int GetQuantity()
		{
			return quantity;
		}
	}
}
