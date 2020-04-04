namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class feedMoviesAgain : DbMigration
    {
        public override void Up()
        {
            Sql("insert into movies (name, genre, releaseDate, dateAdded, numberInStock) values('Django', 'Western', 01-01-2015, 02-04-2020, 1)");
            Sql("insert into movies (name, genre, releaseDate, dateAdded, numberInStock) values('Basn o ludziach stad', 'Dokumentalny', 01-02-2009, 02-04-2020, 1)");
            Sql("insert into movies (name, genre, releaseDate, dateAdded, numberInStock) values('Batman', 'Akcji', 01-01-1999, 01-04-2020, 1)");
            Sql("insert into movies (name, genre, releaseDate, dateAdded, numberInStock) values('Muminki', 'Animowany', 01-01-1980, 02-04-2020, 1)");
            Sql("insert into movies (name, genre, releaseDate, dateAdded, numberInStock) values('Sąsiedzi', 'Animowany', 01-01-2015, 02-04-2020, 1)");
        }
        
        public override void Down()
        {
        }
    }
}
