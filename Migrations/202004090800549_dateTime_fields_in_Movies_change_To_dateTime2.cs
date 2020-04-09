namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class dateTime_fields_in_Movies_change_To_dateTime2 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Movies", "releaseDate", c => c.DateTime(nullable: false, precision: 7, storeType: "datetime2"));
            AlterColumn("dbo.Movies", "dateAdded", c => c.DateTime(nullable: false, precision: 7, storeType: "datetime2"));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Movies", "dateAdded", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Movies", "releaseDate", c => c.DateTime(nullable: false));
        }
    }
}
