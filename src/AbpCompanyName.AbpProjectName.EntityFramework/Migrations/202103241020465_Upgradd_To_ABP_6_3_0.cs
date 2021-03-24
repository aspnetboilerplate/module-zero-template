namespace AbpCompanyName.AbpProjectName.Migrations
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity.Infrastructure.Annotations;
    using System.Data.Entity.Migrations;
    
    public partial class Upgradd_To_ABP_6_3_0 : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.AbpWebhookSubscriptions", new[] { "TenantId" });
            AlterTableAnnotations(
                "dbo.AbpWebhookSubscriptions",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        TenantId = c.Int(),
                        WebhookUri = c.String(nullable: false),
                        Secret = c.String(nullable: false),
                        IsActive = c.Boolean(nullable: false),
                        Webhooks = c.String(),
                        Headers = c.String(),
                        CreationTime = c.DateTime(nullable: false),
                        CreatorUserId = c.Long(),
                    },
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "DynamicFilter_WebhookSubscriptionInfo_MayHaveTenant",
                        new AnnotationValues(oldValue: "EntityFramework.DynamicFilters.DynamicFilterDefinition", newValue: null)
                    },
                });
            
            AddColumn("dbo.AbpAuditLogs", "ExceptionMessage", c => c.String(maxLength: 1024));
        }
        
        public override void Down()
        {
            DropColumn("dbo.AbpAuditLogs", "ExceptionMessage");
            AlterTableAnnotations(
                "dbo.AbpWebhookSubscriptions",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        TenantId = c.Int(),
                        WebhookUri = c.String(nullable: false),
                        Secret = c.String(nullable: false),
                        IsActive = c.Boolean(nullable: false),
                        Webhooks = c.String(),
                        Headers = c.String(),
                        CreationTime = c.DateTime(nullable: false),
                        CreatorUserId = c.Long(),
                    },
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "DynamicFilter_WebhookSubscriptionInfo_MayHaveTenant",
                        new AnnotationValues(oldValue: null, newValue: "EntityFramework.DynamicFilters.DynamicFilterDefinition")
                    },
                });
            
            CreateIndex("dbo.AbpWebhookSubscriptions", "TenantId");
        }
    }
}
