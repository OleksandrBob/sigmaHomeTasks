using System;
using System.Collections.Generic;
using System.Text;

namespace StoreProgram
{
    class LvivManagementSchool : IAbstractSchool
    {
        public Administrator CreateAdministrator(string name, string login, string password, IAdminManagerForAdministrator myAdminManager)
        {
            return new LvivAdministrator(name, login, password, myAdminManager);
        }


        public Moderator CreateModerator(string name, string login, string password, IAdminManagerForModerator myAdminManager)
        {
            return new LvivModerator(name, login, password, myAdminManager);
        }
    }
}
