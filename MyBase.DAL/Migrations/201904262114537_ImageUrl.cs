namespace MyBase.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ImageUrl : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Users", "ImageUrl", c => c.String());
            DropColumn("dbo.Users", "Image");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Users", "Image", c => c.String());
            DropColumn("dbo.Users", "ImageUrl");
        }
    }
}
