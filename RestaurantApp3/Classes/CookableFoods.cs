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
		/// <summary>
		/// this method can responsible for Chicken
		/// </summary>
		public override void Serve() { }
		/// <summary>
		/// this method can responsible for Chicken 
		/// </summary>
		public void CutUp() { }
		/// <summary>
		/// this method can responsible for Chicken 
		/// </summary>
		public void Cook()
		{
			CutUp();
		}
		/// <summary>
		/// this method can responsible for Chicken 
		/// </summary>
		public override void Obtain() { }
	}

	sealed class Egg : CookableFoods, IDisposable
	{
		/// <summary>
		/// this method responsible for Egg
		/// </summary>
		public void Crack() { }
		/// <summary>
		/// this method responsible for Egg
		/// </summary>
		public void Cook()
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
		/// this method responsible for Egg
		/// </summary>
		public override void Obtain()
		{
		}
		/// <summary>
		/// this method responsible for Egg
		/// </summary>
		public override void Serve()
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
