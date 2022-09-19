using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantApp2.Classes
{

    /// <summary>
    /// List of drinks and cooks
    /// </summary>
    public enum menuItem
    {
        NoDrink = 0,
        Cola = 1,
        Pepsi = 2,
        Tea = 3,
        Fanta = 4,
        Coke = 5,
        Soda = 6,
        Chicken = 7,
        Egg = 8
    }

    internal class Server
    {
        /// <summary>
        /// Stores orders
        /// </summary>
        private menuItem[][] orderStore;
        private const int MaxCustomerCount = 8;
        private bool submitBtn = false;
        private bool sendBtn = false;
        private int customerID = 0;
        private ChickenOrder chickenObj;
        private EggOrder eggObj;

        /// <summary>
        /// This method gets value and stores to array
        /// </summary>
        /// <param name="chickenValue">quantity of chicken</param>
        /// <param name="eggValue">quantity of egg</param>
        /// <param name="drinksItem">drink</param>
        /// <exception cref="Exception">Exception when you haven't clicked to send button</exception>
        public void SubmitRequest(string chickenValue, string eggValue, string drinksItem)
        {
            if (!sendBtn)
            {
                int chickenCount, eggQuantity;
                if ((Int32.TryParse(chickenValue, out chickenCount) && chickenCount >= 0) && (Int32.TryParse(eggValue, out eggQuantity) && eggQuantity >= 0))
                {
                    submitBtn = true;
                    customerID++;
                    if (customerID > MaxCustomerCount)
                    {
                        throw new Exception("You cannot enter order out of 8 customer");
                    }
                    Array.Resize(ref orderStore, customerID);
                    menuItem[] customerOrder = new menuItem[chickenCount + eggQuantity + 1];
                    for (int a = 0; a < chickenCount; a++)
                    {
                        customerOrder[a] = menuItem.Chicken;
                    }
                    for (int b = chickenCount; b < chickenCount + eggQuantity; b++)
                    {
                        customerOrder[b] = menuItem.Egg;
                    }
                    customerOrder[customerOrder.Length - 1] = (menuItem)Enum.Parse(typeof(menuItem), drinksItem);
                    orderStore[customerID - 1] = customerOrder;
                }
                else throw new Exception("Enter correct number of order");
            }
            else throw new Exception("Please serve the current order");
        }

        /// <summary>
        /// This method sends all order count to the cook and returns quality of egg
        /// </summary>
        /// <returns>Quality of egg</returns>
        /// <exception cref="Exception">Exception if order wasn't submitted yet</exception>
        public string SendCustomerRequest()
        {
            if (!submitBtn)
            {
                throw new Exception("Please submit an order");
            }
            sendBtn = true;
            int chickenCount = 0;
            int eggCount = 0;
            for (int i = 0; i < orderStore.Length; i++)
            {
                foreach (var item in orderStore[i])
                {
                    if (item == menuItem.Chicken)
                    {
                        chickenCount++;
                    }
                    else if (item == menuItem.Egg)
                    {
                        eggCount++;
                    }
                }
            }
            //CR: Cook should created once for the app's life time. We don't want to use a new cook every time when we need the cook. 
            Cook ChefCook = new Cook();
            if (chickenCount != 0)
            {
                ChefCook.Submit(chickenCount, "Chicken");
                chickenObj = (ChickenOrder)ChefCook.Prepare();
            }
            if (eggCount != 0)
            {
                ChefCook.Submit(eggCount, "Egg");
                eggObj = (EggOrder)ChefCook.Prepare();
                return eggObj.GetQuality().ToString();
            }
            else return "There is no egg to inspect needed";

            //CR: We should call the submit method with specifying chicken or egg quantity.
            //Cr: then we need to call prepare methof for chicken or egg. 
            //CR: If customer requests 0 eggs, it still gives me the egg quality. How can I get the egg quality if I don't have eggs?? 
        }

        /// <summary>
        /// This method serves customer orders and returns array
        /// </summary>
        /// <returns>Array</returns>
        /// <exception cref="Exception">When submit button or send button wasn't clicked</exception>
        public Array ServeCustomer()
        {
            //CR: This is only serving one customer. Consider serving all customers in this method.
            //CR: WE don't need to cast now because we already know the type
            if (!submitBtn)
            {
                throw new Exception("Please submit the orders");
            }
            if (!sendBtn)
            {
                throw new Exception("Please send current order to the Cook");
            }
            
            string[] orderResutl = new string[orderStore.Length + 1];
            for (int i = 0; i < orderStore.Length; i++)
            {
                int chickenCount = 0;
                int eggCount = 0;
                string drink = "";
                foreach (var item in orderStore[i])
                {
                    if (item == menuItem.Chicken)
                    {
                        chickenCount++;
                    }
                    else if (item == menuItem.Egg)
                    {
                        eggCount++;
                    }
                    else drink = item.ToString();
                }

                if (chickenObj != null && chickenObj.quantity > 0)
                {
                    chickenObj.SubtractQuantity(chickenCount);
                }
                else chickenCount = 0;
                if (eggObj != null && eggObj.quantity > 0)
                {
                    eggObj.SubtractQuantity(eggCount);
                }
                else eggCount = 0;
                orderResutl[i] = $"Customer: {i}, Chicken: {chickenCount}, Egg: {eggCount}, Drinks: {drink}";
            }
            orderResutl[orderResutl.Length - 1] = "Please enjoy your food!";
            for (int i = 0; i < orderStore.Length; i++)
            {
                Array.Clear(orderStore[i], 0, orderStore[i].Length);
            }
            sendBtn = false;
            submitBtn = false;
            customerID = 0;
            return orderResutl;
            
            //CR: Why are we subtracting the quantity?? we are not checking if any leftover food there. 
        }
    }
}
