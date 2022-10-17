using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantApp3.Classes
{
    sealed class Cook
    {
        /// <summary>
        /// method can get item and process them
        /// </summary>
        /// <param name="tableRequests">List of customer orders</param>
        /// <exception cref="Exception">cooking foods completed message</exception>
        public void Process(TableRequests tableRequests)
        {
            IMenuItem[] allFood = tableRequests[typeof(CookableFood)];
            foreach (CookableFood food in allFood)
            {
                food.Obtain();
                food.Cook();
            }
        }
    }
}
