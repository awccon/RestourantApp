using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantApp3.Classes
{
	abstract class CookableFood : MenuItem
	{
		public abstract void Cook();
	}

	sealed class Chicken : CookableFood
	{
		/// <summary>
		/// this method can responsible for Chicken 
		/// </summary>
		public void CutUp() { }
		/// <summary>
		/// this method can responsible for Chicken 
		/// </summary>
		public override void Cook()
		{
			CutUp();
		}
	}

	sealed class Egg : CookableFood, IDisposable
	{
		/// <summary>
		/// this method responsible for Egg
		/// </summary>
		public void Crack() { }
		/// <summary>
		/// this method responsible for Egg
		/// </summary>
		public override void Cook()
		{
			Crack();
		}
		/// <summary>
		/// this method responsible for Egg
		/// </summary>
		private void DiscardShell()
		{

		}

		/// <summary>
		/// this will clean RAM from instances
		/// </summary>
		public void Dispose()
		{
			DiscardShell();
		}

		/// <summary>
		/// Destructor calls Dispose method to destroy and clean an instances
		/// </summary>
		~Egg()
		{
			Dispose();
		}
	}
}
