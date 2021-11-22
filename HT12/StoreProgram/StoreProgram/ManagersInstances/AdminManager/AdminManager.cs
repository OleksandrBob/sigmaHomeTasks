using System;
using System.Collections.Generic;
using System.Text;

namespace StoreProgram
{
    interface IAdminManagerForAdministrator 
    {
        IStorageManagerForAdministrator GetAccessToStorageManager();
        IUserManagerForAdministrator GetAccessToUserManager();
    }

    interface IAdminManagerForModerator 
    {
        IChangeOrderManager GetAccessToOrderManager();
        IStorageManagerForModerator GetAccessToStorageManager();
    }

    class AdminManager : IAdminManagerForModerator, IAdminManagerForAdministrator
    {
        private static AdminManager adminManager = null;
        public Store myStore = null;
        private List<Administrator> administrators = null;
        private List<Moderator> moderators = null;

        private AdminManager()
        {
            this.administrators = new List<Administrator>();
            this.moderators = new List<Moderator>();
        }

        public static void InitAdminManager() 
        {
            adminManager = new AdminManager();
        }

        public void SetMainStore(Store myStore)
        {
            this.myStore = myStore;
        }

        public static AdminManager GetInstance() 
        {
            return adminManager ?? throw new Exception("Admin manager is uninitialised. Impossible to use it");
        }

        IChangeOrderManager IAdminManagerForModerator.GetAccessToOrderManager()
        {
            return this.myStore.pendingOrderManager;
        }

        IStorageManagerForModerator IAdminManagerForModerator.GetAccessToStorageManager()
        {
            return this.myStore.storageManager;
        }


        IStorageManagerForAdministrator IAdminManagerForAdministrator.GetAccessToStorageManager()
        {
            return this.myStore.storageManager;
        }

        IUserManagerForAdministrator IAdminManagerForAdministrator.GetAccessToUserManager()
        {
            return this.myStore.userManager;
        }
    }
}
