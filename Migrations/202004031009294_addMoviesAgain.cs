namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addMoviesAgain : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                 "dbo.Movies",
                 c => new
                 {
                     id = c.Int(nullable: false, identity: true),
                     name = c.String(),
                     genre = c.String(),
                     releaseDate = c.DateTime(nullable: false),
                     dateAdded = c.DateTime(nullable: false),
                     numberInStock = c.Int(nullable: false)
                 })
                 .PrimaryKey(t => t.id);
        }

        public override void Down()
        {
            
        }
    }
}
