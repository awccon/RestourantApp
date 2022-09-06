using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestourantApp.Classes
{

    /*
        1. When I make a new order by pressing New Request, I should not be able to make another request or copy request before I prepare the ordered food.
        2. Once you order any food and prepare it, then without making another request, you can Prepare the food again. It should not let you do that. It should tell to order again.
        3. When I leave the quantity box empty, and press Submit, it does nothing. It should tell me to enter quantity. 
        4. When copying the previous order, and if it's the third time, then it should mix my order. It should make chicken if egg was ordered, or wise versa. 
    */

    internal class Employee
    {
        private object? _lastRequest;
        private int _requestCallCount;
        bool ordered = false;

        /// <summary>
        /// Gets order quantity and menuItem
        /// </summary>
        /// <param name="quantity">It should be a positive number</param>
        /// <param name="menuItem">It should be chicken or egg</param>
        /// <returns>New instance of order</returns>
        public object NewRequest(int quantity, string menuItem)
        {
            //CR: You need to handle the problem of ordering multiple times in a row.
            if (ordered)
            {
                throw new Exception("You need to prepare a current order");
            }
            ordered = true;
            _requestCallCount++;
            
            if (_requestCallCount % 3 == 0)
            {
                menuItem = (menuItem == "Chicken" ? "Egg" : "Chicken");
            }
            object? newOrder = null;
            if (menuItem == "Chicken")
            {
                newOrder = new ChickenOrder(quantity);
            }
            else
            {
                newOrder = new EggOrder(quantity);
            }
            _lastRequest = newOrder;
            return newOrder;
        }

        /// <summary>
        /// Copy Request method will check a previous order
        /// </summary>
        /// <returns>It will return null or a new instanse of order</returns>
        /// <exception cref="Exception">If there is no previous order it will stop a method and return a warning message</exception>
        public object CopyRequest()
        {
            if (_lastRequest == null)
            {
                throw new Exception("There are no previous requests!");
            }
            int quantity;
            string menuItem;
            if (_lastRequest is ChickenOrder chickenOrder)
            {
                menuItem = "Chicken";
                quantity = chickenOrder.GetQuantity();
            }
            else
            {
                var egg = _lastRequest as EggOrder;
                quantity = egg.GetQuantity();
                menuItem = "Egg";
            }
            return NewRequest(quantity, menuItem);
        }

        /// <summary>
        /// Inspect Method will inspect an order
        /// </summary>
        /// <param name="obj">should be a new instance of order</param>
        /// <returns>result of inspection in string ether null</returns>
        public string? Inspect(object obj)
        {
            if (obj is EggOrder eggOrder)
            {
                int? quality = eggOrder.GetQuality();

                if (quality == null)
                {
                    return "I forgot to check quality";
                }
                else if (quality != null && quality <= 25)
                {
                    return $"Quality of egg is: {quality}";
                }
                else return quality.ToString();
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
                    try
                    {
                        eggOrder.Crack();
                    }
                    catch (Exception)
                    {
                        //Even if you have rotten eggs, it should still keep on cracking other eggs. It should not leave the method. 
                    }
                    finally
                    {
                        eggOrder.DiscardShell();
                    }
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
            ordered = false;
            return resultMessage;
        }
    }
}
