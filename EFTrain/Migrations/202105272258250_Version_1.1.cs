namespace EFTrain.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Version_11 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                    "dbo.CreditCards",
                    c => new
                    {
                        CreditCardId = c.Int(nullable: false, identity: true),
                        Number = c.Long(nullable: false),
                        CVC = c.Byte(nullable: false),
                        ExpirationDate = c.DateTime(nullable: false),
                        CardHolder = c.String(nullable: false),
                        EmployeeID = c.Int()
                    })
                .PrimaryKey(t => t.CreditCardId)
                .ForeignKey("dbo.Employees", t => t.EmployeeID);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.CreditCards", "EmployeeID", "dbo.Employees");
            DropTable("dbo.CreditCards");
        }
    }
}
