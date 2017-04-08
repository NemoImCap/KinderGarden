namespace DomainLib.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Index : DbMigration
    {
        public override void Up()
        {
            CreateIndex("dbo.Kindergardens", "Number", name: "IX_GartenNumberIndex", clustered: false);
        }
        
        public override void Down()
        {
            DropIndex("dbo.Kindergardens", "IX_GartenNumberIndex");
        }
    }
}
