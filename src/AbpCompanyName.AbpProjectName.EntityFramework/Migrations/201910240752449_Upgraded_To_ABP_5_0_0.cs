namespace AbpCompanyName.AbpProjectName.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Upgraded_To_ABP_5_0_0 : DbMigration
    {
        public override void Up()
        {
            CreateIndex("dbo.AbpSettings", "TenantId");
        }
        
        public override void Down()
        {
            DropIndex("dbo.AbpSettings", new[] { "TenantId" });
        }
    }
}
