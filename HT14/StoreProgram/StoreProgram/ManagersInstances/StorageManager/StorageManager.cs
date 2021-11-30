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
        void ConnectStorage(AbstractStorage storageToAdd);
        void RemoveSorage(AbstractStorage storageToRemove);
    }


    class StorageManager : IStorageManagerForUser, IStorageManagerForModerator, IStorageManagerForAdministrator
    {
        private static StorageManager instance = null;
        public static StorageManager GetInstance()
        {
            if (instance == null)
            {
                instance = new StorageManager();
            }

            return instance;
        }


        private List<AbstractStorage> storages = null;
        private StorageManager() 
        {
            storages = new List<AbstractStorage>();
        }

        private UserType _userType;
        private float _discount;

        public List<IProduct> SearchProducts(string searchingParameters)
        {
            List<IProduct> searchedProducts = new List<IProduct>();
            foreach (AbstractStorage storage in storages) 
            {
                searchedProducts.AddRange(storage.SearchForProducts(searchingParameters));
            }

            return searchedProducts;
        }

        public void SetDiscountPolicy(UserType userType, float discount)
        {
            this._discount = discount;
            this._userType = userType;
        }

        public List<IStorageForAdministrator> WatchAllStorages()
        {
            return new List<IStorageForAdministrator>(storages);
        }

        public void ConnectStorage(AbstractStorage storageToAdd)
        {
            storages.Add(storageToAdd);
        }

        public void RemoveSorage(AbstractStorage storageToRemove)
        {
            storages.Remove(storageToRemove);
        }
    }
}
