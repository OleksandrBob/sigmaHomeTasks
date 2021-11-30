using System;
using System.Collections.Generic;
using System.Text;

namespace StoreProgram
{
    abstract class Moderator
    {
        public string Name { get; protected set; }
        public string Login { get; protected set; }
        public string Password { get; protected set; }

        protected IAdminManagerForModerator myAdminManager { get;  set; }

        public abstract List<PendingOrder> WatchOrders(Moderator moderator);
        public abstract void RemoveOrder(PendingOrder orderToRemove);
        public abstract void SetDiscountPolicy(UserType userType, float discount);
    }
}
