namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class migproducttablecolumnAdd : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Products", "CustomProduct", c => c.Boolean(nullable: false));
            AddColumn("dbo.Products", "FeaturedProduct", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Products", "FeaturedProduct");
            DropColumn("dbo.Products", "CustomProduct");
        }
    }
}
