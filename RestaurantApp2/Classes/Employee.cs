using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantApp2.Classes
{
    public enum drinksItem
    {
        CocaCola,
        Pepsi,
        Water,
        Fanta,
        NoDrink
    }

    public enum menuItem
    {
        Chicken,
        Egg
    }

    internal class Employee
    {
        /// <summary>
        /// This field for store our data
        /// </summary>
        private string[][] customerOrderData = new string[8][];
        private bool customersOrderWasSend = false;

        /// <summary>
        /// Gets order quantity and menuItem
        /// </summary>
        public void NewRequest(string chicken, string egg, string drinksItem)
        {
            if (customersOrderWasSend)
            {
                throw new Exception("Server already have current orders: you cannot order! please continue to prepare an order");
            }

            if (chicken != "" && egg != "" && drinksItem != "")
            {
                //customerOrderData[][] = 
            }

            //object? newOrder = null;

            //if (menuItem == "Chicken")
            //{
            //    newOrder = new ChickenOrder(quantity);
            //}
            //else
            //{
            //    newOrder = new EggOrder(quantity);
            //}
            //return newOrder;
        }

        public void SendCustomerRequest()
        {
            customersOrderWasSend = true;
        }

        /// <summary>
        /// Inspect Method will inspect an order
        /// </summary>
        /// <param name="obj">should be a new instance of order</param>
        /// <returns>result of inspection in string ether null</returns>
        public string Inspect(object obj)
        {
            if (obj is EggOrder eggOrder)
            {
                int quality = eggOrder.GetQuality();
                return quality.ToString();
            }
            else return "No Inspection required";
        }

        /// <summary>
        /// Prepare Food method it will get an object and will prepare
        /// </summary>
        /// <param name="obj">Parameter should be a new instance of order</param>
        /// <returns>Returns a result of cook and prepare</returns>
        public string PrepareFood(object obj)
        {
            string resultMessage;
            if (obj != null && (obj is EggOrder eggOrder))
            {
                for (int i = 0; i < eggOrder.GetQuantity(); i++)
                {
                    eggOrder.Crack();
                    eggOrder.DiscardShell();
                }
                eggOrder.Cook();
                resultMessage = $"Cook Egg has been finished \n" +
                    $"Quantity of Egg is {eggOrder.GetQuantity()}";
            }
            else if (obj != null && (obj is ChickenOrder chickenOrder))
            {
                for (int i = 0; i < chickenOrder.GetQuantity(); i++)
                {
                    chickenOrder.CutUp();
                }
                chickenOrder.Cook();
                resultMessage = "Cooking Chicken has been finished \n" +
                    $"Quantity of Chicken is {chickenOrder.GetQuantity()}";
            }
            else resultMessage = "You didn't choose any item";
            return resultMessage;
        }


    }
}
