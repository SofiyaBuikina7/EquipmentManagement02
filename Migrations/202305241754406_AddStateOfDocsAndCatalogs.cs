namespace EquipmentManagement.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddStateOfDocsAndCatalogs : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Categories", "IsMarkedForDeletion", c => c.Boolean(nullable: false));
            AddColumn("dbo.Equipments", "IsMarkedForDeletion", c => c.Boolean(nullable: false));
            AddColumn("dbo.InstallationLocations", "IsMarkedForDeletion", c => c.Boolean(nullable: false));
            AddColumn("dbo.ResponsiblePersons", "IsMarkedForDeletion", c => c.Boolean(nullable: false));
            AddColumn("dbo.Rrequirements", "Held", c => c.Boolean(nullable: false));
            AddColumn("dbo.Rrequirements", "IsMarkedForDeletion", c => c.Boolean(nullable: false));
            AddColumn("dbo.Users", "IsMarkedForDeletion", c => c.Boolean(nullable: false));
            AddColumn("dbo.Units", "IsMarkedForDeletion", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Units", "IsMarkedForDeletion");
            DropColumn("dbo.Users", "IsMarkedForDeletion");
            DropColumn("dbo.Rrequirements", "IsMarkedForDeletion");
            DropColumn("dbo.Rrequirements", "Held");
            DropColumn("dbo.ResponsiblePersons", "IsMarkedForDeletion");
            DropColumn("dbo.InstallationLocations", "IsMarkedForDeletion");
            DropColumn("dbo.Equipments", "IsMarkedForDeletion");
            DropColumn("dbo.Categories", "IsMarkedForDeletion");
        }
    }
}
