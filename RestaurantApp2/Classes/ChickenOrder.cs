using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantApp2.Classes
{
    /// <summary>
    /// This class is to create Chicken order
    /// </summary>
    internal class ChickenOrder : Order
    {

        /// <summary>
        /// Chicken order it will return quantity of chicken
        /// </summary>
        /// <param name="quantity">quantity of item</param>
        public ChickenOrder(int quantity) : base(quantity)
        {
            //base.quantity = quantity;
        }

        /// <summary>
        /// Gets quantity from constructor
        /// </summary>
        /// <returns>quantity type integer</returns>
        public override int GetQuantity()
        {
            return base.quantity;
        }

        /// <summary>
        /// Method to cut a meat, it shoul be called the num of times in quantity
        /// </summary>
        public void CutUp()
        {

        }

        /// <summary>
        /// Method to cook a chicken
        /// </summary>
        public override void Cook()
        {
            // This is responsible for cook chicken
        }
    }
}
