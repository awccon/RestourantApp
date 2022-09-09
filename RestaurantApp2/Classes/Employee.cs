using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantApp2.Classes
{

    public enum menuItem
    {
        NoDrink = 0,
        CocaCola = 1,
        Pepsi = 2,
        Water = 3,
        Fanta = 4,
        Chicken = 5,
        Egg = 6
    }

    internal class Server
    {
        public menuItem[][] orderStore;
        private const int MaxCustomerCount = 8;
        private bool customersOrderWasSend = false;
        private int customerID = 0;

        /// <summary>
        /// Gets order quantity and menuItem
        /// </summary>
        public void SubmitRequest(int chickenCount, int eggCount, string drinksItem)
        {
            customerID++;
            if (customersOrderWasSend)
            {
                throw new Exception("Server already have current orders: you cannot order! please continue to prepare an order");
            }
            Array.Resize(ref orderStore, customerID);
            if (drinksItem != "")
            {
                menuItem[] newInstance = new menuItem[chickenCount + eggCount + 1];
                try
                {
                    for (int a = 0; a < chickenCount; a++)
                    {
                        newInstance[a] = menuItem.Chicken;
                    }
                    for (int b = chickenCount; b < chickenCount + eggCount; b++)
                    {
                        newInstance[b] = menuItem.Egg;
                    }
                    newInstance[newInstance.Length - 1] = (menuItem)Enum.Parse(typeof(menuItem), drinksItem);
                    orderStore[customerID - 1] = newInstance;
                }
                catch (IndexOutOfRangeException)
                {
                    throw new Exception("You cannot enter order out of 8 customer");
                }
            }
        }

        public void SendCustomerRequest()
        {
            customersOrderWasSend = true;
        }
    }
}
