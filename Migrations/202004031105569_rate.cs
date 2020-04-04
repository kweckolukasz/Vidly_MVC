namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class rate : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Movies", "rate", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Movies", "rate");
        }
    }
}
