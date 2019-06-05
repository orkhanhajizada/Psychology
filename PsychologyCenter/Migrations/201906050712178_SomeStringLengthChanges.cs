namespace PsychologyCenter.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SomeStringLengthChanges : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Specialists", "SpecItem1", c => c.String(maxLength: 100));
            AlterColumn("dbo.Specialists", "SpecItem2", c => c.String(maxLength: 100));
            AlterColumn("dbo.Specialists", "SpecItem3", c => c.String(maxLength: 100));
            AlterColumn("dbo.Specialists", "SpecItem4", c => c.String(maxLength: 100));
            AlterColumn("dbo.Specialists", "SpecItem5", c => c.String(maxLength: 100));
            AlterColumn("dbo.Specialists", "SpecItem6", c => c.String(maxLength: 100));
            AlterColumn("dbo.Specialists", "Icon", c => c.String(nullable: false, maxLength: 100));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Specialists", "Icon", c => c.String(nullable: false, maxLength: 250));
            AlterColumn("dbo.Specialists", "SpecItem6", c => c.String(maxLength: 250));
            AlterColumn("dbo.Specialists", "SpecItem5", c => c.String(maxLength: 250));
            AlterColumn("dbo.Specialists", "SpecItem4", c => c.String(maxLength: 250));
            AlterColumn("dbo.Specialists", "SpecItem3", c => c.String(maxLength: 250));
            AlterColumn("dbo.Specialists", "SpecItem2", c => c.String(maxLength: 250));
            AlterColumn("dbo.Specialists", "SpecItem1", c => c.String(maxLength: 250));
        }
    }
}
