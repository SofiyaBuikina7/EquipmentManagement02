namespace EquipmentManagement.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Categories",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        IsMarkedForDeletion = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Equipments",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        IsMarkedForDeletion = c.Boolean(nullable: false),
                        Category_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Categories", t => t.Category_Id)
                .Index(t => t.Category_Id);
            
            CreateTable(
                "dbo.InstallationLocations",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        IsMarkedForDeletion = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
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
                        Comment = c.String(),
                        IsMarkedForDeletion = c.Boolean(nullable: false),
                        Author_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Users", t => t.Author_Id)
                .Index(t => t.Author_Id);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        PasswordMD5 = c.String(),
                        Name = c.String(),
                        IsMarkedForDeletion = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
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
                        ForResponsiblePerson_Id = c.Int(),
                        ForUnit_Id = c.Int(),
                        Purchasing_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Equipments", t => t.Equipment_Id)
                .ForeignKey("dbo.ResponsiblePersons", t => t.ForResponsiblePerson_Id)
                .ForeignKey("dbo.Units", t => t.ForUnit_Id)
                .ForeignKey("dbo.Purchasings", t => t.Purchasing_Id)
                .Index(t => t.Equipment_Id)
                .Index(t => t.ForResponsiblePerson_Id)
                .Index(t => t.ForUnit_Id)
                .Index(t => t.Purchasing_Id);
            
            CreateTable(
                "dbo.ResponsiblePersons",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Patronymic = c.String(),
                        Surname = c.String(),
                        Name = c.String(),
                        IsMarkedForDeletion = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Units",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        IsMarkedForDeletion = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Rrequirements",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Reason = c.String(),
                        Date = c.DateTime(nullable: false),
                        No = c.String(),
                        Held = c.Boolean(nullable: false),
                        Comment = c.String(),
                        IsMarkedForDeletion = c.Boolean(nullable: false),
                        Author_Id = c.Int(),
                        Unit_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Users", t => t.Author_Id)
                .ForeignKey("dbo.Units", t => t.Unit_Id)
                .Index(t => t.Author_Id)
                .Index(t => t.Unit_Id);
            
            CreateTable(
                "dbo.RrequirementRows",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Quantity = c.Int(nullable: false),
                        RowNum = c.Int(nullable: false),
                        Equipment_Id = c.Int(),
                        Rrequirement_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Equipments", t => t.Equipment_Id)
                .ForeignKey("dbo.Rrequirements", t => t.Rrequirement_Id)
                .Index(t => t.Equipment_Id)
                .Index(t => t.Rrequirement_Id);
            
            CreateTable(
                "dbo.WriteOffs",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Reason = c.String(),
                        Date = c.DateTime(nullable: false),
                        No = c.String(),
                        Held = c.Boolean(nullable: false),
                        Comment = c.String(),
                        IsMarkedForDeletion = c.Boolean(nullable: false),
                        Author_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Users", t => t.Author_Id)
                .Index(t => t.Author_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.WriteOffs", "Author_Id", "dbo.Users");
            DropForeignKey("dbo.Rrequirements", "Unit_Id", "dbo.Units");
            DropForeignKey("dbo.RrequirementRows", "Rrequirement_Id", "dbo.Rrequirements");
            DropForeignKey("dbo.RrequirementRows", "Equipment_Id", "dbo.Equipments");
            DropForeignKey("dbo.Rrequirements", "Author_Id", "dbo.Users");
            DropForeignKey("dbo.PurchasingRows", "Purchasing_Id", "dbo.Purchasings");
            DropForeignKey("dbo.PurchasingRows", "ForUnit_Id", "dbo.Units");
            DropForeignKey("dbo.PurchasingRows", "ForResponsiblePerson_Id", "dbo.ResponsiblePersons");
            DropForeignKey("dbo.PurchasingRows", "Equipment_Id", "dbo.Equipments");
            DropForeignKey("dbo.Purchasings", "Author_Id", "dbo.Users");
            DropForeignKey("dbo.Equipments", "Category_Id", "dbo.Categories");
            DropIndex("dbo.WriteOffs", new[] { "Author_Id" });
            DropIndex("dbo.RrequirementRows", new[] { "Rrequirement_Id" });
            DropIndex("dbo.RrequirementRows", new[] { "Equipment_Id" });
            DropIndex("dbo.Rrequirements", new[] { "Unit_Id" });
            DropIndex("dbo.Rrequirements", new[] { "Author_Id" });
            DropIndex("dbo.PurchasingRows", new[] { "Purchasing_Id" });
            DropIndex("dbo.PurchasingRows", new[] { "ForUnit_Id" });
            DropIndex("dbo.PurchasingRows", new[] { "ForResponsiblePerson_Id" });
            DropIndex("dbo.PurchasingRows", new[] { "Equipment_Id" });
            DropIndex("dbo.Purchasings", new[] { "Author_Id" });
            DropIndex("dbo.Equipments", new[] { "Category_Id" });
            DropTable("dbo.WriteOffs");
            DropTable("dbo.RrequirementRows");
            DropTable("dbo.Rrequirements");
            DropTable("dbo.Units");
            DropTable("dbo.ResponsiblePersons");
            DropTable("dbo.PurchasingRows");
            DropTable("dbo.Users");
            DropTable("dbo.Purchasings");
            DropTable("dbo.InstallationLocations");
            DropTable("dbo.Equipments");
            DropTable("dbo.Categories");
        }
    }
}
