namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addGenresToMovies : DbMigration
    {
        public override void Up()
        {
            Sql("insert into movies (name, genreId, releaseDate, dateAdded, numberInStock) values('Django', 1, 01-01-2015, 02-04-2020, 1)");
            Sql("insert into movies (name, genreId, releaseDate, dateAdded, numberInStock) values('Basn o ludziach stad', 4, 01-02-2009, 02-04-2020, 1)");
            Sql("insert into movies (name, genreId, releaseDate, dateAdded, numberInStock) values('Batman', 1, 01-01-1999, 01-04-2020, 1)");
            Sql("insert into movies (name, genreId, releaseDate, dateAdded, numberInStock) values('Muminki', 2, 01-01-1980, 02-04-2020, 1)");
            Sql("insert into movies (name, genreId, releaseDate, dateAdded, numberInStock) values('Sąsiedzi', '2, 01-01-2015, 02-04-2020, 1)");
        }
        
        public override void Down()
        {
        }
    }
}
