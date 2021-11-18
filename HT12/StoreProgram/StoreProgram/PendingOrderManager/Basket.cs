using System;
using System.Collections.Generic;
using System.Text;

namespace StoreProgram
{
    class Basket
    {
        private readonly User basketOwner = null;
        public readonly int BasketNumber;
        List<SingleOrder> basketOrders = null;
        public double totalPrice { get; private set; }

        public Basket(User owner, int basketNumber)
        {
            this.basketOwner = owner;
            this.BasketNumber = basketNumber;
            this.basketOrders = new List<SingleOrder>();
        }

        public void AddProduct(IProduct product, int count)
        {
            foreach (SingleOrder order in basketOrders)
            {
                if (order.Product == product)
                {
                    order.ChangeCount(order.Count + count);
                    RecalculateTotalPrice();
                    return;
                }
            }

            basketOrders.Add(new SingleOrder(product, count));
            RecalculateTotalPrice();
        }

        protected void RecalculateTotalPrice() 
        {
            this.totalPrice = 0;

            foreach (SingleOrder order in basketOrders)
            {
                this.totalPrice += order.PriceOfOrder;
            }
        }

        public void RemoveProduct(IProduct product, int count)
        {
            foreach (SingleOrder order in basketOrders)
            {
                if (product == order.Product)
                {
                    if (count < order.Count)
                    {
                        order.ChangeCount(order.Count - count);
                    }
                    else
                    {
                        basketOrders.Remove(order);
                    }
                    RecalculateTotalPrice();

                    return;
                }
            }
                        
            throw new Exception("Impossible to remove an unexisting product");
        }

        public List<IProduct> GetProducts() 
        {
            List<IProduct> products = new List<IProduct>();

            foreach (SingleOrder order in basketOrders)
            {
                products.Add(order.Product);
            }


            return products;
        }

    }
}
