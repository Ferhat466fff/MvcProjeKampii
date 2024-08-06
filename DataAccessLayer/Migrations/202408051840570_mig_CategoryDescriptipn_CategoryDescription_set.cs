namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mig_CategoryDescriptipn_CategoryDescription_set : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Categories", "CategoryDescription", c => c.String(maxLength: 500));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Categories", "CategoryDescription", c => c.String(maxLength: 200));
        }
    }
}
