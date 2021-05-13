using System;
using System.Collections.Generic;
using System.Linq;
using Task1.DoNotChange;

namespace Task1
{
    public static class LinqTask
    {
        public static IEnumerable<Customer> Linq1(IEnumerable<Customer> customers, decimal limit)
        {
            if (customers == null)
            {
                throw new ArgumentNullException();
            }

            return customers.Where(o => o.Orders != null && o.Orders.Sum(o => o.Total) > limit);
        }
               
        public static IEnumerable<(Customer customer, IEnumerable<Supplier> suppliers)> Linq2(
            IEnumerable<Customer> customers,
            IEnumerable<Supplier> suppliers
        )
        {
            if (customers == null || suppliers == null)
            {
                throw new ArgumentNullException();
            }

            var result = customers
                .Select(c => (c, suppliers.Where(s => s.City == c.City && s.Country == c.Country)));

            return result;
        }

        public static IEnumerable<(Customer customer, IEnumerable<Supplier> suppliers)> Linq2UsingGroup(
            IEnumerable<Customer> customers,
            IEnumerable<Supplier> suppliers
        )
        {
            if (customers == null || suppliers == null)
            {
                throw new ArgumentNullException();
            }

            var result = customers.GroupJoin(suppliers,
                c => new { c.City, c.Country },
                s => new { s.City, s.Country },
                (c, s) => (c, s));

            return result;
        }

        public static IEnumerable<Customer> Linq3(IEnumerable<Customer> customers, decimal limit)
        {
            if (customers == null)
            {
                throw new ArgumentNullException();
            }

            return customers.Where(c => c.Orders != null && c.Orders.Any(o => o.Total > limit));
        }
                
        public static IEnumerable<(Customer customer, DateTime dateOfEntry)> Linq4(
            IEnumerable<Customer> customers
        )
        {
            if (customers == null)
            {
                throw new ArgumentNullException();
            }

            var result = customers.Where(c => c.Orders != null && c.Orders.Any())
                .Select(c => (c, c.Orders.Min(o => o.OrderDate)));

            return result;    
        } 
                
        public static IEnumerable<(Customer customer, DateTime dateOfEntry)> Linq5(
            IEnumerable<Customer> customers
        )
        {
            if (customers == null)
            {
                throw new ArgumentNullException();
            }

            var result = Linq4(customers)
                .OrderBy(c => c.dateOfEntry)
                .ThenBy(c => c.dateOfEntry)
                .ThenByDescending(c => c.customer.Orders.Sum(o => o.Total))
                .ThenBy(c => c.customer.CompanyName);

            return result;
        }
                
        public static IEnumerable<Customer> Linq6(IEnumerable<Customer> customers)
        {
            if (customers == null)
            {
                throw new ArgumentNullException();
            }

            var result = customers.Where(c => c.PostalCode != null
            && c.PostalCode.Any(Char.IsLetter)
            || string.IsNullOrWhiteSpace(c.Region)
            || c.Phone.FirstOrDefault() != '(');

            return result;
        }
        
        public static IEnumerable<Linq7CategoryGroup> Linq7(IEnumerable<Product> products)
        {
            if (products == null)
            {
                throw new ArgumentNullException();
            }

            var result = products.GroupBy(p => p.Category, (c, p) =>
                new Linq7CategoryGroup()
                {
                    Category = c,
                    UnitsInStockGroup = p.GroupBy(
                        item => item.UnitsInStock,
                        item => item.UnitPrice,
                         (count, price) =>
                    new Linq7UnitsInStockGroup()
                    {
                        UnitsInStock = count,
                        Prices = price.OrderBy(price => price)
                    })
                });

            return result;
        }
        
        public static IEnumerable<(decimal category, IEnumerable<Product> products)> Linq8(
            IEnumerable<Product> products,
            decimal cheap,
            decimal middle,
            decimal expensive
        )
        {
            if (products == null)
            {
                throw new ArgumentNullException();
            }
            
            var result = products.GroupBy(p => (p.UnitPrice <= cheap) ? cheap
                            : ((p.UnitPrice <= middle) ? middle
                            : expensive), (c, p) => (c, p));


            return result;
        }
               
        public static IEnumerable<(string city, int averageIncome, int averageIntensity)> Linq9(
            IEnumerable<Customer> customers
        )
        {
            if (customers == null)
            {
                throw new ArgumentNullException();
            }

            var result = customers
               .GroupBy(c => c.City)
               .Select(g => (g.Key, (int)Math.Round(g.Average(c => c.Orders.Sum(o => o.Total))),
               (int)Math.Round(g.Average(c => c.Orders.Length))));

            return result;
        }

        public static string Linq10(IEnumerable<Supplier> suppliers)
        {
            if (suppliers == null)
            {
                throw new ArgumentNullException();
            }

            var result = suppliers.OrderBy(s => s.Country.Length)
                .ThenBy(s => s.Country)
                .Select(s => s.Country).Distinct()
                .ToList();                      

            return String.Join("", result); 
        }
    }
}