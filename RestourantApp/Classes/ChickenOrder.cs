using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestourantApp.Classes
{
    /// <summary>
    /// This class is to crate Chicken order and other stuff.
    /// </summary>
    internal class ChickenOrder
    {
        private int _quantity = 0; // This is for order quantity

        /// <summary>
        /// 
        /// </summary>
        /// <param name="quantity">You shoudl pass the quantity of chickens</param>
        public ChickenOrder(int quantity)
        {
            _quantity = quantity;
        }

        // Returns quantity from constructor
        public int GetQuantity()
        {
            return _quantity;
        }

        /// <summary>
        /// Method to cut a meat, it shoul be called the num of times in quantity
        /// </summary>
        public void CutUp()
        {

        }

        // Cooking method
        public void Cook()
        {

        }
    }
}
