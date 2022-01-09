namespace JobPortal.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addtbls2d : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.jobs", "JobCategoryId", "dbo.JobCategories");
            DropIndex("dbo.jobs", new[] { "JobCategoryId" });
            DropColumn("dbo.jobs", "JobCategoryId");
            DropTable("dbo.JobCategories");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.JobCategories",
                c => new
                    {
                        CatId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.CatId);
            
            AddColumn("dbo.jobs", "JobCategoryId", c => c.Int(nullable: false));
            CreateIndex("dbo.jobs", "JobCategoryId");
            AddForeignKey("dbo.jobs", "JobCategoryId", "dbo.JobCategories", "CatId", cascadeDelete: true);
        }
    }
}
