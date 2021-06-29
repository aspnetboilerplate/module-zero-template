namespace AbpCompanyName.AbpProjectName.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Upgrade_To_ABP_6_4_rc1 : DbMigration
    {
        public override void Up()
        {
            CreateIndex("dbo.AbpUserLogins", new[] { "ProviderKey", "TenantId" }, unique: true);
        }
        
        public override void Down()
        {
            DropIndex("dbo.AbpUserLogins", new[] { "ProviderKey", "TenantId" });
        }
    }
}
