using System;
using System.Collections.Generic;
using System.Text;

namespace StoreProgram
{
    interface IAdminManagerForAdmin 
    {
    //...
    }

    interface IAdminManagerForModerator 
    {
        IChangeOrderManager GetAccessToOrderManager();
        //IOwnStorageManager GetAccessToStorageManager();
    }

    class AdminManager : IAdminManagerForModerator
    {
        private static AdminManager adminManager = null;
        public Store myStore = null;
        private List<User> users = null;


        private AdminManager(Store myStore)
        {
            this.myStore = myStore;
            this.users = new List<User>();
        }

        public static void InitAdminManager(Store myStore) 
        {
            adminManager = new AdminManager(myStore);
        }

        public static AdminManager GetInstance() 
        {
            if (adminManager == null)
            {
                throw new Exception("Admin manager is uninitialised. Impossible to use it");
            }

            return adminManager;
        }

        public IChangeOrderManager GetAccessToOrderManager()
        {
            return this.myStore.pendingOrderManager;
        }


    }
}
