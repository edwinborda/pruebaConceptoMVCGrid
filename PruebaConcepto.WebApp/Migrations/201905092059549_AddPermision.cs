namespace PruebaConcepto.WebApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddPermision : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Usuarios", "IsEditable", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Usuarios", "IsEditable");
        }
    }
}
