namespace PruebaConcepto.WebApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddDepartmentCities : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Ciudades",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Description = c.String(),
                        DepartmentId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Departamentos", t => t.DepartmentId, cascadeDelete: true)
                .Index(t => t.DepartmentId);
            
            CreateTable(
                "dbo.Departamentos",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Ciudades", "DepartmentId", "dbo.Departamentos");
            DropIndex("dbo.Ciudades", new[] { "DepartmentId" });
            DropTable("dbo.Departamentos");
            DropTable("dbo.Ciudades");
        }
    }
}
