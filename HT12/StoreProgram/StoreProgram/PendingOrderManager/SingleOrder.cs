using System;
using System.Collections.Generic;
using System.Text;

namespace StoreProgram
{
    class SingleOrder
    {
        public IProduct Product { get; protected set; }
        public int Count { get; protected set; }
        public double PriceOfOrder { get; protected set; }

        public SingleOrder(IProduct product, int count)
        {
            this.Product = product;
            this.Count = count;
            this.PriceOfOrder = count * product.Price;
        }

        public void ChangeCount(int newCount) 
        {
            this.Count = newCount;
            this.PriceOfOrder = this.Count * this.Product.Price;
        }
    }
}
