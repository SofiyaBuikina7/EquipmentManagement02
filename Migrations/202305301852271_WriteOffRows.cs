namespace EquipmentManagement.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class WriteOffRows : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.WriteOffRows",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Quantity = c.Int(nullable: false),
                        RowNum = c.Int(nullable: false),
                        Equipment_Id = c.Int(),
                        FromResponsiblePerson_Id = c.Int(),
                        FromUnit_Id = c.Int(),
                        WriteOff_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Equipments", t => t.Equipment_Id)
                .ForeignKey("dbo.ResponsiblePersons", t => t.FromResponsiblePerson_Id)
                .ForeignKey("dbo.Units", t => t.FromUnit_Id)
                .ForeignKey("dbo.WriteOffs", t => t.WriteOff_Id)
                .Index(t => t.Equipment_Id)
                .Index(t => t.FromResponsiblePerson_Id)
                .Index(t => t.FromUnit_Id)
                .Index(t => t.WriteOff_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.WriteOffRows", "WriteOff_Id", "dbo.WriteOffs");
            DropForeignKey("dbo.WriteOffRows", "FromUnit_Id", "dbo.Units");
            DropForeignKey("dbo.WriteOffRows", "FromResponsiblePerson_Id", "dbo.ResponsiblePersons");
            DropForeignKey("dbo.WriteOffRows", "Equipment_Id", "dbo.Equipments");
            DropIndex("dbo.WriteOffRows", new[] { "WriteOff_Id" });
            DropIndex("dbo.WriteOffRows", new[] { "FromUnit_Id" });
            DropIndex("dbo.WriteOffRows", new[] { "FromResponsiblePerson_Id" });
            DropIndex("dbo.WriteOffRows", new[] { "Equipment_Id" });
            DropTable("dbo.WriteOffRows");
        }
    }
}
