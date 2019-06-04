namespace PsychologyCenter.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DeleteLatLng : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Settings", "Lat");
            DropColumn("dbo.Settings", "Lng");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Settings", "Lng", c => c.String(nullable: false, maxLength: 50));
            AddColumn("dbo.Settings", "Lat", c => c.String(nullable: false, maxLength: 50));
        }
    }
}
