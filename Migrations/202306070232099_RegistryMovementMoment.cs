namespace EquipmentManagement.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RegistryMovementMoment : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.EquipmentMovements", "MovementMoment", c => c.DateTime(nullable: false));
            AddColumn("dbo.EquipmentRrequirements", "MovementMoment", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.EquipmentRrequirements", "MovementMoment");
            DropColumn("dbo.EquipmentMovements", "MovementMoment");
        }
    }
}
