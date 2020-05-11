namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class cleanUpAfterDelete : DbMigration
    {
        public override void Up()
        {
            Sql("delete from aspnetuserroles");
            Sql("delete from aspnetuserlogins");
        }
        
        public override void Down()
        {
        }
    }
}
