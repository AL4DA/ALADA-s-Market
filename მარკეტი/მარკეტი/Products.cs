using System;
namespace მარკეტი
{
	public class Products : Market
	{
		public int ProductID { get; set; }
		public string ProductName { get; set; }
        public int Quantity { get; set; }
		public double Price { get; set; }

        public override string Print()
        {
            return base.Print() + $"Product ID: {ProductID}, Product Name: {ProductName}, Quantity: {Quantity}, Price: {Price} ლარი"; ;
        }
    }
}

