using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantApp2.Classes
{
    internal class Order
    {
        public int _quantity = 0;
        public Order(int quantity)
        {
            _quantity = quantity;
        }
        public virtual int GetQuantity()
        {
            return _quantity;
        }

        public virtual void Cook()
        {

        }
    }
}
