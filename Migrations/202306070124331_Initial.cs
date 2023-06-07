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
                        Unit_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Categories", t => t.Category_Id)
                .ForeignKey("dbo.Units", t => t.Unit_Id)
                .Index(t => t.Category_Id)
                .Index(t => t.Unit_Id);
            
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
                "dbo.EquipmentMovements",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Quantity = c.Int(nullable: false),
                        Direction = c.Int(nullable: false),
                        RegistratorId = c.Int(nullable: false),
                        RegistratorType = c.String(),
                        Equipment_Id = c.Int(),
                        InstallationLocation_Id = c.Int(),
                        Person_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Equipments", t => t.Equipment_Id)
                .ForeignKey("dbo.InstallationLocations", t => t.InstallationLocation_Id)
                .ForeignKey("dbo.ResponsiblePersons", t => t.Person_Id)
                .Index(t => t.Equipment_Id)
                .Index(t => t.InstallationLocation_Id)
                .Index(t => t.Person_Id);
            
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
                "dbo.Movements",
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
                        From_Id = c.Int(),
                        ResponsiblePersonFrom_Id = c.Int(),
                        ResponsiblePersonTo_Id = c.Int(),
                        To_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Users", t => t.Author_Id)
                .ForeignKey("dbo.InstallationLocations", t => t.From_Id)
                .ForeignKey("dbo.ResponsiblePersons", t => t.ResponsiblePersonFrom_Id)
                .ForeignKey("dbo.ResponsiblePersons", t => t.ResponsiblePersonTo_Id)
                .ForeignKey("dbo.InstallationLocations", t => t.To_Id)
                .Index(t => t.Author_Id)
                .Index(t => t.From_Id)
                .Index(t => t.ResponsiblePersonFrom_Id)
                .Index(t => t.ResponsiblePersonTo_Id)
                .Index(t => t.To_Id);
            
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
                "dbo.MovementRows",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Quantity = c.Int(nullable: false),
                        RowNum = c.Int(nullable: false),
                        Equipment_Id = c.Int(),
                        Movement_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Equipments", t => t.Equipment_Id)
                .ForeignKey("dbo.Movements", t => t.Movement_Id)
                .Index(t => t.Equipment_Id)
                .Index(t => t.Movement_Id);
            
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
                        InstallationLocation_Id = c.Int(),
                        Purchasing_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Equipments", t => t.Equipment_Id)
                .ForeignKey("dbo.ResponsiblePersons", t => t.ForResponsiblePerson_Id)
                .ForeignKey("dbo.InstallationLocations", t => t.InstallationLocation_Id)
                .ForeignKey("dbo.Purchasings", t => t.Purchasing_Id)
                .Index(t => t.Equipment_Id)
                .Index(t => t.ForResponsiblePerson_Id)
                .Index(t => t.InstallationLocation_Id)
                .Index(t => t.Purchasing_Id);
            
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
                        InstallationLocation_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Users", t => t.Author_Id)
                .ForeignKey("dbo.InstallationLocations", t => t.InstallationLocation_Id)
                .Index(t => t.Author_Id)
                .Index(t => t.InstallationLocation_Id);
            
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
            
            CreateTable(
                "dbo.WriteOffRows",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Quantity = c.Int(nullable: false),
                        RowNum = c.Int(nullable: false),
                        Equipment_Id = c.Int(),
                        FromResponsiblePerson_Id = c.Int(),
                        InstallationLocation_Id = c.Int(),
                        WriteOff_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Equipments", t => t.Equipment_Id)
                .ForeignKey("dbo.ResponsiblePersons", t => t.FromResponsiblePerson_Id)
                .ForeignKey("dbo.InstallationLocations", t => t.InstallationLocation_Id)
                .ForeignKey("dbo.WriteOffs", t => t.WriteOff_Id)
                .Index(t => t.Equipment_Id)
                .Index(t => t.FromResponsiblePerson_Id)
                .Index(t => t.InstallationLocation_Id)
                .Index(t => t.WriteOff_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.WriteOffRows", "WriteOff_Id", "dbo.WriteOffs");
            DropForeignKey("dbo.WriteOffRows", "InstallationLocation_Id", "dbo.InstallationLocations");
            DropForeignKey("dbo.WriteOffRows", "FromResponsiblePerson_Id", "dbo.ResponsiblePersons");
            DropForeignKey("dbo.WriteOffRows", "Equipment_Id", "dbo.Equipments");
            DropForeignKey("dbo.WriteOffs", "Author_Id", "dbo.Users");
            DropForeignKey("dbo.RrequirementRows", "Rrequirement_Id", "dbo.Rrequirements");
            DropForeignKey("dbo.RrequirementRows", "Equipment_Id", "dbo.Equipments");
            DropForeignKey("dbo.Rrequirements", "InstallationLocation_Id", "dbo.InstallationLocations");
            DropForeignKey("dbo.Rrequirements", "Author_Id", "dbo.Users");
            DropForeignKey("dbo.PurchasingRows", "Purchasing_Id", "dbo.Purchasings");
            DropForeignKey("dbo.PurchasingRows", "InstallationLocation_Id", "dbo.InstallationLocations");
            DropForeignKey("dbo.PurchasingRows", "ForResponsiblePerson_Id", "dbo.ResponsiblePersons");
            DropForeignKey("dbo.PurchasingRows", "Equipment_Id", "dbo.Equipments");
            DropForeignKey("dbo.Purchasings", "Author_Id", "dbo.Users");
            DropForeignKey("dbo.Movements", "To_Id", "dbo.InstallationLocations");
            DropForeignKey("dbo.MovementRows", "Movement_Id", "dbo.Movements");
            DropForeignKey("dbo.MovementRows", "Equipment_Id", "dbo.Equipments");
            DropForeignKey("dbo.Movements", "ResponsiblePersonTo_Id", "dbo.ResponsiblePersons");
            DropForeignKey("dbo.Movements", "ResponsiblePersonFrom_Id", "dbo.ResponsiblePersons");
            DropForeignKey("dbo.Movements", "From_Id", "dbo.InstallationLocations");
            DropForeignKey("dbo.Movements", "Author_Id", "dbo.Users");
            DropForeignKey("dbo.EquipmentMovements", "Person_Id", "dbo.ResponsiblePersons");
            DropForeignKey("dbo.EquipmentMovements", "InstallationLocation_Id", "dbo.InstallationLocations");
            DropForeignKey("dbo.EquipmentMovements", "Equipment_Id", "dbo.Equipments");
            DropForeignKey("dbo.Equipments", "Unit_Id", "dbo.Units");
            DropForeignKey("dbo.Equipments", "Category_Id", "dbo.Categories");
            DropIndex("dbo.WriteOffRows", new[] { "WriteOff_Id" });
            DropIndex("dbo.WriteOffRows", new[] { "InstallationLocation_Id" });
            DropIndex("dbo.WriteOffRows", new[] { "FromResponsiblePerson_Id" });
            DropIndex("dbo.WriteOffRows", new[] { "Equipment_Id" });
            DropIndex("dbo.WriteOffs", new[] { "Author_Id" });
            DropIndex("dbo.RrequirementRows", new[] { "Rrequirement_Id" });
            DropIndex("dbo.RrequirementRows", new[] { "Equipment_Id" });
            DropIndex("dbo.Rrequirements", new[] { "InstallationLocation_Id" });
            DropIndex("dbo.Rrequirements", new[] { "Author_Id" });
            DropIndex("dbo.PurchasingRows", new[] { "Purchasing_Id" });
            DropIndex("dbo.PurchasingRows", new[] { "InstallationLocation_Id" });
            DropIndex("dbo.PurchasingRows", new[] { "ForResponsiblePerson_Id" });
            DropIndex("dbo.PurchasingRows", new[] { "Equipment_Id" });
            DropIndex("dbo.Purchasings", new[] { "Author_Id" });
            DropIndex("dbo.MovementRows", new[] { "Movement_Id" });
            DropIndex("dbo.MovementRows", new[] { "Equipment_Id" });
            DropIndex("dbo.Movements", new[] { "To_Id" });
            DropIndex("dbo.Movements", new[] { "ResponsiblePersonTo_Id" });
            DropIndex("dbo.Movements", new[] { "ResponsiblePersonFrom_Id" });
            DropIndex("dbo.Movements", new[] { "From_Id" });
            DropIndex("dbo.Movements", new[] { "Author_Id" });
            DropIndex("dbo.EquipmentMovements", new[] { "Person_Id" });
            DropIndex("dbo.EquipmentMovements", new[] { "InstallationLocation_Id" });
            DropIndex("dbo.EquipmentMovements", new[] { "Equipment_Id" });
            DropIndex("dbo.Equipments", new[] { "Unit_Id" });
            DropIndex("dbo.Equipments", new[] { "Category_Id" });
            DropTable("dbo.WriteOffRows");
            DropTable("dbo.WriteOffs");
            DropTable("dbo.RrequirementRows");
            DropTable("dbo.Rrequirements");
            DropTable("dbo.PurchasingRows");
            DropTable("dbo.Purchasings");
            DropTable("dbo.MovementRows");
            DropTable("dbo.Users");
            DropTable("dbo.Movements");
            DropTable("dbo.ResponsiblePersons");
            DropTable("dbo.InstallationLocations");
            DropTable("dbo.EquipmentMovements");
            DropTable("dbo.Units");
            DropTable("dbo.Equipments");
            DropTable("dbo.Categories");
        }
    }
}
