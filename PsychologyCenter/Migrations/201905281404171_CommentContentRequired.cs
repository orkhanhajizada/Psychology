namespace PsychologyCenter.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CommentContentRequired : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Comments", "Name", c => c.String(nullable: false, maxLength: 50));
            AlterColumn("dbo.Comments", "Content", c => c.String(nullable: false, maxLength: 1000));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Comments", "Content", c => c.String());
            AlterColumn("dbo.Comments", "Name", c => c.String());
        }
    }
}
