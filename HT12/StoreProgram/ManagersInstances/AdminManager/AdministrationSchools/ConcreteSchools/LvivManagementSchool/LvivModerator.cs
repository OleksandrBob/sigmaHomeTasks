using System;
using System.Collections.Generic;
using System.Text;

namespace StoreProgram
{
    class LvivModerator : Moderator
    {
        public LvivModerator(string name, string login, string password, IAdminManagerForModerator myAdminManager)
        {
            this.Name = name;
            this.Login = login;
            this.Password = password;

            this.myAdminManager = myAdminManager;
        }

        public override void RemoveOrder(PendingOrder orderToRemove)
        {
            this.myAdminManager.GetAccessToOrderManager().RemoveOrder(orderToRemove);
        }

        public override void SetDiscountPolicy(UserType userType, float discount)
        {
            this.myAdminManager.GetAccessToStorageManager().SetDiscountPolicy(userType, discount);
        }

        public override List<PendingOrder> WatchOrders(Moderator moderator)
        {
            return this.myAdminManager.GetAccessToOrderManager().WatchOrders();
        }
    }
}
