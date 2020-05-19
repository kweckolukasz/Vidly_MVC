namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addedAvaibleCopiesToMoviesEntity : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Movies", "AvaibleCopies", c => c.Int(nullable: false));
            AlterColumn("dbo.NewRentals", "DateReturned", c => c.DateTime());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.NewRentals", "DateReturned", c => c.DateTime(nullable: false));
            DropColumn("dbo.Movies", "AvaibleCopies");
        }
    }
}
