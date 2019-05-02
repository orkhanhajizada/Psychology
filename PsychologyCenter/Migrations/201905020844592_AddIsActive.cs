namespace PsychologyCenter.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddIsActive : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Comments", "IsActive", c => c.Boolean(nullable: false));
            AddColumn("dbo.Phrases", "OrderBy", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Phrases", "OrderBy");
            DropColumn("dbo.Comments", "IsActive");
        }
    }
}
