namespace EquipmentManagement.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InstalationLocationTable_Connect : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.EquipmentMovements", "Unit_Id", "dbo.Units");
            DropForeignKey("dbo.PurchasingRows", "ForUnit_Id", "dbo.Units");
            DropForeignKey("dbo.WriteOffRows", "FromUnit_Id", "dbo.Units");
            DropIndex("dbo.EquipmentMovements", new[] { "Unit_Id" });
            DropIndex("dbo.PurchasingRows", new[] { "ForUnit_Id" });
            DropIndex("dbo.WriteOffRows", new[] { "FromUnit_Id" });
            AddColumn("dbo.Equipments", "Unit_Id", c => c.Int());
            AddColumn("dbo.EquipmentMovements", "InstallationLocation_Id", c => c.Int());
            AddColumn("dbo.PurchasingRows", "InstallationLocation_Id", c => c.Int());
            AddColumn("dbo.WriteOffRows", "InstallationLocation_Id", c => c.Int());
            CreateIndex("dbo.Equipments", "Unit_Id");
            CreateIndex("dbo.EquipmentMovements", "InstallationLocation_Id");
            CreateIndex("dbo.PurchasingRows", "InstallationLocation_Id");
            CreateIndex("dbo.WriteOffRows", "InstallationLocation_Id");
            AddForeignKey("dbo.Equipments", "Unit_Id", "dbo.Units", "Id");
            AddForeignKey("dbo.EquipmentMovements", "InstallationLocation_Id", "dbo.InstallationLocations", "Id");
            AddForeignKey("dbo.PurchasingRows", "InstallationLocation_Id", "dbo.InstallationLocations", "Id");
            AddForeignKey("dbo.WriteOffRows", "InstallationLocation_Id", "dbo.InstallationLocations", "Id");
            DropColumn("dbo.EquipmentMovements", "Unit_Id");
            DropColumn("dbo.PurchasingRows", "ForUnit_Id");
            DropColumn("dbo.WriteOffRows", "FromUnit_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.WriteOffRows", "FromUnit_Id", c => c.Int());
            AddColumn("dbo.PurchasingRows", "ForUnit_Id", c => c.Int());
            AddColumn("dbo.EquipmentMovements", "Unit_Id", c => c.Int());
            DropForeignKey("dbo.WriteOffRows", "InstallationLocation_Id", "dbo.InstallationLocations");
            DropForeignKey("dbo.PurchasingRows", "InstallationLocation_Id", "dbo.InstallationLocations");
            DropForeignKey("dbo.EquipmentMovements", "InstallationLocation_Id", "dbo.InstallationLocations");
            DropForeignKey("dbo.Equipments", "Unit_Id", "dbo.Units");
            DropIndex("dbo.WriteOffRows", new[] { "InstallationLocation_Id" });
            DropIndex("dbo.PurchasingRows", new[] { "InstallationLocation_Id" });
            DropIndex("dbo.EquipmentMovements", new[] { "InstallationLocation_Id" });
            DropIndex("dbo.Equipments", new[] { "Unit_Id" });
            DropColumn("dbo.WriteOffRows", "InstallationLocation_Id");
            DropColumn("dbo.PurchasingRows", "InstallationLocation_Id");
            DropColumn("dbo.EquipmentMovements", "InstallationLocation_Id");
            DropColumn("dbo.Equipments", "Unit_Id");
            CreateIndex("dbo.WriteOffRows", "FromUnit_Id");
            CreateIndex("dbo.PurchasingRows", "ForUnit_Id");
            CreateIndex("dbo.EquipmentMovements", "Unit_Id");
            AddForeignKey("dbo.WriteOffRows", "FromUnit_Id", "dbo.Units", "Id");
            AddForeignKey("dbo.PurchasingRows", "ForUnit_Id", "dbo.Units", "Id");
            AddForeignKey("dbo.EquipmentMovements", "Unit_Id", "dbo.Units", "Id");
        }
    }
}
