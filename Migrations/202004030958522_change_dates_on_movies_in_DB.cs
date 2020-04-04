namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class change_dates_on_movies_in_DB : DbMigration
    {
        public override void Up()
        {
            Sql("drop table movies");

        }
        
        public override void Down()
        {
        }
    }
}
