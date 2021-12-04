namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mig_aboutContent_MaxString : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Settings", "AboutContent", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Settings", "AboutContent", c => c.String(maxLength: 1000));
        }
    }
}
