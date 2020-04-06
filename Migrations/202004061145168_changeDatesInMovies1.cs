namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class changeDatesInMovies1 : DbMigration
    {
        public override void Up()
        {
            Sql("update Movies set releaseDate = '2013-01-18' where id = 1");
            Sql("update Movies set releaseDate = '2003-02-27' where id = 2");
            Sql("update Movies set releaseDate = '2021-06-25' where id = 3");
            Sql("update Movies set releaseDate = '1993-05-21' where id = 4");
            Sql("update Movies set releaseDate = '1976-08-01' where id = 5");
        
    }
        
        public override void Down()
        {
        }
    }
}
