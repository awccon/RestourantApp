using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantApp2.Classes
{
    /// <summary>
    /// This class is to create an Egg order
    /// </summary>
    internal class EggOrder : Order
    {
        //private static int _eggQualityCount = 0;
        private int random = new Random().Next(101);
        
        /// <summary>
        /// inherited from class Order
        /// </summary>
        /// <param name="quantity">Quantity of item</param>
        public EggOrder(int quantity) : base(quantity)
        {
            base.quantity = quantity;
            //_eggQualityCount++;
        }

        /// <summary>
        /// Get Quantity of Egg
        /// </summary>
        /// <returns>quantity</returns>
        public override int GetQuantity()
        {
             return base.quantity;
        }

        /// <summary>
        /// Get quality method
        /// </summary>
        /// <returns>returns a quality of egg with random number</returns>
        public int GetQuality()
        {
            return random;
        }

        /// <summary>
        /// Crack method
        /// </summary>
        public void Crack()
        {

        }

        /// <summary>
        /// Discard Shell method doesn't return anithing
        /// </summary>
        public void DiscardShell()
        {

        }

        /// <summary>
        /// Cook method doesn't return anithing
        /// </summary>
        public override void Cook()
        {
            // This is reponsible for cook egg
        }

        public override int SubtractQuantity(int quantityOfItem)
        {
            return base.quantity - quantityOfItem;
        }
    }
}
