namespace BITCollege_TA.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Courses", "Notes", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Courses", "Notes");
        }
    }
}
