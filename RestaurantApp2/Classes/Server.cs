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
        private bool orderSentToCook = false;
        private bool submitOrder = false;
        private int customerID = 0;
        private object chickenObj;
        private object eggObj;


        /// <summary>
        /// Submit function that takes all item and saves to data storage
        /// </summary>
        public void SubmitRequest(int chickenCount, int eggCount, string drinksItem)
        {
            submitOrder = true;
            customerID++;
            if (customerID > MaxCustomerCount)
            {
                throw new Exception("You cannot enter order out of 8 customer");
            }
            if (orderSentToCook) // It will throw an exception if we send orders and want to place a new order
            {
                throw new Exception("Server already have current orders: you cannot order! please continue to prepare an order");
            }
            Array.Resize(ref orderStore, customerID); //It will resize our data from customer count
            if (drinksItem != "")
            {
                //customerOrder it is used to assign to jagged array every customer order
                menuItem[] customerOrder = new menuItem[chickenCount + eggCount + 1];
                try
                {
                    for (int a = 0; a < chickenCount; a++)
                    {
                        customerOrder[a] = menuItem.Chicken;
                    }
                    for (int b = chickenCount; b < chickenCount + eggCount; b++)
                    {
                        customerOrder[b] = menuItem.Egg;
                    }
                    customerOrder[customerOrder.Length - 1] = (menuItem)Enum.Parse(typeof(menuItem), drinksItem);
                    orderStore[customerID - 1] = customerOrder;
                }
                catch (IndexOutOfRangeException ex)
                {
                    throw new Exception(ex.Message);
                }
            }
        }

        public int SendCustomerRequest()
        {
            orderSentToCook = true;
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
            Cook ChefCook = new Cook(chickenCount, eggCount);
            (chickenObj, eggObj) = ChefCook.PrepareFood();
            EggOrder egg = (EggOrder)eggObj;
            return egg.GetQuality();
        }

        public string ServeCustomer(int i)
        {
            string Message = "";
            if (submitOrder)
            {
                Message = "Please enter sever a food to the customers";
            }
            orderSentToCook=false;

            ChickenOrder chick = (ChickenOrder)chickenObj;
            EggOrder egg = (EggOrder)eggObj;

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
                chick.SubtractQuantity(chickenCount);
                egg.SubtractQuantity(eggCount);
                return Message = $"Customer: {i}, Chicken: {chickenCount}, Egg: {eggCount}, Drinks: {drink}";
        }
    }
}
