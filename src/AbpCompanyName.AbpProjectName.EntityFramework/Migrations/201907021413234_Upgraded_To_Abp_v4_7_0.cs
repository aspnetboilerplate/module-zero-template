namespace AbpCompanyName.AbpProjectName.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Upgraded_To_Abp_v4_7_0 : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.AbpSettings", new[] { "TenantId" });
            DropIndex("dbo.AbpSettings", new[] { "UserId" });
            CreateIndex("dbo.AbpSettings", new[] { "TenantId", "Name", "UserId" }, unique: true);
        }
        
        public override void Down()
        {
            DropIndex("dbo.AbpSettings", new[] { "TenantId", "Name", "UserId" });
            CreateIndex("dbo.AbpSettings", "UserId");
            CreateIndex("dbo.AbpSettings", "TenantId");
        }
    }
}
