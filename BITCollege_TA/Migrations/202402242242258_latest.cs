namespace BITCollege_TA.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class latest : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Courses", "CourseNumber", c => c.String());
            AlterColumn("dbo.Registrations", "RegistrationNumber", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Registrations", "RegistrationNumber", c => c.String(nullable: false));
            AlterColumn("dbo.Courses", "CourseNumber", c => c.String(nullable: false));
        }
    }
}
