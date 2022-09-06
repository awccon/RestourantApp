using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestourantApp.Classes
{
    /// <summary>
    /// This class is to create Chicken order
    /// </summary>
    internal class ChickenOrder
    {
        private int _quantity = 0;

        /// <summary>
        /// Chicken order it will return quantity of chicken
        /// </summary>
        /// <param name="quantity">You shoudl pass the quantity of chickens</param>
        public ChickenOrder(int quantity)
        {
            _quantity = quantity;
        }

        /// <summary>
        /// Gets quantity from constructor
        /// </summary>
        /// <returns>quantity type integer</returns>
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

        /// <summary>
        /// Method to cook a chicken
        /// </summary>
        public void Cook()
        {

        }
    }
}
