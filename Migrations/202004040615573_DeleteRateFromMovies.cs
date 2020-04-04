namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DeleteRateFromMovies : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Movies", "rate");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Movies", "rate", c => c.Int(nullable: false));
        }
    }
}
