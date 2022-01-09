namespace JobPortal.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addtbls2ds : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.jobs", "SourceId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.jobs", "SourceId", c => c.Int());
        }
    }
}
