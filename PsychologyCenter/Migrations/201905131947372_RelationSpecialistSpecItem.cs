namespace PsychologyCenter.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RelationSpecialistSpecItem : DbMigration
    {
        public override void Up()
        {
            CreateIndex("dbo.SpecItems", "SpecialistId");
            AddForeignKey("dbo.SpecItems", "SpecialistId", "dbo.Specialists", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.SpecItems", "SpecialistId", "dbo.Specialists");
            DropIndex("dbo.SpecItems", new[] { "SpecialistId" });
        }
    }
}
