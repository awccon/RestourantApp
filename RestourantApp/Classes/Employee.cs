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
5. 

 */

    internal class Employee
    {
        private object? _lastRequest; // This used for Copy
        private int _requestCallCount;
        

        //This func returns obj, this is correct I checked twise
        public object NewRequest(int quantity, string menuItem)
        {
            //CR: You need to handle the problem of ordering multiple times in a row.
            _requestCallCount++; // Function call counter
            if (_requestCallCount % 3 == 0) // This will reverse and return value every third session
            {
                menuItem = (menuItem == "Chicken" ? "Egg" : "Chicken");
            }
            object? newOrder = null; // This object used to store a new instance of class and return it
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

        // Copy previous order, it get's from _lastRequest and returns new instance
        public object CopyRequest()
        {
            if (_lastRequest == null)
            {
                throw new Exception("There are no previous requests!");
            }
            int quantity = 0;
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

        // Inspect will check an Egg, is it rotten or not it will return a string ether null
        public string? Inspect(object obj)
        {
            //We show the egg quality whether it is rotten or not. You need to show if the egg is rotten in the result box.  
            if (obj is EggOrder eggOrder)
            {
                int? quality = eggOrder.GetQuality();

                if (quality == null)
                {
                    return "I forgot to check quality";
                }
                else if (quality != null && quality <= 25)
                {
                    return "The Egg is rotten and you can't use it to cook";
                }
                else return quality.ToString();
            }
            else return "No Inspection required";
        }

        // 
        public string PrepareFood(object obj)
        {
            //You need to check to see if the obj is null. if so tell the user that there is no order. then check for Egg or Chicken
            _lastRequest = obj; // Last order need for Copy previous order

            // Preparing an Egg
            if (obj != null && (obj is EggOrder eggOrder)) // F9 breakpoint kuyish, F10 step over, F11 step in, Shift + F11 step out 
            {
                for (int i = 0; i < eggOrder.GetQuantity(); i++)
                {
                    try
                    {
                        eggOrder.Crack();
                    }
                    catch (Exception ex)
                    {
                        //Even if you have rotten eggs, it should still keep on cracking other eggs. It should not leave the method. 
                        return ex.Message;
                    }
                    finally
                    {
                        eggOrder.DiscardShell();
                    }
                }
                eggOrder.Cook();
                return $"Cook Egg has been finished \n" +

                    $"Quantity of Egg is {eggOrder.GetQuantity()}";
            }
            else if (obj != null && (obj is ChickenOrder chickenOrder))
            {
                for (int i = 0; i < chickenOrder.GetQuantity(); i++)
                {
                    chickenOrder.CutUp();
                }
                chickenOrder.Cook();
                return "Cooking Chicken has been finished \n" +

                    $"Quantity of Chicken is {chickenOrder.GetQuantity()}";
            }
            else return "You didn't choose any item";

        }
    }
}
