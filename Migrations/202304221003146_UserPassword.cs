namespace EquipmentManagement.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UserPassword : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Users", "PasswordMD5", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Users", "PasswordMD5");
        }
    }
}
