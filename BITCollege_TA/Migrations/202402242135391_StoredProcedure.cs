namespace BITCollege_TA.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class StoredProcedure : DbMigration
    {
        public override void Up()
        {
            //call script to create the stored procedure
            this.Sql(Properties.Resource1.create_next_number);
        }
        
        public override void Down()
        {
            //call script to drop the stored procedure
            this.Sql(Properties.Resource1.drop_next_number);
        }
    }
}
