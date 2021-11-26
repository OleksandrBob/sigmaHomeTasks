using System;
using System.Collections.Generic;
using System.Text;

namespace StoreProgram
{
    interface IAddOrderToManager 
    {
        void AddOrder(Basket basket);
    }

    interface IChangeOrderManager 
    {
        List<PendingOrder> WatchOrders();
        void RemoveOrder(PendingOrder orderToRemove);
    }

    class PendingOrderManager : IAddOrderToManager, IChangeOrderManager
    {
        private static PendingOrderManager instance = null;

        public static PendingOrderManager GetInstance()
        {
            if (instance == null)
            {
                instance = new PendingOrderManager();
            }

            return instance;
        }



        private List<PendingOrder> allOrders = null;

        private PendingOrderManager()
        {
            this.allOrders = new List<PendingOrder>();
        }

        public void AddOrder(Basket basket)
        {
            allOrders.Add(basket.BuyBasket());
        }

        public List<PendingOrder> WatchOrders()
        {
            return this.allOrders;
        }

        public void RemoveOrder(PendingOrder orderToRemove)
        {
            this.allOrders.Remove(orderToRemove);
        }
    }
}
