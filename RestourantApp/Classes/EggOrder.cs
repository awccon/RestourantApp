using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestourantApp.Classes
{
    internal class EggOrder
    {
        private int _quantity = 0; // Quantity
        private int _checkQualityCount = 0;
        private int random = new Random().Next(101);


        // Constructor
        public EggOrder(int quantity)
        {
            _quantity = quantity;
        }

        // returns quantity from Constructor
        public int GetQuantity()
        {
            return _quantity;
        }

        //1: 55, 2: null, 3: 45, 4: null, 

        // Nullable Method returns int value and also sometimes Null
        public int? GetQuality()
        {
            //CR: quality of the egg should be specific to an instance. It shouldn't renew ever =y time I call the method. It should be different when I create a new EggOrder class.
            _checkQualityCount++;
            if (_checkQualityCount == 1) { return random; }
            else  return null;
            

              // Generating egg quality
            //return random;
        }

        public void Crack()
        {
            if (GetQuality() <= 25)
            {
                throw new Exception("The Egg is rotten");
            }
        }

        public void DiscardShell()
        {

        }

        public void Cook()
        {

        }
    }
}
