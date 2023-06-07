namespace EquipmentManagement.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ErrorFix_Requirement : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.Rrequirements", newName: "Requirements");
            RenameColumn(table: "dbo.RrequirementRows", name: "Rrequirement_Id", newName: "Requirement_Id");
            RenameIndex(table: "dbo.RrequirementRows", name: "IX_Rrequirement_Id", newName: "IX_Requirement_Id");
        }
        
        public override void Down()
        {
            RenameIndex(table: "dbo.RrequirementRows", name: "IX_Requirement_Id", newName: "IX_Rrequirement_Id");
            RenameColumn(table: "dbo.RrequirementRows", name: "Requirement_Id", newName: "Rrequirement_Id");
            RenameTable(name: "dbo.Requirements", newName: "Rrequirements");
        }
    }
}
