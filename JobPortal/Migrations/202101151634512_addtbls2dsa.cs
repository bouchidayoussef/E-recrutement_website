namespace JobPortal.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addtbls2dsa : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.jobs", "NoOfOpeing");
        }
        
        public override void Down()
        {
            AddColumn("dbo.jobs", "NoOfOpeing", c => c.Int(nullable: false));
        }
    }
}
