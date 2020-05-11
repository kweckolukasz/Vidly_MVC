namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class deleteUsers : DbMigration
    {
        public override void Up()
        {
            Sql("DELETE FROM ASPNETUSERS");
    
        }
        
        public override void Down()
        {
        }
    }
}
