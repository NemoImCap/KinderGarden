namespace DomainLib.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Announcement : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Announcemen",
                c => new
                    {
                        Announcementunification = c.Guid(nullable: false),
                        NewsMessage = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.Announcementunification, t.NewsMessage });

        }
        
        public override void Down()
        {
            DropTable("dbo.Announcemen");
        }
    }
}
