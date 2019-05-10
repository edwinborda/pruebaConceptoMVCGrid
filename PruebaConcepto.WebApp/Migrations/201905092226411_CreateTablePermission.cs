namespace PruebaConcepto.WebApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreateTablePermission : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Permisos",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.PermissionUsers",
                c => new
                    {
                        Permission_Id = c.Int(nullable: false),
                        User_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Permission_Id, t.User_Id })
                .ForeignKey("dbo.Permisos", t => t.Permission_Id, cascadeDelete: true)
                .ForeignKey("dbo.Usuarios", t => t.User_Id, cascadeDelete: true)
                .Index(t => t.Permission_Id)
                .Index(t => t.User_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.PermissionUsers", "User_Id", "dbo.Usuarios");
            DropForeignKey("dbo.PermissionUsers", "Permission_Id", "dbo.Permisos");
            DropIndex("dbo.PermissionUsers", new[] { "User_Id" });
            DropIndex("dbo.PermissionUsers", new[] { "Permission_Id" });
            DropTable("dbo.PermissionUsers");
            DropTable("dbo.Permisos");
        }
    }
}
