namespace EquipmentManagement.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddWriteOff : DbMigration
    {
        public override void Up()
        {
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
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.WriteOffs", "Author_Id", "dbo.Users");
            DropIndex("dbo.WriteOffs", new[] { "Author_Id" });
            DropTable("dbo.WriteOffs");
        }
    }
}
