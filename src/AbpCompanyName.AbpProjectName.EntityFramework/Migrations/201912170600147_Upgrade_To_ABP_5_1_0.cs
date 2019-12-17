namespace AbpCompanyName.AbpProjectName.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Upgrade_To_ABP_5_1_0 : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.AbpBackgroundJobs", new[] { "IsAbandoned", "NextTryTime" });
            CreateIndex("dbo.AbpBackgroundJobs", new[] { "Priority", "TryCount", "NextTryTime" });
            CreateIndex("dbo.AbpBackgroundJobs", "IsAbandoned", name: "IX_IsAbandoned_NextTryTime");
        }
        
        public override void Down()
        {
            DropIndex("dbo.AbpBackgroundJobs", "IX_IsAbandoned_NextTryTime");
            DropIndex("dbo.AbpBackgroundJobs", new[] { "Priority", "TryCount", "NextTryTime" });
            CreateIndex("dbo.AbpBackgroundJobs", new[] { "IsAbandoned", "NextTryTime" });
        }
    }
}
