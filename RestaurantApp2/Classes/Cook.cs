using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantApp2.Classes
{
    internal class Cook
    {
        //CR: Why these fields are static?
        private int orderCount;
        private menuItem orderType;

        /// <summary>
        /// This method is responsible to get quantity of order and type of order
        /// </summary>
        /// <param name="orderCount">quantity of order</param>
        /// <param name="orderType">type of order</param>
        public void Submit(int orderCount, menuItem orderType)
        {
            this.orderCount = orderCount;
            this.orderType = orderType;
        }

        //CR: Why the return parameters are object type? 
        public object Prepare()
        {
            object returnPrepOrder = new Object();
            if (orderCount != 0 && orderType == menuItem.Chicken)
            {
                ChickenOrder chicken = new ChickenOrder(orderCount);
                chicken.Cook();
                returnPrepOrder = chicken;
            }
            //CR: What is I have no chickens or eggs? Why do I create their instance? 
            if (orderCount != 0 && orderType == menuItem.Egg)
            {
                EggOrder egg = new EggOrder(orderCount);
                egg.Cook();
                returnPrepOrder = egg;
            }
            return returnPrepOrder;
        }

    }
}
