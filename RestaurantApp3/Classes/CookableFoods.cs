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
		public void CutUp() {}
		public void Cook() {}
		public void Obtain() {}
	}
	sealed class Egg : CookableFoods
	{
		public void Crack() { }
		public void DiscardShell() { }
		public void Cook() { }
		public void Obtain() { }
	}
}
