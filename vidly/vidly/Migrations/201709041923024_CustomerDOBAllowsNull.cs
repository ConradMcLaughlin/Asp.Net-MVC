namespace vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CustomerDOBAllowsNull : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Customers", "DOB", c => c.DateTime(nullable: true));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Customers", "DOB", c => c.DateTime(nullable: false));
        }
    }
}
