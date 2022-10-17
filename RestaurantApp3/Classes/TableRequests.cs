using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantApp3.Classes
{
    /// <summary>
    /// Usefull to set the status of order:
    /// Served, Sent, Ordered
    /// </summary>
    public enum orderStatus
    {
        Ordered,
        Sent,
        Served
    }

    /// <summary>
    /// it can get an orders with method Add, returns an orders with customer id and menu item
    /// </summary>
    internal class TableRequests
    {
        /// <summary>
        /// Returns the number of customers
        /// </summary>
        public int CustomerCount
        {
            get
            {
                return customerOrders.Length;
            }
        }

        private IMenuItem[][] customerOrders = new IMenuItem[0][];
        public orderStatus status;

        /// <summary>
        /// This method gets customer id and type of menu item and saves to array
        /// </summary>
        /// <param name="customerId"></param>
        /// <param name="menuItem"></param>
        public void Add(int customerId, IMenuItem menuItem)
        {
            if (customerId > 8)
                throw new Exception("In this table we can only serve up to 8 customers");

            var singleCustomerOrder = new IMenuItem[0];
            bool newCustomer = true;
            if (customerOrders.Length >= customerId)
            {
                singleCustomerOrder = customerOrders[customerId - 1];
                newCustomer = false;
            }
            Array.Resize(ref singleCustomerOrder, singleCustomerOrder.Length + 1);
            singleCustomerOrder[singleCustomerOrder.Length - 1] = menuItem;
            if (newCustomer)
            {
                Array.Resize(ref customerOrders, customerOrders.Length + 1);
            }
            customerOrders[customerOrders.Length - 1] = singleCustomerOrder;
        }

        /// <summary>
        /// indexer for each customer order
        /// </summary>
        /// <param name="customerID">integer value from 1 to 8</param>
        /// <returns>each customer order</returns>
        public IMenuItem[] this[int customerID]
        {
            get
            {
                return customerOrders[customerID];
            }
        }

        /// <summary>
        /// indexer for each menu item
        /// </summary>
        /// <param name="menuItemType">gets new instance of menu item</param>
        /// <returns>array of menu items</returns>
        public IMenuItem[] this[Type menuItemType]
        {
            get
            {
                IMenuItem[] orderItems = new IMenuItem[0];
                foreach (var singleCustomerOrder in customerOrders)
                {
                    foreach (var customerOrder in singleCustomerOrder)
                    {
                        if (menuItemType.IsAssignableFrom(customerOrder.GetType()))
                        {
                            Array.Resize(ref orderItems, orderItems.Length + 1);
                            orderItems[orderItems.Length - 1] = customerOrder;
                        }
                    }
                }
                return orderItems;
            }
        }


        /// <summary>
        /// this method cleans all customers orders from main list
        /// </summary>
        public void CleanCustomersOrder()
        {
            customerOrders = new MenuItem[0][];
        }
    }
}
