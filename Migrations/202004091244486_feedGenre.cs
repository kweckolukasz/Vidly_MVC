namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class feedGenre : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO GENRES (NAME) VALUES ('Akcji') ");
            Sql("INSERT INTO GENRES (NAME) VALUES ('Animowany') ");
            Sql("INSERT INTO GENRES (NAME) VALUES ('Horror') ");
            Sql("INSERT INTO GENRES (NAME) VALUES ('Familijny') ");
        }
        
        public override void Down()
        {
        }
    }
}
