using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantApp3.Classes
{
    /// <summary>
    /// Base Class
    /// </summary>
    abstract class MenuItem : IMenuItem
    {
        bool isObtained = false;
        public void Obtain()
        {
            isObtained = true;
        }
        public void Serve()
        {
            if (!isObtained)
            {
                throw new Exception("Food must be obtained first");
            }

        }
    }
}
