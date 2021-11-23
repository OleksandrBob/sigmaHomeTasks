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
        public IAbstractSchool ManagmentSchool = null;

        private List<Administrator> administrators = null;
        private List<Moderator> moderators = null;

        private AdminManager()
        {
            this.administrators = new List<Administrator>();
            this.moderators = new List<Moderator>();
        }

        public void RegisterNewModerator(string name, string login, string password, string VerifyAdminRegistration)
        {
            if (VerifyAdminRegistration != "swalddnm")
            {
                return;//Access denied - to register a moderator we should know speccial password
            }

            try
            {
                moderators.Add(ManagmentSchool.CreateModerator(name, login, password, this));
            }
            catch (Exception ex)
            {
                throw new Exception("User manager didn't create a new moderator - " + ex.Message);
            }
        }

        public void RegisterNewAdministrator(string name, string login, string password, string VerifyAdminRegistration)
        {
            if (VerifyAdminRegistration != "swalddnm")
            {
                return;//Access denied - to register a moderator we should know speccial password
            }

            try
            {
                administrators.Add(ManagmentSchool.CreateAdministrator(name, login, password, this));
            }
            catch (Exception ex)
            {
                throw new Exception("User manager didn't create a new moderator - " + ex.Message);
            }
        }

        public Administrator SingInAdministrator(string login, string password) 
        {
            return administrators.Find((admin) => (admin.Login == login && admin.Password == password));
        }

        public Moderator SingInModerator(string login, string password)
        {
            return moderators.Find((moder) => (moder.Login == login && moder.Password == password));
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
