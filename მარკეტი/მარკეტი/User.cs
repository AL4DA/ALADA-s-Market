using System;
namespace მარკეტი
{
	public class User
	{
        public string Name { get; set; }
        public string Password { get; set; }
        public List<ShoppingCartItem> ShoppingCart { get; set; }

        // Constructor
        public User()
        {
            ShoppingCart = new List<ShoppingCartItem>();
        }
        public virtual string Print3()
        {
            return $"";
        }
    }
}

