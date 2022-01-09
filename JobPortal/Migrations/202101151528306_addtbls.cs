namespace JobPortal.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addtbls : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Applieds",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        JobId = c.Int(nullable: false),
                        Status = c.String(),
                        AppliedOn = c.DateTime(),
                        UserId = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.jobs", t => t.JobId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId)
                .Index(t => t.JobId)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.jobs",
                c => new
                    {
                        JobId = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        JobCategoryId = c.Int(nullable: false),
                        Skills = c.String(),
                        RequiredDescription = c.String(),
                        RequiredResponsibilities = c.String(),
                        RequiredQualification = c.String(),
                        RequiredExperience = c.String(),
                        HrsPerWeek = c.Int(),
                        Salary = c.String(),
                        MinExpInYr = c.Int(),
                        Location = c.String(),
                        NoOfOpening = c.Int(),
                        SourceId = c.Int(),
                        Status = c.String(),
                        NoOfOpeing = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.JobId)
                .ForeignKey("dbo.JobCategories", t => t.JobCategoryId, cascadeDelete: true)
                .Index(t => t.JobCategoryId);
            
            CreateTable(
                "dbo.JobCategories",
                c => new
                    {
                        CatId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.CatId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Applieds", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.Applieds", "JobId", "dbo.jobs");
            DropForeignKey("dbo.jobs", "JobCategoryId", "dbo.JobCategories");
            DropIndex("dbo.jobs", new[] { "JobCategoryId" });
            DropIndex("dbo.Applieds", new[] { "UserId" });
            DropIndex("dbo.Applieds", new[] { "JobId" });
            DropTable("dbo.JobCategories");
            DropTable("dbo.jobs");
            DropTable("dbo.Applieds");
        }
    }
}
