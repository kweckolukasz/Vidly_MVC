namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addFavouriteColourToUser : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AspNetUsers", "MyFavouriteColour", c => c.String(nullable: false, maxLength: 255));
        }
        
        public override void Down()
        {
            DropColumn("dbo.AspNetUsers", "MyFavouriteColour");
        }
    }
}
