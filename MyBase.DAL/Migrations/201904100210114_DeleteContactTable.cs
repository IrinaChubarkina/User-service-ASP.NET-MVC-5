namespace MyBase.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DeleteContactTable : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Users", "ContactId", "dbo.Contacts");
            DropIndex("dbo.Users", new[] { "ContactId" });
            AddColumn("dbo.Users", "PhoneNumber", c => c.String());
            AddColumn("dbo.Users", "Email", c => c.String());
            DropColumn("dbo.Users", "ContactId");
            DropTable("dbo.Contacts");
        }
        
        public override void Down()
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
            
            AddColumn("dbo.Users", "ContactId", c => c.Int(nullable: false));
            DropColumn("dbo.Users", "Email");
            DropColumn("dbo.Users", "PhoneNumber");
            CreateIndex("dbo.Users", "ContactId");
            AddForeignKey("dbo.Users", "ContactId", "dbo.Contacts", "Id", cascadeDelete: true);
        }
    }
}
