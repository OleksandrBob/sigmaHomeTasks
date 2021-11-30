using System;
using System.Collections.Generic;
using System.Text;

namespace StoreProgram
{
    interface IAbstractSchool
    {
        Administrator CreateAdministrator(string name, string login, string password, IAdminManagerForAdministrator myAdminManager);
        Moderator CreateModerator(string name, string login, string password, IAdminManagerForModerator myAdminManager);
    }
}
