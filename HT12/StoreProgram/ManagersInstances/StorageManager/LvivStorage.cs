using System;
using System.Collections.Generic;
using System.Text;

namespace StoreProgram
{
    class LvivStorage : AbstractStorage
    {
        public LvivStorage() 
        {
            this.products = new List<IProduct>();
        }

    }
}
