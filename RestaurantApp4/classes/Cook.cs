using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantApp4
{
	internal class Cook
	{
		public delegate void CookingProcessEvent();
		public event CookingProcessEvent? OnProcessFinished;

		public void Process(TableRequest currentTable)
		{
			var CookableItems = currentTable.Get<CookableFood>();

			foreach (CookableFood item in CookableItems)
			{
				item.Obtain();
				item.Cook();
			}
			OnProcessFinished?.Invoke();
		}
	}
}
