using System;
using System.Collections.Generic;
using System.Text;

namespace StoreProgram
{
    class PendingOrder
    {
        private List<SingleOrder> orders = null;
        private User orderReceiver = null;
        public DateTime timeOfCreation { get; private set; }

        public PendingOrder(List<SingleOrder> orders, User orderReceiver)
        {
            this.orders = orders;
            this.orderReceiver = orderReceiver;
            this.timeOfCreation = DateTime.UtcNow;
        }


    }
}
