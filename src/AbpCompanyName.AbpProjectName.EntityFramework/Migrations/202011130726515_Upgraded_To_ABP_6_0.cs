namespace AbpCompanyName.AbpProjectName.Migrations
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity.Infrastructure.Annotations;
    using System.Data.Entity.Migrations;
    
    public partial class Upgraded_To_ABP_6_0 : DbMigration
    {
        public override void Up()
        {
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
            
            AddColumn("dbo.AbpDynamicProperties", "DisplayName", c => c.String());
            AddColumn("dbo.AbpEntityPropertyChanges", "NewValueHash", c => c.String());
            AddColumn("dbo.AbpEntityPropertyChanges", "OriginalValueHash", c => c.String());
            CreateIndex("dbo.AbpWebhookSubscriptions", "TenantId");
        }
        
        public override void Down()
        {
            DropIndex("dbo.AbpWebhookSubscriptions", new[] { "TenantId" });
            DropColumn("dbo.AbpEntityPropertyChanges", "OriginalValueHash");
            DropColumn("dbo.AbpEntityPropertyChanges", "NewValueHash");
            DropColumn("dbo.AbpDynamicProperties", "DisplayName");
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
            
        }
    }
}
