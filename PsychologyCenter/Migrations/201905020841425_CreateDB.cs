namespace PsychologyCenter.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreateDB : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Abouts",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Text = c.String(nullable: false, storeType: "ntext"),
                        Photo = c.String(nullable: false, maxLength: 250),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.BlogCategories",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 100),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Blogs",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Slug = c.String(maxLength: 1000),
                        Title = c.String(nullable: false, maxLength: 500),
                        Text = c.String(nullable: false, storeType: "ntext"),
                        MinAbout = c.String(nullable: false, storeType: "ntext"),
                        Photo = c.String(nullable: false, maxLength: 250),
                        TitlePhoto = c.String(nullable: false, maxLength: 250),
                        Date = c.DateTime(nullable: false),
                        BlogCategoryId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.BlogCategories", t => t.BlogCategoryId, cascadeDelete: true)
                .Index(t => t.BlogCategoryId);
            
            CreateTable(
                "dbo.Comments",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        BlogId = c.Int(nullable: false),
                        Date = c.DateTime(nullable: false),
                        Content = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Blogs", t => t.BlogId, cascadeDelete: true)
                .Index(t => t.BlogId);
            
            CreateTable(
                "dbo.Likes",
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
            
            CreateTable(
                "dbo.ChooseUs",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(nullable: false, maxLength: 150),
                        Text = c.String(nullable: false, maxLength: 300),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Faqs",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Question = c.String(nullable: false, maxLength: 500),
                        Answer = c.String(nullable: false, maxLength: 500),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Galeries",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Photo = c.String(nullable: false, maxLength: 250),
                        BigPhoto = c.String(nullable: false, maxLength: 250),
                        GaleryCategoryId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.GaleryCategories", t => t.GaleryCategoryId, cascadeDelete: true)
                .Index(t => t.GaleryCategoryId);
            
            CreateTable(
                "dbo.GaleryCategories",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.OpeningHours",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Day = c.String(nullable: false, maxLength: 250),
                        OpenHour = c.String(nullable: false, maxLength: 250),
                        OrderBy = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Phrases",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 250),
                        Text = c.String(nullable: false, maxLength: 250),
                        Photo = c.String(nullable: false, maxLength: 250),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Services",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 50),
                        Text = c.String(nullable: false, maxLength: 100),
                        OrderBy = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Settings",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Photo = c.String(nullable: false, maxLength: 250),
                        Phone = c.String(nullable: false, maxLength: 50),
                        Email = c.String(nullable: false, maxLength: 50),
                        Adress = c.String(nullable: false, maxLength: 200),
                        Facebook = c.String(nullable: false, maxLength: 250),
                        Instagram = c.String(nullable: false, maxLength: 250),
                        Youtube = c.String(nullable: false, maxLength: 250),
                        Lat = c.String(nullable: false, maxLength: 50),
                        Lng = c.String(nullable: false, maxLength: 50),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.SpecItems",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 100),
                        SpecialistId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Specialists",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 100),
                        Text = c.String(nullable: false, storeType: "ntext"),
                        Photo = c.String(nullable: false, maxLength: 250),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Timelines",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Date = c.String(nullable: false),
                        Text = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Galeries", "GaleryCategoryId", "dbo.GaleryCategories");
            DropForeignKey("dbo.Likes", "BlogId", "dbo.Blogs");
            DropForeignKey("dbo.Comments", "BlogId", "dbo.Blogs");
            DropForeignKey("dbo.Blogs", "BlogCategoryId", "dbo.BlogCategories");
            DropIndex("dbo.Galeries", new[] { "GaleryCategoryId" });
            DropIndex("dbo.Likes", new[] { "BlogId" });
            DropIndex("dbo.Comments", new[] { "BlogId" });
            DropIndex("dbo.Blogs", new[] { "BlogCategoryId" });
            DropTable("dbo.Timelines");
            DropTable("dbo.Specialists");
            DropTable("dbo.SpecItems");
            DropTable("dbo.Settings");
            DropTable("dbo.Services");
            DropTable("dbo.Phrases");
            DropTable("dbo.OpeningHours");
            DropTable("dbo.GaleryCategories");
            DropTable("dbo.Galeries");
            DropTable("dbo.Faqs");
            DropTable("dbo.ChooseUs");
            DropTable("dbo.Likes");
            DropTable("dbo.Comments");
            DropTable("dbo.Blogs");
            DropTable("dbo.BlogCategories");
            DropTable("dbo.Abouts");
        }
    }
}
