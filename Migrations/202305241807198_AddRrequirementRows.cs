namespace EquipmentManagement.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddRrequirementRows : DbMigration
    {
        public override void Up()
        {
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
            
            AddColumn("dbo.Rrequirements", "Unit_Id", c => c.Int());
            CreateIndex("dbo.Rrequirements", "Unit_Id");
            AddForeignKey("dbo.Rrequirements", "Unit_Id", "dbo.Units", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Rrequirements", "Unit_Id", "dbo.Units");
            DropForeignKey("dbo.RrequirementRows", "Rrequirement_Id", "dbo.Rrequirements");
            DropForeignKey("dbo.RrequirementRows", "Equipment_Id", "dbo.Equipments");
            DropIndex("dbo.RrequirementRows", new[] { "Rrequirement_Id" });
            DropIndex("dbo.RrequirementRows", new[] { "Equipment_Id" });
            DropIndex("dbo.Rrequirements", new[] { "Unit_Id" });
            DropColumn("dbo.Rrequirements", "Unit_Id");
            DropTable("dbo.RrequirementRows");
        }
    }
}
