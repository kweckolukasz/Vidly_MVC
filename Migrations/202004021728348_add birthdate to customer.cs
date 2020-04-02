namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addbirthdatetocustomer : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Customers", "dateOfBirth", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Customers", "dateOfBirth");
        }
    }
}
