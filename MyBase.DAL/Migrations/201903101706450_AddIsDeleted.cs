namespace MyBase.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddIsDeleted : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Users", "PictureId", "dbo.Pictures");
            DropIndex("dbo.Users", new[] { "PictureId" });
            AddColumn("dbo.Users", "IsDeleted", c => c.Boolean(nullable: false));
            AlterColumn("dbo.Users", "PictureId", c => c.Int());
            CreateIndex("dbo.Users", "PictureId");
            AddForeignKey("dbo.Users", "PictureId", "dbo.Pictures", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Users", "PictureId", "dbo.Pictures");
            DropIndex("dbo.Users", new[] { "PictureId" });
            AlterColumn("dbo.Users", "PictureId", c => c.Int(nullable: false));
            DropColumn("dbo.Users", "IsDeleted");
            CreateIndex("dbo.Users", "PictureId");
            AddForeignKey("dbo.Users", "PictureId", "dbo.Pictures", "Id", cascadeDelete: true);
        }
    }
}
