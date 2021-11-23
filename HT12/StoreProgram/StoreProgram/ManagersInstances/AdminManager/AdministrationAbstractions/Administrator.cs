using System;
using System.Collections.Generic;
using System.Text;

namespace StoreProgram
{
    abstract class Administrator
    {
        public string Name { get; protected set; }
        public string Login { get; protected set; }
        public string Password { get; protected set; }

        protected IAdminManagerForAdministrator myAdminManager { get; set; }

        public abstract List<IStorageForAdministrator> WatchAllStorages();
        public abstract void ConnectStorage(AbstractStorage storageToConnect);
        public abstract void RemoveStorage(AbstractStorage storageToRemove);
        public abstract List<User> WatchAllUsers();
        public abstract void ChangeStatus(User user, UserType newUserType);

    }
}
