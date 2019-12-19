namespace AbpCompanyName.AbpProjectName.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Upgraded_To_ABP_5_1_0 : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.AbpBackgroundJobs", new[] { "IsAbandoned", "NextTryTime" });
            DropIndex("dbo.AbpUserLoginAttempts", new[] { "TenancyName", "UserNameOrEmailAddress", "Result" });
            AlterColumn("dbo.AbpSettings", "Value", c => c.String());
            AlterColumn("dbo.AbpUserLoginAttempts", "UserNameOrEmailAddress", c => c.String(maxLength: 256));
            CreateIndex("dbo.AbpBackgroundJobs", new[] { "Priority", "TryCount", "NextTryTime" });
            CreateIndex("dbo.AbpBackgroundJobs", "IsAbandoned", name: "IX_IsAbandoned_NextTryTime");
            CreateIndex("dbo.AbpUserLoginAttempts", new[] { "TenancyName", "UserNameOrEmailAddress", "Result" });
        }
        
        public override void Down()
        {
            DropIndex("dbo.AbpUserLoginAttempts", new[] { "TenancyName", "UserNameOrEmailAddress", "Result" });
            DropIndex("dbo.AbpBackgroundJobs", "IX_IsAbandoned_NextTryTime");
            DropIndex("dbo.AbpBackgroundJobs", new[] { "Priority", "TryCount", "NextTryTime" });
            AlterColumn("dbo.AbpUserLoginAttempts", "UserNameOrEmailAddress", c => c.String(maxLength: 255));
            AlterColumn("dbo.AbpSettings", "Value", c => c.String(maxLength: 2000));
            CreateIndex("dbo.AbpUserLoginAttempts", new[] { "TenancyName", "UserNameOrEmailAddress", "Result" });
            CreateIndex("dbo.AbpBackgroundJobs", new[] { "IsAbandoned", "NextTryTime" });
        }
    }
}
