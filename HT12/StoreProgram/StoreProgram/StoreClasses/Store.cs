using System;
using System.Collections.Generic;
using System.Text;

namespace StoreProgram
{
    class Store : IOwnStorageManager, IOwnAdminManager, IOwnUserManager
    {
        private static Store mainStore = null;
        public UserManager userManager { get; private set; }
        public StorageManager storageManager { get; private set; }
        public AdminManager adminManager { get; private set; }

        private Store(UserManager userManager, StorageManager storageManager, AdminManager adminManager)
        {
            this.userManager = userManager;
            this.storageManager = storageManager;
            this.adminManager = adminManager;
        }


        public static void InitStore(UserManager userManager, StorageManager storageManager, AdminManager adminManager)
        {
            mainStore = new Store(userManager, storageManager, adminManager);
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
