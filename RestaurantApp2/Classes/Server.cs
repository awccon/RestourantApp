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

    public enum appStatus
	{
        submitted,
        sent,
        served
	}

    internal class Server
    {
        /// <summary>
        /// Stores orders
        /// </summary>
        private menuItem[][] orderStore = new menuItem[0][];
        private const int MaxCustomerCount = 8;
        private int customerID = 0;
        private ChickenOrder chickenObj;
        private EggOrder eggObj;
        appStatus orderStatus;

        /// <summary>
        /// This method gets value and stores to array
        /// </summary>
        /// <param name="chickenValue">quantity of chicken</param>
        /// <param name="eggValue">quantity of egg</param>
        /// <param name="drinksItem">drink</param>
        /// <exception cref="Exception">Exception when you haven't clicked to send button</exception>
        public void SubmitRequest(string chickenValue, string eggValue, string drinksItem)
        {
            if (orderStatus != appStatus.sent)
            {
                int chickenCount, eggQuantity;
                if ((Int32.TryParse(chickenValue, out chickenCount) && chickenCount >= 0) && (Int32.TryParse(eggValue, out eggQuantity) && eggQuantity >= 0))
                {
                    customerID++;
                    if (customerID > MaxCustomerCount)
                    {
                        throw new Exception("Range of customers up to 8");
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
                else throw new Exception("Count of order incorrect");
            }
            else throw new Exception("Order didn't served");
            orderStatus = appStatus.submitted;
        }

        /// <summary>
        /// This method sends all order count to the cook and returns quality of egg
        /// </summary>
        /// <returns>Quality of egg</returns>
        /// <exception cref="Exception">Exception if order wasn't submitted yet</exception>
        public string SendCustomerRequest()
        {
            if (orderStatus == appStatus.submitted)
            {
                int chickenCount = 0, eggCount = 0;
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
                orderStatus = appStatus.sent;
                if (chickenCount != 0)
                {
                    ChefCook.Submit(chickenCount, menuItem.Chicken);
                    chickenObj = (ChickenOrder)ChefCook.Prepare();
                }
                if (eggCount != 0)
                {
                    ChefCook.Submit(eggCount, menuItem.Egg);
                    eggObj = (EggOrder)ChefCook.Prepare();
                    return eggObj.GetQuality().ToString();
                }
                else return "There is no egg to inspect needed";
            }
            else throw new Exception("Order didn't submitted");

            //CR: We should call the submit method with specifying chicken or egg quantity.
            //Cr: then we need to call prepare methof for chicken or egg. 
            //CR: If customer requests 0 eggs, it still gives me the egg quality. How can I get the egg quality if I don't have eggs?? 
        }

        /// <summary>
        /// This method serves customer orders and returns array
        /// </summary>
        /// <returns>Array</returns>
        /// <exception cref="Exception">When submit button or send button wasn't clicked</exception>
        public string[] ServeCustomer()
        {
            //CR: This is only serving one customer. Consider serving all customers in this method.
            //CR: WE don't need to cast now because we already know the type
            
            if (orderStatus != appStatus.sent)
            {
                throw new Exception("Order wasn't sent to cook yet");
            }
            
            string[] orderResutl = new string[orderStore.Length + 1];
            for (int i = 0; i < orderStore.Length; i++)
            {
                int chickenCount = 0, eggCount = 0;
                menuItem drink = menuItem.NoDrink;
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
                    else drink = item;
                }
                
                //CR: I should change the subtract and add exeption
                //if (chickenObj != null && chickenObj.quantity > 0)
                //{
                //    chickenObj.SubtractQuantity(chickenCount);
                //}
                //else chickenCount = 0;
                //if (eggObj != null && eggObj.quantity > 0)
                //{
                //    eggObj.SubtractQuantity(eggCount);
                //}
                //else eggCount = 0;

                orderResutl[i] = $"Customer: {i}, Chicken: {chickenCount}, Egg: {eggCount}, Drinks: {Enum.GetName(typeof(menuItem), drink)}";
            }
            orderResutl[orderResutl.Length - 1] = "Please enjoy your food!";
            customerID = 0;
            orderStore = new menuItem[0][];
            orderStatus = appStatus.served;
            return orderResutl;
            
            //CR: Why are we subtracting the quantity?? we are not checking if any leftover food there. 
        }
    }
}
