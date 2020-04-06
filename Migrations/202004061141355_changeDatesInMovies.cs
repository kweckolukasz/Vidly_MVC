namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class changeDatesInMovies : DbMigration
    {
        public override void Up()
        {
            Sql("update Movies set dateAdded = '2020-04-06'");
        }
        
        public override void Down()
        {
        }
    }
}
