namespace PsychologyCenter.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddSlider1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Sliders",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title1 = c.String(nullable: false, maxLength: 150),
                        Title2 = c.String(nullable: false, maxLength: 150),
                        Text = c.String(nullable: false, maxLength: 150),
                        Photo = c.String(nullable: false, maxLength: 250),
                        OrderBy = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Sliders");
        }
    }
}
