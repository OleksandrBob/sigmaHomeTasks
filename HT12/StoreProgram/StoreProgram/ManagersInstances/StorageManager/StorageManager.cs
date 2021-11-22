using System;
using System.Collections.Generic;
using System.Text;

namespace StoreProgram
{
    interface IStorageManagerForUser 
    {
        List<IProduct> SearchProducts(string searchingParameters);
    }

    interface IStorageManagerForModerator 
    {
        void SetDiscountPolicy(UserType userType, float discount);
    }

    interface IStorageManagerForAdministrator 
    {
        List<IStorageForAdministrator> WatchAllStorages();
    }


    class StorageManager : IStorageManagerForUser, IStorageManagerForModerator, IStorageManagerForAdministrator
    {
        private List<AbstractStorage> storages = null;

        public List<IProduct> SearchProducts(string searchingParameters)
        {
            return null;
        }

        public void SetDiscountPolicy(UserType userType, float discount)
        {
            throw new NotImplementedException();
        }

        public List<IStorageForAdministrator> WatchAllStorages()
        {
            return new List<IStorageForAdministrator>(storages);
        }
    }
}
