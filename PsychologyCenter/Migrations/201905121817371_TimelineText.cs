namespace PsychologyCenter.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class TimelineText : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Timelines", "Text", c => c.String(nullable: false, maxLength: 700));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Timelines", "Text", c => c.String(nullable: false, maxLength: 200));
        }
    }
}
