namespace AbpCompanyName.AbpProjectName.Migrations
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity.Infrastructure.Annotations;
    using System.Data.Entity.Migrations;
    
    public partial class Ugraded_To_ABP_5_2_0 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.AbpWebhookEvents",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        WebhookName = c.String(nullable: false),
                        Data = c.String(),
                        CreationTime = c.DateTime(nullable: false),
                        TenantId = c.Int(),
                        IsDeleted = c.Boolean(nullable: false),
                        DeletionTime = c.DateTime(),
                    },
                annotations: new Dictionary<string, object>
                {
                    { "DynamicFilter_WebhookEvent_MayHaveTenant", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                    { "DynamicFilter_WebhookEvent_SoftDelete", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                })
                .PrimaryKey(t => t.Id)
                .Index(t => t.TenantId)
                .Index(t => t.IsDeleted);
            
            CreateTable(
                "dbo.AbpWebhookSendAttempts",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        WebhookEventId = c.Guid(nullable: false),
                        WebhookSubscriptionId = c.Guid(nullable: false),
                        Response = c.String(),
                        ResponseStatusCode = c.Int(),
                        CreationTime = c.DateTime(nullable: false),
                        LastModificationTime = c.DateTime(),
                        TenantId = c.Int(),
                    },
                annotations: new Dictionary<string, object>
                {
                    { "DynamicFilter_WebhookSendAttempt_MayHaveTenant", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AbpWebhookEvents", t => t.WebhookEventId, cascadeDelete: true)
                .Index(t => t.WebhookEventId)
                .Index(t => t.TenantId);
            
            CreateTable(
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
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AbpWebhookSendAttempts", "WebhookEventId", "dbo.AbpWebhookEvents");
            DropIndex("dbo.AbpWebhookSendAttempts", new[] { "TenantId" });
            DropIndex("dbo.AbpWebhookSendAttempts", new[] { "WebhookEventId" });
            DropIndex("dbo.AbpWebhookEvents", new[] { "IsDeleted" });
            DropIndex("dbo.AbpWebhookEvents", new[] { "TenantId" });
            DropTable("dbo.AbpWebhookSubscriptions");
            DropTable("dbo.AbpWebhookSendAttempts",
                removedAnnotations: new Dictionary<string, object>
                {
                    { "DynamicFilter_WebhookSendAttempt_MayHaveTenant", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                });
            DropTable("dbo.AbpWebhookEvents",
                removedAnnotations: new Dictionary<string, object>
                {
                    { "DynamicFilter_WebhookEvent_MayHaveTenant", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                    { "DynamicFilter_WebhookEvent_SoftDelete", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                });
        }
    }
}
