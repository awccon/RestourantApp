using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantApp3.Classes
{
	/// <summary>
	/// Base Class
	/// </summary>
	abstract class MenuItem : IMenuItem
	{
		public void Obtain() { }
		public void Serve() { }
	}
}
