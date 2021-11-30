using System;
using System.Collections.Generic;
using System.Text;

namespace StoreProgram
{
    class Store : IOwnStorageManager, IOwnAdminManager, IOwnUserManager, IOwnPendingOrderManager
    {
        private static Store mainStore = null;
        public UserManager userManager { get; private set; }
        public StorageManager storageManager { get; private set; }
        public AdminManager adminManager { get; private set; }
        public PendingOrderManager pendingOrderManager { get; private set; }

        private Store(UserManager userManager, StorageManager storageManager, AdminManager adminManager,PendingOrderManager pendingOrderManager)
        {
            this.userManager = userManager;
            this.storageManager = storageManager;
            this.adminManager = adminManager;
            this.pendingOrderManager = pendingOrderManager;
        }



        public static void InitStore(UserManager userManager, StorageManager storageManager, AdminManager adminManager, PendingOrderManager pendingOrderManager)
        {
            mainStore = new Store(userManager, storageManager, adminManager, pendingOrderManager);
        }

        public static Store GetInstance()
        {
            if (mainStore == null)
            {
                throw new Exception("Error in 'Store' class\nImpossible to get instance of the store - 'mainSore' is uninitialised.");
            }

            return mainStore;
        }
    }
}
