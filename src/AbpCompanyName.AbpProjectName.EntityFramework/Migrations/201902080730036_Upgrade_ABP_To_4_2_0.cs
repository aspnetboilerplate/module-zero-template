namespace AbpCompanyName.AbpProjectName.Migrations
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity.Infrastructure.Annotations;
    using System.Data.Entity.Migrations;
    
    public partial class Upgrade_ABP_To_4_2_0 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.AbpOrganizationUnitRoles",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        TenantId = c.Int(),
                        RoleId = c.Int(nullable: false),
                        OrganizationUnitId = c.Long(nullable: false),
                        IsDeleted = c.Boolean(nullable: false),
                        CreationTime = c.DateTime(nullable: false),
                        CreatorUserId = c.Long(),
                    },
                annotations: new Dictionary<string, object>
                {
                    { "DynamicFilter_OrganizationUnitRole_MayHaveTenant", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                })
                .PrimaryKey(t => t.Id)
                .Index(t => t.TenantId);
            
            AddColumn("dbo.AbpAuditLogs", "ReturnValue", c => c.String());
            AddColumn("dbo.AbpRoles", "NormalizedName", c => c.String(nullable: false, maxLength: 32));
            AddColumn("dbo.AbpUsers", "NormalizedUserName", c => c.String(nullable: false, maxLength: 256));
            AddColumn("dbo.AbpUsers", "NormalizedEmailAddress", c => c.String(nullable: false, maxLength: 256));
            DropColumn("dbo.AbpUsers", "LastLoginTime");
            DropColumn("dbo.AbpUserAccounts", "LastLoginTime");
        }
        
        public override void Down()
        {
            AddColumn("dbo.AbpUserAccounts", "LastLoginTime", c => c.DateTime());
            AddColumn("dbo.AbpUsers", "LastLoginTime", c => c.DateTime());
            DropIndex("dbo.AbpOrganizationUnitRoles", new[] { "TenantId" });
            DropColumn("dbo.AbpUsers", "NormalizedEmailAddress");
            DropColumn("dbo.AbpUsers", "NormalizedUserName");
            DropColumn("dbo.AbpRoles", "NormalizedName");
            DropColumn("dbo.AbpAuditLogs", "ReturnValue");
            DropTable("dbo.AbpOrganizationUnitRoles",
                removedAnnotations: new Dictionary<string, object>
                {
                    { "DynamicFilter_OrganizationUnitRole_MayHaveTenant", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                });
        }
    }
}
