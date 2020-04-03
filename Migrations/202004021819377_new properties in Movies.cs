namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class newpropertiesinMovies : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Movies", "genre", c => c.String());
            AddColumn("dbo.Movies", "releaseDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.Movies", "dateAdded", c => c.DateTime(nullable: false));
            AddColumn("dbo.Movies", "numberInStock", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Movies", "numberInStock");
            DropColumn("dbo.Movies", "dateAdded");
            DropColumn("dbo.Movies", "releaseDate");
            DropColumn("dbo.Movies", "genre");
        }
    }
}
