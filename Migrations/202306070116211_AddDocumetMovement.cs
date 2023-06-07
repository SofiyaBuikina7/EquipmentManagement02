namespace EquipmentManagement.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddDocumetMovement : DbMigration
    {
        public override void Up()
        {
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
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Movements", "To_Id", "dbo.InstallationLocations");
            DropForeignKey("dbo.MovementRows", "Movement_Id", "dbo.Movements");
            DropForeignKey("dbo.MovementRows", "Equipment_Id", "dbo.Equipments");
            DropForeignKey("dbo.Movements", "ResponsiblePersonTo_Id", "dbo.ResponsiblePersons");
            DropForeignKey("dbo.Movements", "ResponsiblePersonFrom_Id", "dbo.ResponsiblePersons");
            DropForeignKey("dbo.Movements", "From_Id", "dbo.InstallationLocations");
            DropForeignKey("dbo.Movements", "Author_Id", "dbo.Users");
            DropIndex("dbo.MovementRows", new[] { "Movement_Id" });
            DropIndex("dbo.MovementRows", new[] { "Equipment_Id" });
            DropIndex("dbo.Movements", new[] { "To_Id" });
            DropIndex("dbo.Movements", new[] { "ResponsiblePersonTo_Id" });
            DropIndex("dbo.Movements", new[] { "ResponsiblePersonFrom_Id" });
            DropIndex("dbo.Movements", new[] { "From_Id" });
            DropIndex("dbo.Movements", new[] { "Author_Id" });
            DropTable("dbo.MovementRows");
            DropTable("dbo.Movements");
        }
    }
}
