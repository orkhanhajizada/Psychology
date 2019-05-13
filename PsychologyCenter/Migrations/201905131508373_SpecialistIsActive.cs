namespace PsychologyCenter.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SpecialistIsActive : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Specialists", "IsActive", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Specialists", "IsActive");
        }
    }
}
