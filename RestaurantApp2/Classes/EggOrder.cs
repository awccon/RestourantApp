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
        private static int _eggQualityCount = 0;
        private int random = new Random().Next(101);

        public EggOrder(int quantity) : base(quantity)
        {
            base._quantity = quantity;
            _eggQualityCount++;
        }

        /// <summary>
        /// Get Quantity of Egg
        /// </summary>
        /// <returns>quantity</returns>
        public override int GetQuantity()
        {
             return base._quantity;
        }

        /// <summary>
        /// Get quality method
        /// </summary>
        /// <returns>returns a quality of egg with random number</returns>
        public int? GetQuality()
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
    }
}
