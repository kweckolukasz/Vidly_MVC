﻿namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class givePermisionToAdmin : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'fc4bf919-eab4-44d5-885c-0832ba73fb69', N'c624a112-e419-40dc-adb5-3b85a3452150')");
        }
        
        public override void Down()
        {
          
        }
    }
}
