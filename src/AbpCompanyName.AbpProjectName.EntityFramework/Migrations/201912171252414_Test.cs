namespace AbpCompanyName.AbpProjectName.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Test : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.AbpUserLoginAttempts", new[] { "TenancyName", "UserNameOrEmailAddress", "Result" });
            AlterColumn("dbo.AbpSettings", "Value", c => c.String());
            AlterColumn("dbo.AbpUserLoginAttempts", "UserNameOrEmailAddress", c => c.String(maxLength: 256));
            CreateIndex("dbo.AbpUserLoginAttempts", new[] { "TenancyName", "UserNameOrEmailAddress", "Result" });
        }
        
        public override void Down()
        {
            DropIndex("dbo.AbpUserLoginAttempts", new[] { "TenancyName", "UserNameOrEmailAddress", "Result" });
            AlterColumn("dbo.AbpUserLoginAttempts", "UserNameOrEmailAddress", c => c.String(maxLength: 255));
            AlterColumn("dbo.AbpSettings", "Value", c => c.String(maxLength: 2000));
            CreateIndex("dbo.AbpUserLoginAttempts", new[] { "TenancyName", "UserNameOrEmailAddress", "Result" });
        }
    }
}
