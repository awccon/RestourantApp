using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantApp4
{

	/// <summary>
	/// Drinks list
	/// </summary>
	public enum listOfDrinks
	{
		NoDrink,
		Tea,
		CocaCola,
		Pepsi
	}

	/// <summary>
	/// Menu items base class, type abstract has implemented interface IMenuItem
	/// </summary>
	abstract class MenuItem : IMenuItem
	{

		public abstract void Obtain();

		public abstract void Serve();
	}
	/// <summary>
	/// Cookable foods base class which inherited from MenuItem
	/// </summary>
	abstract class CookableFood : MenuItem
	{
		//CR: Since the method below are just empty, it should have been inplemented one level above and no need to make it abstract unless it is necessary
		public override void Obtain()
		{
		}

		public override void Serve()
		{
		}

		public abstract void Cook();
	}
	/// <summary>
	/// Drink inherited from MenuItem
	/// </summary>
	abstract class Drink : MenuItem
	{
		public override string ToString()
		{
			return this.GetType().Name;
		}
		public override void Obtain()
		{
		}

		public override void Serve()
		{
		}
	}
	/// <summary>
	/// sealed class: Chicken it's menu item, can be cook, obtain and serve
	/// </summary>
	sealed class Chicken : CookableFood
	{
		private void cutUp() { }

		public override void Cook()
		{
			cutUp();
		}
	}

	/// <summary>
	/// sealed class: Egg it's menu item, can be cook, obtain and serve
	/// After end of object it will dispose itself from destructor
	/// </summary>
	sealed class Egg : CookableFood, IDisposable
	{
		private void crack() { }
		private void discardShell()
		{
			Dispose();
		}
		public override void Cook()
		{
			crack();
		}

		public void Dispose()
		{

		}

		~Egg()
		{
			discardShell();
		}
	}

	// Drinks

	sealed class Tea : Drink
	{

	}
	sealed class CocaCola : Drink
	{

	}
	sealed class Pepsi : Drink
	{

	}
}
