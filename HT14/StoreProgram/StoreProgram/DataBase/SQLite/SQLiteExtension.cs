using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace StoreProgram.DataBase
{
    static class SQLiteExtension
    {
        public static List<IProduct> GetProductsList(this SQLiteDataBase dataBase) 
        {
            return dataBase.GetRecords<IProduct>("SELECT * FROM Products", Product.CreateFromRecord);
        }

        public static IProduct GetProductByNameLINQ(this SQLiteDataBase dataBase, string productName) 
        {
            return dataBase.GetProductsList().Where(prod => productName == prod.Name).FirstOrDefault();
        }

        public static IProduct GetProductByNameSQL(this SQLiteDataBase dataBase, string productName)
        {
            return dataBase.GetRecords<IProduct>($"select * from Products where Name like '{productName}%' limit 1", Product.CreateFromRecord).FirstOrDefault();
        }

        public static void AddProduct(this SQLiteDataBase dataBase, IProduct productToWrite) 
        {
            dataBase.ExecuteSQL("insert into Products (Name, Weight, Price, ExpirationDate, CreationTime) values(" +
                                "'" + productToWrite.Name + "', " +
                                "'" + productToWrite.Weight + "', " +
                                "'" + productToWrite.Price + "', " +
                                "'" + productToWrite.ExpirationDate + "', " +
                                "'" + productToWrite.CreationTime + "');");
        }
    }
}
