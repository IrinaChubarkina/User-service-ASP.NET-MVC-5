namespace MyBase.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddPictureTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Contacts",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        PhoneNumber = c.String(),
                        Email = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Pictures",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Image = c.Binary(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FirstName = c.String(),
                        LastName = c.String(),
                        ContactId = c.Int(nullable: false),
                        PictureId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Contacts", t => t.ContactId, cascadeDelete: true)
                .ForeignKey("dbo.Pictures", t => t.PictureId, cascadeDelete: true)
                .Index(t => t.ContactId)
                .Index(t => t.PictureId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Users", "PictureId", "dbo.Pictures");
            DropForeignKey("dbo.Users", "ContactId", "dbo.Contacts");
            DropIndex("dbo.Users", new[] { "PictureId" });
            DropIndex("dbo.Users", new[] { "ContactId" });
            DropTable("dbo.Users");
            DropTable("dbo.Pictures");
            DropTable("dbo.Contacts");
        }
    }
}
