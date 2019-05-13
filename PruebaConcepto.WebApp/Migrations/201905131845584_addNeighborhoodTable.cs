namespace PruebaConcepto.WebApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addNeighborhoodTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Barrios",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        CityId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Ciudades", t => t.CityId, cascadeDelete: true)
                .Index(t => t.CityId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Barrios", "CityId", "dbo.Ciudades");
            DropIndex("dbo.Barrios", new[] { "CityId" });
            DropTable("dbo.Barrios");
        }
    }
}
