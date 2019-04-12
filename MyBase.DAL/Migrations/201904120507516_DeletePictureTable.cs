namespace MyBase.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DeletePictureTable : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Users", "PictureId", "dbo.Pictures");
            DropIndex("dbo.Users", new[] { "PictureId" });
            AddColumn("dbo.Users", "Image", c => c.Binary());
            DropColumn("dbo.Users", "PictureId");
            DropTable("dbo.Pictures");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Pictures",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Image = c.Binary(),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Users", "PictureId", c => c.Int());
            DropColumn("dbo.Users", "Image");
            CreateIndex("dbo.Users", "PictureId");
            AddForeignKey("dbo.Users", "PictureId", "dbo.Pictures", "Id");
        }
    }
}
