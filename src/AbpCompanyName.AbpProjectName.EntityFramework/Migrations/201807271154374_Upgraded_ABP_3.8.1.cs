namespace AbpCompanyName.AbpProjectName.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Upgraded_ABP_381 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.AbpUsers", "UserName", c => c.String(nullable: false, maxLength: 256));
            AlterColumn("dbo.AbpUserAccounts", "UserName", c => c.String(maxLength: 256));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.AbpUserAccounts", "UserName", c => c.String(maxLength: 32));
            AlterColumn("dbo.AbpUsers", "UserName", c => c.String(nullable: false, maxLength: 32));
        }
    }
}
