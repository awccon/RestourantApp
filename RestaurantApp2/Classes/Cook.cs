using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantApp2.Classes
{
    internal class Cook
    {
        private static int quantityOfChicken;
        private static int quantityOfEgg;
        public Cook(int QuantityOfChicken, int QuantityOfEgg)
        {
            quantityOfChicken = QuantityOfChicken;
            quantityOfEgg = QuantityOfEgg;
        }
        
        public (object, object) PrepareFood()
        {
            ChickenOrder chicken = new ChickenOrder(quantityOfChicken);
            EggOrder egg = new EggOrder(quantityOfEgg);
            for (int i = 0; i < chicken.GetQuantity(); i++)
            {
                chicken.CutUp();
            }
            chicken.Cook();

            for (int i = 0; i < egg.GetQuantity(); i++)
            {
                egg.Crack();
                egg.DiscardShell();
            }
            egg.Cook();
            return (chicken, egg);
        }

    }
}
