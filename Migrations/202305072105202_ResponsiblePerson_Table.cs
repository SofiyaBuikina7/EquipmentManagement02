namespace EquipmentManagement.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ResponsiblePerson_Table : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ResponsiblePersons",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Patronymic = c.String(),
                        Surname = c.String(),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.ResponsiblePersons");
        }
    }
}
