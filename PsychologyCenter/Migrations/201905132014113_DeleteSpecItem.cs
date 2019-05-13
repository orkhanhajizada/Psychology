namespace PsychologyCenter.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DeleteSpecItem : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Specialists", "SpecItem_Id", "dbo.SpecItems");
            DropIndex("dbo.Specialists", new[] { "SpecItem_Id" });
            AddColumn("dbo.Specialists", "SpecItem1", c => c.String(maxLength: 250));
            AddColumn("dbo.Specialists", "SpecItem2", c => c.String(maxLength: 250));
            AddColumn("dbo.Specialists", "SpecItem3", c => c.String(maxLength: 250));
            AddColumn("dbo.Specialists", "SpecItem4", c => c.String(maxLength: 250));
            AddColumn("dbo.Specialists", "SpecItem5", c => c.String(maxLength: 250));
            AddColumn("dbo.Specialists", "SpecItem6", c => c.String(maxLength: 250));
            DropColumn("dbo.Specialists", "SpecItem_Id");
            DropTable("dbo.SpecItems");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.SpecItems",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 100),
                        SpecialistId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Specialists", "SpecItem_Id", c => c.Int());
            DropColumn("dbo.Specialists", "SpecItem6");
            DropColumn("dbo.Specialists", "SpecItem5");
            DropColumn("dbo.Specialists", "SpecItem4");
            DropColumn("dbo.Specialists", "SpecItem3");
            DropColumn("dbo.Specialists", "SpecItem2");
            DropColumn("dbo.Specialists", "SpecItem1");
            CreateIndex("dbo.Specialists", "SpecItem_Id");
            AddForeignKey("dbo.Specialists", "SpecItem_Id", "dbo.SpecItems", "Id");
        }
    }
}
