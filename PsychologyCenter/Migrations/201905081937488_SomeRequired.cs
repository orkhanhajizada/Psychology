namespace PsychologyCenter.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SomeRequired : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Faqs", "Answer", c => c.String(nullable: false, storeType: "ntext"));
            AlterColumn("dbo.Timelines", "Text", c => c.String(nullable: false, maxLength: 200));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Timelines", "Text", c => c.String(nullable: false));
            AlterColumn("dbo.Faqs", "Answer", c => c.String(nullable: false, maxLength: 500));
        }
    }
}
