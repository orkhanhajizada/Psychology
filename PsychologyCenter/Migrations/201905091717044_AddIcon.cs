namespace PsychologyCenter.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddIcon : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Services", "Icon", c => c.String(nullable: false, maxLength: 250));
            AddColumn("dbo.Specialists", "Icon", c => c.String(nullable: false, maxLength: 250));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Specialists", "Icon");
            DropColumn("dbo.Services", "Icon");
        }
    }
}
