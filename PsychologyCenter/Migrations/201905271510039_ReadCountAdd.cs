namespace PsychologyCenter.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ReadCountAdd : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ReadCounts",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        BlogId = c.Int(nullable: false),
                        Date = c.DateTime(nullable: false),
                        Ip = c.String(maxLength: 4000),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Blogs", t => t.BlogId, cascadeDelete: true)
                .Index(t => t.BlogId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ReadCounts", "BlogId", "dbo.Blogs");
            DropIndex("dbo.ReadCounts", new[] { "BlogId" });
            DropTable("dbo.ReadCounts");
        }
    }
}
