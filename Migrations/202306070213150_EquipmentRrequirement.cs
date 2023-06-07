namespace EquipmentManagement.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class EquipmentRrequirement : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.EquipmentRrequirements",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Quantity = c.Int(nullable: false),
                        Direction = c.Int(nullable: false),
                        RegistratorId = c.Int(nullable: false),
                        RegistratorType = c.String(),
                        Equipment_Id = c.Int(),
                        InstallationLocation_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Equipments", t => t.Equipment_Id)
                .ForeignKey("dbo.InstallationLocations", t => t.InstallationLocation_Id)
                .Index(t => t.Equipment_Id)
                .Index(t => t.InstallationLocation_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.EquipmentRrequirements", "InstallationLocation_Id", "dbo.InstallationLocations");
            DropForeignKey("dbo.EquipmentRrequirements", "Equipment_Id", "dbo.Equipments");
            DropIndex("dbo.EquipmentRrequirements", new[] { "InstallationLocation_Id" });
            DropIndex("dbo.EquipmentRrequirements", new[] { "Equipment_Id" });
            DropTable("dbo.EquipmentRrequirements");
        }
    }
}
