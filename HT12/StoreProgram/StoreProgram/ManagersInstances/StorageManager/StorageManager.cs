using System;
using System.Collections.Generic;
using System.Text;

namespace StoreProgram
{
    interface ISearchByAllStoragesManager 
    {
        List<IProduct> SearchProducts(string searchingParameters);
    }

    class StorageManager : ISearchByAllStoragesManager
    {
        public List<IProduct> SearchProducts(string searchingParameters)
        {
            return null;
        }
    }
}
