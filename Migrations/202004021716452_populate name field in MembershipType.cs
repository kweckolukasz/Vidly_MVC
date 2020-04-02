namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class populatenamefieldinMembershipType : DbMigration
    {
        public override void Up()
        {
            Sql("UPDATE MembershipTypes set name='pay as you go' where Id = 1");
            Sql("UPDATE MembershipTypes set name='monthly' where Id = 2");
            Sql("UPDATE MembershipTypes set name='quarterly' where Id = 3");
            Sql("UPDATE MembershipTypes set name='annual' where Id = 4");
        }
        
        public override void Down()
        {
        }
    }
}
