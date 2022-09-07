using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantApp2.Classes
{

    internal class Employee
    {
        /// <summary>
        /// Gets order quantity and menuItem
        /// </summary>
        /// <param name="quantity">It should be a positive number</param>
        /// <param name="menuItem">It should be chicken or egg</param>
        /// <returns>New instance of order</returns>
        public object NewRequest(int quantity, string menuItem)
        {
            object? newOrder = null;
            if (menuItem == "Chicken")
            {
                newOrder = new ChickenOrder(quantity);
            }
            else
            {
                newOrder = new EggOrder(quantity);
            }
            return newOrder;
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
            //You need to check to see if the obj is null. if so tell the user that there is no order. then check for Egg or Chicken
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
