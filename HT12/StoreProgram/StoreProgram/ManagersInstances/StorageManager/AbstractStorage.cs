using System;
using System.Collections.Generic;
using System.Text;

namespace StoreProgram
{
    interface IStorageForAdministrator 
    {
        List<IProduct> WatchProductsInStorage();
        void AddProductToStorage(IProduct productToAdd);
        void DeleteProductFromStorage(IProduct productToDelete);
    }

    abstract class AbstractStorage : IStorageForAdministrator
    {
        protected List<IProduct> products = null;

        public void AddProductToStorage(IProduct productToAdd)
        {
            products.Add(productToAdd);
        }

        public void DeleteProductFromStorage(IProduct productToDelete)
        {
            products.Remove(productToDelete);
        }

        public List<IProduct> WatchProductsInStorage()
        {
            return products;
        }

        public List<IProduct> SearchForProducts(string SearchingParameter) 
        {
            return products.FindAll((prod) => (prod.Name == SearchingParameter));
        }
    }
}
