namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class populate_birthdays : DbMigration
    {
        public override void Up()
        {
            Sql("update Customers set dateOfBirth = '1990-09-17' where id = 5");
            Sql("update Customers set dateOfBirth = '1988-05-14' where id = 6");
        }
        
        public override void Down()
        {
        }
    }
}
