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
        private bool submitOrder = false;
        private bool orderSentToCook = false;
        private bool orderServedToCustomer = false;
        private int customerID = 0;
        private ChickenOrder chickenObj;
        private EggOrder eggObj;


        /// <summary>
        /// Submit function that takes all item and saves to data storage
        /// </summary>
        public void SubmitRequest(int chickenCount, int eggCount, string drinksItem)
        {
            if (orderServedToCustomer)
            {
                throw new Exception("Please serve current customers orders");
            }
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
            //It will resize our data from customer count
            Array.Resize(ref orderStore, customerID);
                                                      
            //customerOrder it is used to assign to jagged array every customer order
            menuItem[] customerOrder = new menuItem[chickenCount + eggCount + 1];
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

        public string SendCustomerRequest()
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
            //CR: Cook should created once for the app's life time. We don't want to use a new cook every time when we need the cook. 
            Cook ChefCook = new Cook();
            ChefCook.Submit(chickenCount, "Chicken");
            chickenObj = (ChickenOrder)ChefCook.Prepare();
            if (eggCount != 0)
            {
                ChefCook.Submit(eggCount, "Egg");
                eggObj = (EggOrder)ChefCook.Prepare();
                return eggObj.GetQuality().ToString();
            }
            else return "There is no egg to inspect";
            
            //CR: We should call the submit method with specifying chicken or egg quantity.
            //Cr: then we need to call prepare methof for chicken or egg. 

            //CR: If customer requests 0 eggs, it still gives me the egg quality. How can I get the egg quality if I don't have eggs?? 
            //return eggObj.GetQuality();
        }

        public Array ServeCustomer()
        {
            //CR: This is only serving one customer. Consider serving all customers in this method.
            if (!submitOrder && !orderSentToCook)
            {
                throw new Exception("please send menu item to the cook to prepare a food");
            }
            //CR: WE don't need to cast now because we already know the type
            //ChickenOrder chick = (ChickenOrder)chickenObj;
            //EggOrder egg = (EggOrder)eggObj;

            int chickenCount = 0;
            int eggCount = 0;
            string drink = "";
            string orderAvailability;
            string[] orderResutl = new string[customerID];
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
                    else drink = item.ToString();
                    orderResutl[i - 1] = $"Customer: {i}, Chicken: {chickenCount}, Egg: {eggCount}, Drinks: {drink}";
                }

            }

            //CR: Why are we subtracting the quantity?? we are not checking if any leftover food there. 
            if (chickenObj.quantity > 0)
            {
                chickenObj.SubtractQuantity(chickenCount);
            }
            else orderAvailability = "There is not enough chicken in the plate";

            if (eggObj.quantity > 0)
            {
                eggObj.SubtractQuantity(eggCount);
            }
            else orderAvailability = "There is not enough egg in the plate";
            return orderResutl;
        }
    }
}
