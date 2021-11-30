using System;
using StoreProgram.DataBase;

namespace StoreProgram
{
    class Program
    {
        static void SimulateDataBaseUSE(View view) //All new classes are located in DataBase directory
        {//I also created new constructor for 'Product' and gave ability to use data bases to administrators
            var adm1 = view.SignIn("Sm1th", "ttrrtt") as Administrator;

            try
            {
                adm1.MyDataBase = new SQLiteDataBase(@"data source = ..\..\..\DataBase\SQLite\product.db");
            }
            catch (Exception)
            {
                Console.WriteLine("Cant open this data base");
            }
            adm1.MyDataBase.AddProduct(new Product("Milk", 440, 20, 14, DateTime.UtcNow));

            var specificRecord = adm1.MyDataBase.GetProductByNameSQL("Banana");
            var listOfAllRecords = adm1.MyDataBase.GetProductsList();

            Console.WriteLine(specificRecord.Name + " - " + specificRecord.Price + "\n\n");
            foreach (var prod in listOfAllRecords)
            {
                Console.WriteLine(prod.Name + " - " + prod.Price);
            }
        }


        static void Simulation() 
        {
            var view = new View();
            view.SetManagementSchool(new LvivManagementSchool());

            view.RegisterUser(UserType.ClassicUser, "Anthony|Stariv|rcbxd@gmail.com|Cypress|112331223|rcbxd|qwert321|03.07.2002");
            view.RegisterModerator("Tom", "0rwe11", "skrrtt", "swalddnm");
            view.RegisterAdministrator("Mike", "Sm1th", "ttrrtt", "swalddnm");


            var user1 = view.SignIn("rcbxd", "qwert321") as ClassicUser;

            var mod1 = view.SignIn("0rwe11", "skrrtt") as Moderator;
            var adm1 = view.SignIn("Sm1th", "ttrrtt") as Administrator;

            SimulateDataBaseUSE(view);
            return;

            adm1.ConnectStorage(new LvivStorage());

            var storages = adm1.WatchAllStorages();
            storages[0].AddProductToStorage(new Product("Milk", 440, 20, 14, DateTime.UtcNow));


            var productsFound = user1.SearchProducts("Milk");
            user1.AddProductToBasket(1, productsFound[0], 2);
            user1.RemoveProductFromBasket(1, productsFound[0], 1);
            user1.MakeOrder(1);


            var allOrders = mod1.WatchOrders(mod1);
            mod1.RemoveOrder(allOrders[0]);
            mod1.WatchOrders(mod1);
        }

        static void Main(string[] args)
        {
            Simulation();        
        }
    }
}
//    UserManager.InitUserManager();
//    AdminManager.InitAdminManager();

// Store.InitStore(UserManager.GetInstance(), StorageManager.GetInstance(), AdminManager.GetInstance(), PendingOrderManager.GetInstance());

//    var store = Store.GetInstance();
//    var userManager = UserManager.GetInstance();
//    userManager.SetMainStore(store);
//    var adminManager = AdminManager.GetInstance();
//    adminManager.SetMainStore(store);

//    userManager.RegisterNewUser(UserType.ClassicUser, "Anthony|Stariv|rcbxd@gmail.com|Cypress|112331223|rcbxd|qwert321|03.07.2002");
//    var concreteUser = userManager.SignIn("rcbxd","qwert321");1111!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
//    //concreteUser.DeleteMyAccount();

//    var milkProd = new Product("Milk", 440, 20, 14, DateTime.UtcNow);
//    var sausageProd = new Product("Saussage", 800, 90, 20, DateTime.UtcNow);
//    concreteUser.AddProductToBasket(1, milkProd, 2);
//    concreteUser.AddProductToBasket(1, sausageProd, 1);

//    concreteUser.ShowBasketProducts(1);
//    concreteUser.RemoveProductFromBasket(1, milkProd, 1);


//    concreteUser.MakeOrder(1);
//    adminManager.ManagmentSchool = new LvivManagementSchool();
//    adminManager.RegisterNewAdministrator("Mike", "Smith", "ttrrtt", "swalddnm");
//    var concreteAdmin = adminManager.SingInAdministrator("Smith", "ttrrtt");

//    concreteAdmin.ConnectStorage(new LvivStorage());
//    var storages = concreteAdmin.WatchAllStorages();
//    storages[0].AddProductToStorage(milkProd);


//    concreteUser.SearchProducts("Milk");


//    adminManager.RegisterNewModerator("Tom", "Orwell", "skrrtt", "swalddnm");
//    var concreteModerator = adminManager.SingInModerator("Orwell", "skrrtt");

//    concreteModerator.WatchOrders(concreteModerator);
//    concreteModerator.SetDiscountPolicy(UserType.VIPUser, (float)2.2);