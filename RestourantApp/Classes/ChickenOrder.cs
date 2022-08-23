using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestourantApp.Classes
{
    internal class ChickenOrder
    {
        private int _quantity = 0; // This is for order quantity

        // Constructor
        public ChickenOrder(int quantity)
        {
            _quantity = quantity;
        }

        // Returns quantity from constructor
        public int GetQuantity()
        {
            return _quantity;
        }

        // Method to cut a meat, it shoul be called the num of times in quantity
        public void CutUp()
        {

        }
        
        // Cooking method
        public void Cook()
        {

        }


    }
}
