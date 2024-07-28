namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mig_writer_addstatüs : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Writers", "WriterStatüs", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Writers", "WriterStatüs");
        }
    }
}
