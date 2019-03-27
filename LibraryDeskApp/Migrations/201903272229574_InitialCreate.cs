namespace LibraryDeskApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Libraries",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Name = c.String(),
                        Address = c.String(),
                        LibraryBook_Id = c.Long(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.LibraryBooks", t => t.LibraryBook_Id)
                .Index(t => t.LibraryBook_Id);
            
            CreateTable(
                "dbo.LibraryBooks",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Title = c.String(),
                        Author = c.String(),
                        Publisher = c.String(),
                        DatePublished = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Libraries", "LibraryBook_Id", "dbo.LibraryBooks");
            DropIndex("dbo.Libraries", new[] { "LibraryBook_Id" });
            DropTable("dbo.LibraryBooks");
            DropTable("dbo.Libraries");
        }
    }
}
