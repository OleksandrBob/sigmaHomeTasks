using System;

namespace StoreProgram
{
    class Program
    {
        static void Main(string[] args)
        {
            UserManager.InitUserManager();
            AdminManager.InitAdminManager();
            Store.InitStore(UserManager.GetInstance(), new StorageManager(), AdminManager.GetInstance(), PendingOrderManager.GetInstance());

            var store = Store.GetInstance();
            var userManager = UserManager.GetInstance();
            userManager.SetMainStore(store);
            var adminManager = AdminManager.GetInstance();
            adminManager.SetMainStore(store);

            userManager.RegisterNewUser(UserType.ClassicUser, "Anthony|Stariv|rcbxd@gmail.com|Cypress|112331223|rcbxd|qwert321|03.07.2002");
            var concreteUser = userManager.SignIn("rcbxd","qwert321");
            concreteUser.DeleteMyAccount();

            var milkProd = new Product("Milk", 440, 20, 14, DateTime.UtcNow);
            var sausageProd = new Product("Saussage", 800, 90, 20, DateTime.UtcNow);
            concreteUser.AddProductToBasket(1, milkProd, 2);
            concreteUser.AddProductToBasket(1, sausageProd, 1);

            concreteUser.ShowBasketProducts(1);
            concreteUser.RemoveProductFromBasket(1, milkProd, 1);


            concreteUser.MakeOrder(1);




            //concreteUser.SearchProducts();
        }
    }
}
