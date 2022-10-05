using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantApp3.Classes
{
	internal interface IMenuItem
	{
		void Cook() { }
		void CutUp() { }

		void Crack() { }

		void Obtain() { }
		void DiscardShell() { }
	}
}
