using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantApp3.Classes
{
	abstract class Drinks : MenuItem
	{
		public override string ToString()
		{
			return this.GetType().Name;
		}

	}

	sealed class Tea : Drinks
	{

		/// <summary>
		/// this method responsible for Tea
		/// </summary>
		public override void Obtain()
		{
		}


		/// <summary>
		/// this method responsible for Tea
		/// </summary>
		public override void Serve()
		{
		}
	}

	sealed class CocaCola : Drinks
	{

		/// <summary>
		/// this method responsible for CocaCola
		/// </summary>
		public override void Obtain()
		{
		}

		/// <summary>
		/// this method responsible for CocaCola
		/// </summary>
		public override void Serve()
		{
		}
	}

	sealed class Pepsi : Drinks
	{
		/// <summary>
		/// this method responsible for Pepsi
		/// </summary>
		public override void Obtain()
		{
		}

		/// <summary>
		/// this method responsible for Pepsi
		/// </summary>
		public override void Serve()
		{
		}
	}
}
