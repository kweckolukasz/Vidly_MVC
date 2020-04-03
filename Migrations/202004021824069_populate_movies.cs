namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class populate_movies : DbMigration
    {
        public override void Up()
        {
            Sql("insert into movies (name, genre, releaseDate, dateAdded, numberInStock) values('Django', 'Western', 2015-01-01, 02-04-2020, 1)");
            Sql("insert into movies (name, genre, releaseDate, dateAdded, numberInStock) values('Basn o ludziach stad', 'Dokumentalny', 2008-01-01, 02-04-2020, 1)");
            Sql("insert into movies (name, genre, releaseDate, dateAdded, numberInStock) values('Batman', 'Akcji', 1999-01-01, 01-04-2020, 1)");
            Sql("insert into movies (name, genre, releaseDate, dateAdded, numberInStock) values('Muminki', 'Animowany', 1980-01-01, 02-04-2020, 1)");
            Sql("insert into movies (name, genre, releaseDate, dateAdded, numberInStock) values('Sąsiedzi', 'Animowany', 2015-01-01, 02-04-2020, 1)");
        }
        
        public override void Down()
        {
        }
    }
}
