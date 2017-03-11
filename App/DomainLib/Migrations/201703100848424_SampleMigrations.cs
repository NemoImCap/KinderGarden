namespace DomainLib.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SampleMigrations : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.Children", new[] { "GartenId" });
            AlterColumn("dbo.Children", "GartenId", c => c.Int(nullable: true));
            CreateIndex("dbo.Children", "GartenId");
        }
        
        public override void Down()
        {
            DropIndex("dbo.Children", new[] { "GartenId" });
            AlterColumn("dbo.Children", "GartenId", c => c.Int(nullable: false));
            CreateIndex("dbo.Children", "GartenId");
        }
    }
}
