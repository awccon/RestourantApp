using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestourantApp.Classes
{
    /// <summary>
    /// This class is to create an Egg order
    /// </summary>
    internal class EggOrder
    {
        private int _quantity = 0;
        private int _checkQualityCount = 0;
        private int random = new Random().Next(101);

        public EggOrder(int quantity)
        {
            _quantity = quantity;
        }

        /// <summary>
        /// Get Quantity of Egg
        /// </summary>
        /// <returns>quantity</returns>
        public int GetQuantity()
        {
            return _quantity;
        }

        //1: 55, 2: null, 3: 45, 4: null, 

        /// <summary>
        /// Get quality method
        /// </summary>
        /// <returns>returns a quality of egg with random number</returns>
        public int? GetQuality()
        {
            //CR: quality of the egg should be specific to an instance. It shouldn't renew ever =y time I call the method. It should be different when I create a new EggOrder class.
            _checkQualityCount++;
            if (_checkQualityCount == 1) { return random; }
            else return null;
        }

        /// <summary>
        /// Crack method
        /// </summary>
        /// <exception cref="Exception">Checks egg quality and throws an exception</exception>
        public void Crack()
        {
            if (GetQuality() <= 25)
            {
                throw new Exception("The Egg is rotten");
            }
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
        public void Cook()
        {

        }
    }
}
