using System;

namespace StorageUPD
{
    class Program
    {
        static void Main(string[] args)
        {
            var s1 = new Storage();     
            s1.ProblemWithProduct += LogFileWriteEvent.WriteInLogTXT;
            s1.ProblemWithProduct += Storage.UserInitialisation;
            s1.GetBadDairyProductsEvent += DairyProductsHandlers.WriteInConsole;
            s1.GetBadDairyProductsEvent += DairyProductsHandlers.WriteInLogTXT;
            s1.StartFileInitialisation(@"F:\my_study\sigma\p13\Task1\StorageUPD\storageInit1.txt");


            var deletedProduct = s1.DeleteSingleBadProduct();//Звичайний метод
            TaskDecorator taskDecorator = new TaskDecorator(s1, @"F:\my_study\sigma\p13\Task1\StorageUPD\StorageUPD\log.txt");//Вивід інформації про видалений продукт відбудеться сюди
            taskDecorator.DeleteSingleBadProduct();

            s1.MaxLimits = (2, 1, 1);//Встановлення обмежень на кількість різних товарів 
            s1.AddProduct(new Product("Bread", 250, 13, 14, new DateTime(2021, 10, 3)));
            s1.FindCurrentCount();
            taskDecorator.AddProduct(new MeatProduct("Raw", 250, 13, 14, new DateTime(2021, 10, 3),Sort.Greatest,Type.Pork));//При використанні декоратора буде відбуватись перевірка, чи можна добавляти новий продукт


            Console.WriteLine();

            foreach (Product product in s1)
            {
                Console.WriteLine(product);
            }
        }
    }
}
