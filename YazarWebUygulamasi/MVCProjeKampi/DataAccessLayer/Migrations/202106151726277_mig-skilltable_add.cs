namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class migskilltable_add : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Skills",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(maxLength: 25),
                        Surname = c.String(maxLength: 25),
                        TitleInfo = c.String(maxLength: 250),
                        ImageUrl = c.String(maxLength: 100),
                        Ability1 = c.String(maxLength: 100),
                        AbilityRate1 = c.Int(nullable: false),
                        Ability2 = c.String(maxLength: 100),
                        AbilityRate2 = c.Int(nullable: false),
                        Ability3 = c.String(maxLength: 100),
                        AbilityRate3 = c.Int(nullable: false),
                        Ability4 = c.String(maxLength: 100),
                        AbilityRate4 = c.Int(nullable: false),
                        Ability5 = c.String(maxLength: 100),
                        AbilityRate5 = c.Int(nullable: false),
                        Ability6 = c.String(maxLength: 100),
                        AbilityRate6 = c.Int(nullable: false),
                        Ability7 = c.String(maxLength: 100),
                        AbilityRate7 = c.Int(nullable: false),
                        Ability8 = c.String(maxLength: 100),
                        AbilityRate8 = c.Int(nullable: false),
                        FacebookUrl = c.String(maxLength: 100),
                        LinkedinUrl = c.String(maxLength: 100),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Skills");
        }
    }
}
