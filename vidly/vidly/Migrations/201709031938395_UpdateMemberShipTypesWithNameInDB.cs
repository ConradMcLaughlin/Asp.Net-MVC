namespace vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateMemberShipTypesWithNameInDB : DbMigration
    {
        public override void Up()
        {
            Sql("UPDATE MembershipTypes SET Name = 'Pay As You Go' WHERE Id = 1");
            Sql("UPDATE MembershipTypes SET Name = 'Pay Monthly' WHERE Id IN (2,3,4)");
        }

        public override void Down()
        {
        }
    }
}
