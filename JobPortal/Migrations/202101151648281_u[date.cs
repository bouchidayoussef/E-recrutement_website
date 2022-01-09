namespace JobPortal.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class udate : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Applieds", "RecruiterId", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Applieds", "RecruiterId");
        }
    }
}
