namespace DomainLib.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CascadeDelete : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Children", "GartenId", "dbo.Kindergardens");
            AddForeignKey("dbo.Children", "GartenId", "dbo.Kindergardens", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Children", "GartenId", "dbo.Kindergardens");
            AddForeignKey("dbo.Children", "GartenId", "dbo.Kindergardens", "Id", cascadeDelete: true);
        }
    }
}
