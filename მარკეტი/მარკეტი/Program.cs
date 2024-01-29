using System;
using System.Collections.Generic;
using System.Runtime.ConstrainedExecution;
using მარკეტი;

namespace MarketProject
{
    internal class Program
    {
        public static int orderIdCounter = 1;

        public static int GenerateOrderId()
        {
            return orderIdCounter++;
        }

        static void Main(string[] args)
        {
            List<Market> markets = new List<Market>()
            {
                new Products()
                {
                    ProductID = 1,
                    ProductName = "Coca-Cola",
                    Quantity = 145,
                    Price = 1.90,
                },
                new Products()
                {
                    ProductID = 2,
                    ProductName = "Pepsi",
                    Quantity = 78,
                    Price = 1.70,
                },
                new Category()
                {
                    categories = "A soft drink",
                }
            };
            List<Admin> admins = new List<Admin>()
            {
                new Admin(){ name = "Admin", password = "Admin"}
            };
            List<User> users = new List<User>()
            {
                new User(){Name = "Lasha", Password = "Aladashvili"}
            };
            Selector(markets, admins, users);
        }

        public static void Selector(List<Market> markets, List<Admin> admins, List<User> users)
        {
            int manage = 0;

            while (manage != 3)
            {
                Console.WriteLine("ALADA's Market");
                Console.WriteLine("1. Admin");
                Console.WriteLine("2. User");
                Console.WriteLine("3. Exit");
                Console.Write("Enter your choice: ");
                manage = int.Parse(Console.ReadLine());

                switch (manage)
                {
                    case 1:
                        Console.Write("Enter admin name: ");
                        string adminName = Console.ReadLine();
                        Console.Write("Enter admin password: ");
                        string adminPassword = Console.ReadLine();
                        AdminMenu(admins, markets, adminName, adminPassword);
                        break;
                    case 2:
                        Console.Write("Enter User name: ");
                        string userName = Console.ReadLine();
                        Console.Write("Enter User password: ");
                        string UserPass = Console.ReadLine();
                        UserPanel(users, markets, userName, UserPass);
                        break;
                    case 3:
                        Console.WriteLine("Exiting...");
                        break;
                    default:
                        Console.WriteLine("Invalid choice. Please try again.");
                        break;
                }
            }
        }

        public static void AdminMenu(List<Admin> admins, List<Market> markets, string adminName, string adminPassword)
        {
            int manage = 0;
            string item;
            while (manage != 7)
            {
                foreach (var admin in admins)
                {
                    if (admin.name == adminName && admin.password == adminPassword)
                    {
                        Console.WriteLine("\nAdmin Menu | ALADA's Market");
                        Console.WriteLine("1. View Products");
                        Console.WriteLine("2. Search Products");
                        Console.WriteLine("3. Add Product");
                        Console.WriteLine("4. Edit Product");
                        Console.WriteLine("5. Delete Product");
                        Console.WriteLine("6. View Category");
                        Console.WriteLine("7. Back to Main Menu");
                        Console.Write("Enter your choice: ");
                        manage = int.Parse(Console.ReadLine());

                        if (manage == 1)
                        {
                            ViewProduct(markets);
                        }
                        if (manage == 2)
                        {
                            Console.Write("Enter the product name to search: ");
                            item = Console.ReadLine();
                            SearchProducts(markets, item);
                        }
                        if (manage == 3)
                        {
                            AddProduct(markets);
                        }
                        if (manage == 4)
                        {
                            UpdateProduct(markets);
                        }
                        if (manage == 5)
                        {
                            DeleteProduct(markets);
                        }
                        if (manage == 6)
                        {
                            ViewCategory(markets);
                        }
                        if (manage == 7)
                        {
                            Console.WriteLine("Exiting...");
                        }
                    }
                }
            }
            Console.WriteLine("Invalid admin credentials.");
        }

        public static void ViewProduct(List<Market> markets)
        {
            foreach (var product in markets)
            {
                Console.WriteLine(product.Print());
            }
        }

        public static void SearchProducts(List<Market> markets, string item)
        {
            foreach (var marketItem in markets)
            {
                if (marketItem is Products && ((Products)marketItem).ProductName == item)
                {
                    Console.WriteLine(marketItem.Print());
                    return;
                }
            }
            Console.WriteLine("Product not found.");
        }

        public static void AddProduct(List<Market> markets)
        {
            Console.WriteLine("Enter the details of the product:");
            Console.Write("Product ID: ");
            int productid = int.Parse(Console.ReadLine());
            Console.Write("Product Name: ");
            string productname = Console.ReadLine();
            Console.Write("Quantity: ");
            int quantity = int.Parse(Console.ReadLine());
            Console.Write("Product Price: ");
            double productprice = double.Parse(Console.ReadLine());

            Products prod = new Products()
            {
                ProductID = productid,
                ProductName = productname,
                Quantity = quantity,
                Price = productprice
            };
            markets.Add(prod);
            Console.WriteLine("Product added successfully!");
        }

        public static void UpdateProduct(List<Market> markets)
        {
            Console.WriteLine("Enter the Product ID of the product you want to update:");
            int productId = int.Parse(Console.ReadLine());

            Products products;
            string productName;
            int quantity;
            double productPrice;
            bool found = false;

            foreach (var marketitem in markets)
            {
                if (marketitem is Products && ((Products)marketitem).ProductID == productId)
                {
                    products = marketitem as Products;
                    found = true;
                    Console.WriteLine("Enter the new details of the product:");
                    Console.Write("Product Name: ");
                    productName = Console.ReadLine();
                    Console.Write("Quantity");
                    quantity = int.Parse(Console.ReadLine());
                    Console.Write("Product Price: ");
                    productPrice = double.Parse(Console.ReadLine());

                    ((Products)marketitem).ProductName = productName;
                    ((Products)marketitem).Price = productPrice;
                    ((Products)marketitem).Quantity = quantity;

                    Console.WriteLine("Product updated successfully!");
                    break;
                }
            }
            if (!found)
            {
                Console.WriteLine("Product not found");
            }
        }

        public static void DeleteProduct(List<Market> markets)
        {
            Console.WriteLine("Enter the Product ID of the product you want to delete:");
            int productId = int.Parse(Console.ReadLine());

            Products products;

            bool found = false;

            for (int i = 0; i < markets.Count; i++)
            {
                if (markets[i] is Products && ((Products)markets[i]).ProductID == productId)
                {
                    found = true;
                    markets.RemoveAt(i);
                    Console.WriteLine("Product deleted successfully!");
                    break;
                }
            }
            if (!found)
            {
                Console.WriteLine("Product not found.");
            }
        }

        public static void ViewCategory(List<Market> markets)
        {
            foreach (var item in markets)
            {
                Console.WriteLine(item.Print2());
            }
        }

        public static void UserPanel(List<User> users, List<Market> markets, string name, string password)
        {
            int manage = 0;
            string item;
            int generatedOrderId;
            int itemid;
            while (manage != 6)
            {
                foreach (var userlogin in users)
                {
                    if (userlogin.Name == name && userlogin.Password == password)
                    {
                        Console.WriteLine("\nUser Menu | ALADA's Market");
                        Console.WriteLine("1.View Products");
                        Console.WriteLine("2.Find Products");
                        Console.WriteLine("3.Add Product to Cart");
                        Console.WriteLine("4.View Cart");
                        Console.WriteLine("5.Checkout");
                        Console.WriteLine("6.Back to Main Menu");
                        Console.Write("Enter your choice: ");
                        manage = int.Parse(Console.ReadLine());

                        if (manage == 1)
                        {
                            ViewProduct(markets);
                        }
                        if (manage == 2)
                        {
                            Console.Write("Enter the product name to search: ");
                            item = Console.ReadLine();
                            SearchProducts(markets, item);
                        }
                        if (manage == 3)
                        {
                            Console.Write("Enter the ID of the product to add to cart: ");
                            itemid = int.Parse(Console.ReadLine());
                            generatedOrderId = GenerateOrderId();
                            AddToCartList(users, markets, itemid, generatedOrderId);
                        }
                        if (manage == 4)
                        {
                            ViewCart(users);
                        }
                        if (manage == 5)
                        {
                            Checkout(users);
                        }
                        if (manage == 6)
                        {
                            Console.WriteLine("Exiting...");
                        }
                    }
                }
            }
            Console.WriteLine("Invalid User credentials.");
        }
        public static void AddToCartList(List<User> users, List<Market> markets, int productid, int orderid)
        {
            Console.Write("Enter the quantity: ");
            int quantity = int.Parse(Console.ReadLine());

            Products productsToAdd = null;

            foreach (var marketitem in markets)
            {
                if (marketitem is Products && ((Products)marketitem).ProductID == productid)
                {
                    productsToAdd = (Products)marketitem;
                    break;
                }
            }
            if (productsToAdd != null)
            {
                Console.Write("Enter the user name: ");
                string userName = Console.ReadLine();
                User user = null;

                foreach (var item in users)
                {
                    if (item.Name == userName)
                    {
                        user = item;
                    }
                }
                if (user != null)
                {
                    user.ShoppingCart.Add(new ShoppingCartItem(productsToAdd, quantity, orderid));
                    Console.WriteLine("Product added to cart successfully!");
                }
                else
                {
                    Console.WriteLine("User not found.");
                }
            }
            else
            {
                Console.WriteLine("Product not found.");
            }
        }
        public static void ViewCart(List<User> users)
        {
            foreach (var user in users)
            {
                Console.WriteLine($"User: {user.Name}'s Shopping Cart:");
                foreach (var item in user.ShoppingCart)
                {
                    Console.WriteLine(item.Print3());
                }
            }
        }
        public static void Checkout(List<User> users)
        {
            int paymentoption;
            double totalAmount;
            foreach (var user in users)
            {
                Console.WriteLine($"User: {user.Name}'s Shopping Cart:");
                totalAmount = 0;
                foreach (var item in user.ShoppingCart)
                {
                    Console.WriteLine(item.Print3());
                    totalAmount += item.Quantity * item.Product.Price;
                }
                Console.WriteLine($"Total Amount: {totalAmount}");
                Console.WriteLine();
                Console.WriteLine("Select payment method:");
                Console.WriteLine("1. Credit/Debit Card");
                Console.WriteLine("2. Cash on Delivery");
                paymentoption = int.Parse(Console.ReadLine());

                if (paymentoption == 1)
                {
                    Console.WriteLine("Credit/Debit Card Payment Method Comming Soon");
                }
                if (paymentoption == 2)
                {
                    Console.WriteLine("Cash on delivery. Your order will be delivered shortly.");
                }

                foreach (var item in user.ShoppingCart)
                {
                    item.Product.Quantity -= item.Quantity;
                }

                user.ShoppingCart.Clear();
                Console.WriteLine("Order confirmed!");
                Console.WriteLine("Thank you for shopping with us!");
            }
        }
    }
}
