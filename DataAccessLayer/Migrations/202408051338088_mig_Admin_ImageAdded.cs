namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mig_Admin_ImageAdded : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Admins", "WriterImage", c => c.String(maxLength: 250));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Admins", "WriterImage");
        }
    }
}
