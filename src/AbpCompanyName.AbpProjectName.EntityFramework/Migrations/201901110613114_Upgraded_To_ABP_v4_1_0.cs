namespace AbpCompanyName.AbpProjectName.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Upgraded_To_ABP_v4_1_0 : DbMigration
    {
        public override void Up()
        {
            CreateIndex("dbo.AbpAuditLogs", "TenantId");
            CreateIndex("dbo.AbpFeatures", "TenantId");
            CreateIndex("dbo.AbpEditions", "IsDeleted");
            CreateIndex("dbo.AbpLanguages", "TenantId");
            CreateIndex("dbo.AbpLanguages", "IsDeleted");
            CreateIndex("dbo.AbpLanguageTexts", "TenantId");
            CreateIndex("dbo.AbpNotificationSubscriptions", "TenantId");
            CreateIndex("dbo.AbpOrganizationUnits", "TenantId");
            CreateIndex("dbo.AbpOrganizationUnits", "IsDeleted");
            CreateIndex("dbo.AbpPermissions", "TenantId");
            CreateIndex("dbo.AbpRoles", "TenantId");
            CreateIndex("dbo.AbpRoles", "IsDeleted");
            CreateIndex("dbo.AbpUsers", "TenantId");
            CreateIndex("dbo.AbpUsers", "IsDeleted");
            CreateIndex("dbo.AbpUserClaims", "TenantId");
            CreateIndex("dbo.AbpUserLogins", "TenantId");
            CreateIndex("dbo.AbpUserRoles", "TenantId");
            CreateIndex("dbo.AbpSettings", "TenantId");
            CreateIndex("dbo.AbpTenantNotifications", "TenantId");
            CreateIndex("dbo.AbpTenants", "IsDeleted");
            CreateIndex("dbo.AbpUserAccounts", "IsDeleted");
            CreateIndex("dbo.AbpUserLoginAttempts", "TenantId");
            CreateIndex("dbo.AbpUserNotifications", "TenantId");
            CreateIndex("dbo.AbpUserOrganizationUnits", "TenantId");
            CreateIndex("dbo.AbpUserOrganizationUnits", "IsDeleted");
        }
        
        public override void Down()
        {
            DropIndex("dbo.AbpUserOrganizationUnits", new[] { "IsDeleted" });
            DropIndex("dbo.AbpUserOrganizationUnits", new[] { "TenantId" });
            DropIndex("dbo.AbpUserNotifications", new[] { "TenantId" });
            DropIndex("dbo.AbpUserLoginAttempts", new[] { "TenantId" });
            DropIndex("dbo.AbpUserAccounts", new[] { "IsDeleted" });
            DropIndex("dbo.AbpTenants", new[] { "IsDeleted" });
            DropIndex("dbo.AbpTenantNotifications", new[] { "TenantId" });
            DropIndex("dbo.AbpSettings", new[] { "TenantId" });
            DropIndex("dbo.AbpUserRoles", new[] { "TenantId" });
            DropIndex("dbo.AbpUserLogins", new[] { "TenantId" });
            DropIndex("dbo.AbpUserClaims", new[] { "TenantId" });
            DropIndex("dbo.AbpUsers", new[] { "IsDeleted" });
            DropIndex("dbo.AbpUsers", new[] { "TenantId" });
            DropIndex("dbo.AbpRoles", new[] { "IsDeleted" });
            DropIndex("dbo.AbpRoles", new[] { "TenantId" });
            DropIndex("dbo.AbpPermissions", new[] { "TenantId" });
            DropIndex("dbo.AbpOrganizationUnits", new[] { "IsDeleted" });
            DropIndex("dbo.AbpOrganizationUnits", new[] { "TenantId" });
            DropIndex("dbo.AbpNotificationSubscriptions", new[] { "TenantId" });
            DropIndex("dbo.AbpLanguageTexts", new[] { "TenantId" });
            DropIndex("dbo.AbpLanguages", new[] { "IsDeleted" });
            DropIndex("dbo.AbpLanguages", new[] { "TenantId" });
            DropIndex("dbo.AbpEditions", new[] { "IsDeleted" });
            DropIndex("dbo.AbpFeatures", new[] { "TenantId" });
            DropIndex("dbo.AbpAuditLogs", new[] { "TenantId" });
        }
    }
}
