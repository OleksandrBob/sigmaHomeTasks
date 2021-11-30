using System;
using System.Collections.Generic;
using System.Text;

namespace StoreProgram
{
    interface IProduct
    {
        string Name { get; }
        int Weight { get; }
        double Price { get; }
        int ExpirationDate { get; }
        DateTime CreationTime { get; }

    }
}
