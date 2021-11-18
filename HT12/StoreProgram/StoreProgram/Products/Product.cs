using System;
using System.Collections.Generic;
using System.Text;

namespace StoreProgram
{
    class Product : IProduct
    {
        public string Name { get; protected set; }

        public int Weight { get; protected set; }

        public double Price { get; protected set; }

        public int ExpirationDate { get; protected set; }

        public DateTime CreationTime { get; protected set; }


        public Product(string name, int weight, double price, int expirationDate, DateTime creationTime) 
        {
            this.Name = name;
            this.Weight = weight;
            this.Price = price;
            this.ExpirationDate = expirationDate;
            this.CreationTime = creationTime;
        }
    }
}
