using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestourantApp.Classes
{
    internal class Employee
    {
        private object? _lastRequest; // This used for Copy
        private int _requestCallCount;

        //This func returns obj, this is correct I checked twise
        public object NewRequest(int quantity, string menuItem)
        {

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
            _lastRequest = newOrder; // Last order need for Copy previous order
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
                else return Convert.ToString(quality);
            }
            else return "No Inspection required";
        }


        // 
        public string PrepareFood(object obj)
        {
            // Preparing an Egg
            if (obj is EggOrder eggOrder)
            {
                for (int i = 0; i <= eggOrder.GetQuantity(); i++)
                {
                    try
                    {
                        eggOrder.Crack();
                    }
                    catch (Exception ex)
                    {
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
            // This process of prepare a Chicken and cook it
            else if (obj is ChickenOrder chickenOrder)
            {
                for (int i = 0; i <= chickenOrder.GetQuantity(); i++)
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
