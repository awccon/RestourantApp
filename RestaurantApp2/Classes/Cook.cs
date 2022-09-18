using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantApp2.Classes
{
    internal class Cook
    {

        //CR: Why these fields are static?
        private static int quantityOfChicken;
        private static int quantityOfEgg;
        public Cook(int QuantityOfChicken, int QuantityOfEgg)
        {
            quantityOfChicken = QuantityOfChicken;
            quantityOfEgg = QuantityOfEgg;
        }
        
        //CR: Why the return parameters are object type? 
        public (ChickenOrder, EggOrder) PrepareFood()
        {
            //CR: What is I have no chickens or eggs? Why do I create their instance? 
            ChickenOrder chicken = new ChickenOrder(quantityOfChicken);
            EggOrder egg = new EggOrder(quantityOfEgg);
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
