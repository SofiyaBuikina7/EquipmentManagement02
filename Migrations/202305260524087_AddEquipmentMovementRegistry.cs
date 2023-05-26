namespace EquipmentManagement.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddEquipmentMovementRegistry : DbMigration
    {
        public override void Up()
        {
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
                        Person_Id = c.Int(),
                        Unit_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Equipments", t => t.Equipment_Id)
                .ForeignKey("dbo.ResponsiblePersons", t => t.Person_Id)
                .ForeignKey("dbo.Units", t => t.Unit_Id)
                .Index(t => t.Equipment_Id)
                .Index(t => t.Person_Id)
                .Index(t => t.Unit_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.EquipmentMovements", "Unit_Id", "dbo.Units");
            DropForeignKey("dbo.EquipmentMovements", "Person_Id", "dbo.ResponsiblePersons");
            DropForeignKey("dbo.EquipmentMovements", "Equipment_Id", "dbo.Equipments");
            DropIndex("dbo.EquipmentMovements", new[] { "Unit_Id" });
            DropIndex("dbo.EquipmentMovements", new[] { "Person_Id" });
            DropIndex("dbo.EquipmentMovements", new[] { "Equipment_Id" });
            DropTable("dbo.EquipmentMovements");
        }
    }
}
