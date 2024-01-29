using System;
namespace მარკეტი
{
	public class Category : Market
	{
		public string categories { get; set; }

        public override string Print2()
        {
            return base.Print2() + $"Category: {categories}";
        }
    }
}

