namespace DomainLib.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateEntitiesLinks : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Children", "Kindergarden_Id", c => c.Int());
            CreateIndex("dbo.Children", "Kindergarden_Id");
            AddForeignKey("dbo.Children", "Kindergarden_Id", "dbo.Kindergardens", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Children", "Kindergarden_Id", "dbo.Kindergardens");
            DropIndex("dbo.Children", new[] { "Kindergarden_Id" });
            DropColumn("dbo.Children", "Kindergarden_Id");
        }
    }
}
