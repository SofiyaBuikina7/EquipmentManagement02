namespace EquipmentManagement.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddPurchasing : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Purchasings",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Provider = c.String(),
                        Amount = c.Decimal(nullable: false, storeType: "money"),
                        Date = c.DateTime(nullable: false),
                        No = c.String(),
                        Held = c.Boolean(nullable: false),
                        IsMarkedForDeletion = c.Boolean(nullable: false),
                        Author_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Users", t => t.Author_Id)
                .Index(t => t.Author_Id);
            
            CreateTable(
                "dbo.PurchasingRows",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Quantity = c.Int(nullable: false),
                        Price = c.Decimal(nullable: false, storeType: "money"),
                        Amount = c.Decimal(nullable: false, storeType: "money"),
                        RowNum = c.Int(nullable: false),
                        Equipment_Id = c.Int(),
                        ForUnit_Id = c.Int(),
                        Purchasing_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Equipments", t => t.Equipment_Id)
                .ForeignKey("dbo.Units", t => t.ForUnit_Id)
                .ForeignKey("dbo.Purchasings", t => t.Purchasing_Id)
                .Index(t => t.Equipment_Id)
                .Index(t => t.ForUnit_Id)
                .Index(t => t.Purchasing_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.PurchasingRows", "Purchasing_Id", "dbo.Purchasings");
            DropForeignKey("dbo.PurchasingRows", "ForUnit_Id", "dbo.Units");
            DropForeignKey("dbo.PurchasingRows", "Equipment_Id", "dbo.Equipments");
            DropForeignKey("dbo.Purchasings", "Author_Id", "dbo.Users");
            DropIndex("dbo.PurchasingRows", new[] { "Purchasing_Id" });
            DropIndex("dbo.PurchasingRows", new[] { "ForUnit_Id" });
            DropIndex("dbo.PurchasingRows", new[] { "Equipment_Id" });
            DropIndex("dbo.Purchasings", new[] { "Author_Id" });
            DropTable("dbo.PurchasingRows");
            DropTable("dbo.Purchasings");
        }
    }
}
