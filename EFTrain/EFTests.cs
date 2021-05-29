using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Text;
using EFTrain.Migrations;

namespace EFTrain
{
    [TestClass]
    public class EFTests
    {
        [TestMethod]
        public void GetOrdersByCategory() //Task1
        {
            using (var db = new Sample())
            {
                var requiredCategory = db.Categories.First();
                var orders = db.Orders.Where(order =>
                    order.Order_Details.Any(detail => detail.Product.CategoryID == requiredCategory.CategoryID));
                foreach (var order in orders)
                {
                    Console.WriteLine(order.Customer.CompanyName);
                    Console.WriteLine(order.Order_Details.Aggregate(new StringBuilder(), (current, next) => current.Append(current.Length == 0 ? "" : ", ").Append(next.Product.ProductName)));
                    Console.WriteLine($"{order.OrderDate} {order.RequiredDate} {order.ShippedDate} {order.Freight} {order.ShipName} {order.ShipAddress} {order.ShipCity} {order.ShipRegion} {order.ShipPostalCode} {order.ShipCountry}");
                    Console.WriteLine(string.Empty.PadLeft(100,'-'));
                }
            }
        }

        [TestMethod]
        public void InitDb() //Task 3
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<Sample, Configuration>());
            
            using (var db = new Sample())
            {               
                db.Database.Initialize(false);
            }
        }
    }
}
