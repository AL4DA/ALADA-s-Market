using System;
namespace მარკეტი
{
	public class ShoppingCartItem : User
	{
        public int OrderID { get; set; }
        public Products Product { get; set; }

        
        public int Quantity { get; set; }

        public ShoppingCartItem(Products Ordername, int quantity, int orderid)
        {
            OrderID = orderid;
            Product = Ordername;
            Quantity = quantity;
        }

        public override string Print3()
        {
            return base.Print3() + $"Order ID {OrderID}, Product {Product.ProductName}, Quantity {Quantity}  ";
        }
    }
}

