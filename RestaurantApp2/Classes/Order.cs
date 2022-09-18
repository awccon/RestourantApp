using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantApp2.Classes
{
    internal class Order
    {
        public int quantity = 0;
        public Order(int quantity)
        {
            this.quantity = quantity;
        }

        /// <summary>
        /// gets quantity and returns
        /// </summary>
        /// <returns></returns>
        public int GetQuantity()
        {
            return quantity;
        }

        /// <summary>
        /// Cook method
        /// </summary>
        public virtual void Cook()
        {

        }

        public void SubtractQuantity(int quantityOfItem)
        {
            quantity = quantity - quantityOfItem;
        }
    }
}
