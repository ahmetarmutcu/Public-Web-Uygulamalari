namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mig1_delete_bog : DbMigration
    {
        public override void Up()
        {
            DropTable("dbo.Blogs");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Blogs",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Heading = c.String(maxLength: 250),
                        Content = c.String(maxLength: 2000),
                    })
                .PrimaryKey(t => t.ID);
            
        }
    }
}
