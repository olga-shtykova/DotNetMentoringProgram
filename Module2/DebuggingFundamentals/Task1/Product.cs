using System;
using System.Diagnostics.CodeAnalysis;

namespace Task1
{
    public class Product //: IEquatable<Product>
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
            if (obj == null || !(obj is Product))
                return false;

            Product product = obj as Product;

            if((Name, Price) == (product.Name, product.Price))
                return true;

            return false;
        }

        public override int GetHashCode() => (Name, Price).GetHashCode();

        // When using IEquatable<T>

        //public static bool operator ==(Product product1, Product product2) =>
        //   Equals(product1, product2);

        //public static bool operator !=(Product product1, Product product2) =>
        //    !Equals(product1, product2);

        //public bool Equals(Product other) =>
        //    (other != null) &&
        //    (Name, Price) == (other.Name, other.Price);

        //public override bool Equals(object obj) =>
        //    (obj is Product productObj) && Equals(productObj);
    }
}
