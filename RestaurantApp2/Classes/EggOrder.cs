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
            //CR: Not needed    base.quantity = quantity;
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
        private void Crack()
        {

        }

        /// <summary>
        /// Discard Shell method doesn't return anithing
        /// </summary>
        private void DiscardShell()
        {

        }

        /// <summary>
        /// Cook method: Crack's an egg, discard's the shell and cooks it
        /// </summary>
        public override void Cook()
        {
            for (int i = 0; i < quantity; i++)
            {
                Crack();
                DiscardShell();
            }
        }
    }
}
