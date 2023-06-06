namespace EquipmentManagement.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InstalationLocationTable_BugFix : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Rrequirements", "Unit_Id", "dbo.Units");
            DropIndex("dbo.Rrequirements", new[] { "Unit_Id" });
            AddColumn("dbo.Rrequirements", "InstallationLocation_Id", c => c.Int());
            CreateIndex("dbo.Rrequirements", "InstallationLocation_Id");
            AddForeignKey("dbo.Rrequirements", "InstallationLocation_Id", "dbo.InstallationLocations", "Id");
            DropColumn("dbo.Rrequirements", "Unit_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Rrequirements", "Unit_Id", c => c.Int());
            DropForeignKey("dbo.Rrequirements", "InstallationLocation_Id", "dbo.InstallationLocations");
            DropIndex("dbo.Rrequirements", new[] { "InstallationLocation_Id" });
            DropColumn("dbo.Rrequirements", "InstallationLocation_Id");
            CreateIndex("dbo.Rrequirements", "Unit_Id");
            AddForeignKey("dbo.Rrequirements", "Unit_Id", "dbo.Units", "Id");
        }
    }
}
