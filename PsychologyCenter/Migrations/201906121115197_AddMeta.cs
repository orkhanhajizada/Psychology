namespace PsychologyCenter.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddMeta : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Metas",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Url = c.String(),
                        Title = c.String(),
                        Desc = c.String(),
                        Image = c.String(),
                        Type = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Metas");
        }
    }
}
