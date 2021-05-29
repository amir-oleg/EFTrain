
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using EFTrain.Entites;

namespace EFTrain.Migrations
{
    internal sealed class Configuration : DbMigrationsConfiguration<EFTrain.Sample>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(EFTrain.Sample context)
        {
            //  диспоус контекста вызовет ошибку в дальнейшем
            var categories = new Category[]
            {
                new Category()
                {
                    CategoryName = "Test1", 
                    Description = "blabla"
                },
                new Category() //update row
                {
                    CategoryID = context.Categories.First(cat => cat.CategoryName == "change").CategoryID, 
                    CategoryName = "Test2", 
                    Description = "blabla"
                }
            };
            var regions = new Region[]
            {
                new Region()
                {
                    RegionID = 0, //так бд не генерирует ключ
                    RegionDescription = "asdasdasdasd",
                },
                new Region()
                {
                    RegionID = 1, //так бд не генерирует ключ
                    RegionDescription = "fgdblabla222fdsfsdf"
                }
            };
            context.Categories.AddOrUpdate(categories);
            context.SaveChanges();
            context.Regions.AddOrUpdate(regions);
            context.SaveChanges();
            var regionsArray = context.Regions.Take(2).ToArray();
            var territories = new Territory[]
            {
                new Territory()
                {
                    TerritoryID = "0", //так бд не генерирует ключ
                    TerritoryDescription = "ter-bla-bla",
                    RegionID = regionsArray[0].RegionID,
                    Region = regionsArray[0]
                },
                new Territory()
                {
                    TerritoryID = "1", //так бд не генерирует ключ
                    TerritoryDescription = "ter-bla-bla2222",
                    RegionID = regionsArray[1].RegionID,
                    Region = regionsArray[1]
                }
            };
            context.Territories.AddOrUpdate(territories);
            context.SaveChanges();
        }
    }
}
