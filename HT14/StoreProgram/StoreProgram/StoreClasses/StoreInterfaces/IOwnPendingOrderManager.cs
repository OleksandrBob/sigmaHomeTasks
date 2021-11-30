using System;
using System.Collections.Generic;
using System.Text;

namespace StoreProgram
{
    interface IOwnPendingOrderManager
    {
        PendingOrderManager pendingOrderManager { get; }
    }
}
