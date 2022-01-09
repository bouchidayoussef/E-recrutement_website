namespace JobPortal.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addtbls2 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.jobs", "UserId", c => c.String());
            AddColumn("dbo.AspNetUsers", "Role", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.AspNetUsers", "Role");
            DropColumn("dbo.jobs", "UserId");
        }
    }
}
