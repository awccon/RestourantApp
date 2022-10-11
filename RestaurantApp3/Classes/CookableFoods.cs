using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantApp3.Classes
{
	abstract class CookableFoods : MenuItem
	{

	}

	sealed class Chicken : CookableFoods
	{
		public override void Serve()
		{
		}

		public void CutUp() { }
		public void Cook()
		{
			CutUp();
		}

		public override void Obtain()
		{
		}
	}
	sealed class Egg : CookableFoods, IDisposable
	{
		static int counter = 0;

		public Egg()
		{
			counter++;
		}

		public override string ToString()
		{
			return this.GetType().Name + " " + counter;
		}

		public void Crack() { }

		public void Cook()
		{
			Crack();
		}
		public override void Obtain()
		{
		}
		public override void Serve()
		{
		}

		public void Dispose()
		{
			//throw new NotImplementedException();
		}

		//~Egg();
	}
}
