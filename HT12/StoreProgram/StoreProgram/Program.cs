using System;

namespace StoreProgram
{
    class Program
    {
        static void Main(string[] args)
        {
            UserManager.InitUserManager();
            Store.InitStore(UserManager.GetInstance(), new StorageManager(), new AdminManager());

            var store = Store.GetInstance();
            var userManager = UserManager.GetInstance();
            userManager.myStore = store;

            userManager.RegisterNewUser(UserType.ClassicUser, "Anthony|Stariv|rcbxd@gmail.com|Cypress|112331223|rcbxd|qwert321|03.07.2002");

            var concreteUser = userManager.SignIn("rcbxd","qwert321");
            concreteUser.DeleteMyAccount();
        }
    }
}
