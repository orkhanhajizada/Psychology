namespace PsychologyCenter.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RelationSpecialistSpecItem1 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.SpecItems", "SpecialistId", "dbo.Specialists");
            DropIndex("dbo.SpecItems", new[] { "SpecialistId" });
            AddColumn("dbo.Specialists", "SpecItem_Id", c => c.Int());
            CreateIndex("dbo.Specialists", "SpecItem_Id");
            AddForeignKey("dbo.Specialists", "SpecItem_Id", "dbo.SpecItems", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Specialists", "SpecItem_Id", "dbo.SpecItems");
            DropIndex("dbo.Specialists", new[] { "SpecItem_Id" });
            DropColumn("dbo.Specialists", "SpecItem_Id");
            CreateIndex("dbo.SpecItems", "SpecialistId");
            AddForeignKey("dbo.SpecItems", "SpecialistId", "dbo.Specialists", "Id", cascadeDelete: true);
        }
    }
}
