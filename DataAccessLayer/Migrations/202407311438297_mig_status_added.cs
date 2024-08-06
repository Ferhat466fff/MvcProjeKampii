﻿namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mig_status_added : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Messages", "status", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Messages", "status");
        }
    }
}
