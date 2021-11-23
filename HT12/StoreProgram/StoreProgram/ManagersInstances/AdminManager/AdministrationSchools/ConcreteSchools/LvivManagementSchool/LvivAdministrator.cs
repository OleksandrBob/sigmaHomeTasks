using System;
using System.Collections.Generic;
using System.Text;

namespace StoreProgram
{
    class LvivAdministrator: Administrator
    {
        public LvivAdministrator(string name, string login, string password, IAdminManagerForAdministrator myAdminManager)
        {
            this.Name = name;
            this.Login = login;
            this.Password = password;

            this.myAdminManager = myAdminManager;
        }

        public override void ChangeStatus(User user, UserType newUserType)
        {
            this.myAdminManager.GetAccessToUserManager().ChangeStatus(user, newUserType);
        }

        public override void ConnectStorage(AbstractStorage storageToConnect)
        {
            this.myAdminManager.GetAccessToStorageManager().ConnectStorage(storageToConnect);
        }

        public override void RemoveStorage(AbstractStorage storageToRemove)
        {
            this.myAdminManager.GetAccessToStorageManager().RemoveSorage(storageToRemove);
        }

        public override List<IStorageForAdministrator> WatchAllStorages()
        {
            return this.myAdminManager.GetAccessToStorageManager().WatchAllStorages();
        }

        public override List<User> WatchAllUsers()
        {
            return this.myAdminManager.GetAccessToUserManager().WatchAllUsers();
        }
    }
}
