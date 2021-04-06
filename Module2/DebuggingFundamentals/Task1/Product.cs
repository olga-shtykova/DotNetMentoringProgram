using System;
using System.Diagnostics.CodeAnalysis;

namespace Task1
{
    public class Product : IEquatable<Product>    
    {
        public Product(string name, double price)
        {
            Name = name;
            Price = price;
        }

        public string Name { get; set; }

        public double Price { get; set; }          

        public override bool Equals(object obj)
        {
            if (obj == null) return false;

            Product productObj = obj as Product;

            if (productObj == null) return false;

            return Equals(productObj);
        }

        public override int GetHashCode() => (Name, Price).GetHashCode();

        public bool Equals(Product other) =>
            (other != null) &&
            (Name, Price) == (other.Name, other.Price);

        public static bool operator ==(Product product1, Product product2)
        {
            if (((object)product1 == null) || ((object)product2 == null))
                return Equals(product1, product2);

            return product1.Equals(product2);
        }

        public static bool operator !=(Product product1, Product product2)
        {
            if (((object)product1 == null) || ((object)product2 == null))
                return !Equals(product1, product2);

            return !(product1.Equals(product2));
        }
    }
}
