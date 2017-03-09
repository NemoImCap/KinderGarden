namespace DomainLib.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CorrectKindergarten1 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Children", "Kindergarden_Id", "dbo.Kindergardens");
            DropIndex("dbo.Children", new[] { "Kindergarden_Id" });
            RenameColumn(table: "dbo.Children", name: "Kindergarden_Id", newName: "GartenId");
            AlterColumn("dbo.Children", "GartenId", c => c.Int(nullable: true));
            CreateIndex("dbo.Children", "GartenId");
            AddForeignKey("dbo.Children", "GartenId", "dbo.Kindergardens", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Children", "GartenId", "dbo.Kindergardens");
            DropIndex("dbo.Children", new[] { "GartenId" });
            AlterColumn("dbo.Children", "GartenId", c => c.Int());
            RenameColumn(table: "dbo.Children", name: "GartenId", newName: "Kindergarden_Id");
            CreateIndex("dbo.Children", "Kindergarden_Id");
            AddForeignKey("dbo.Children", "Kindergarden_Id", "dbo.Kindergardens", "Id");
        }
    }
}
