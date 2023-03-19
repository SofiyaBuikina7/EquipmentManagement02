namespace EquipmentManagement.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Add_User_Rrequirement : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Rrequirements",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Date = c.DateTime(nullable: false),
                        No = c.String(),
                        Author_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Users", t => t.Author_Id)
                .Index(t => t.Author_Id);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Rrequirements", "Author_Id", "dbo.Users");
            DropIndex("dbo.Rrequirements", new[] { "Author_Id" });
            DropTable("dbo.Users");
            DropTable("dbo.Rrequirements");
        }
    }
}
