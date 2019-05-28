namespace PsychologyCenter.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddAdmins : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Admins",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Fullname = c.String(maxLength: 50),
                        Email = c.String(maxLength: 50),
                        Password = c.String(maxLength: 100),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Admins");
        }
    }
}
