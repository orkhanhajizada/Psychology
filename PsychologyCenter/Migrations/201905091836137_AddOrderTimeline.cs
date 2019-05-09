namespace PsychologyCenter.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddOrderTimeline : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Timelines", "OrderBy", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Timelines", "OrderBy");
        }
    }
}
