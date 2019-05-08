namespace AbpCompanyName.AbpProjectName.Migrations
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity.Infrastructure.Annotations;
    using System.Data.Entity.Migrations;
    
    public partial class Upgrade_ABP_To_4_5_0 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.AbpEntityChanges",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        ChangeTime = c.DateTime(nullable: false),
                        ChangeType = c.Byte(nullable: false),
                        EntityChangeSetId = c.Long(nullable: false),
                        EntityId = c.String(maxLength: 48),
                        EntityTypeFullName = c.String(maxLength: 192),
                        TenantId = c.Int(),
                    },
                annotations: new Dictionary<string, object>
                {
                    { "DynamicFilter_EntityChange_MayHaveTenant", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AbpEntityChangeSets", t => t.EntityChangeSetId, cascadeDelete: true)
                .Index(t => t.EntityChangeSetId)
                .Index(t => new { t.EntityTypeFullName, t.EntityId })
                .Index(t => t.TenantId);
            
            CreateTable(
                "dbo.AbpEntityPropertyChanges",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        EntityChangeId = c.Long(nullable: false),
                        NewValue = c.String(maxLength: 512),
                        OriginalValue = c.String(maxLength: 512),
                        PropertyName = c.String(maxLength: 96),
                        PropertyTypeFullName = c.String(maxLength: 192),
                        TenantId = c.Int(),
                    },
                annotations: new Dictionary<string, object>
                {
                    { "DynamicFilter_EntityPropertyChange_MayHaveTenant", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AbpEntityChanges", t => t.EntityChangeId, cascadeDelete: true)
                .Index(t => t.EntityChangeId)
                .Index(t => t.TenantId);
            
            CreateTable(
                "dbo.AbpEntityChangeSets",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        BrowserInfo = c.String(maxLength: 512),
                        ClientIpAddress = c.String(maxLength: 64),
                        ClientName = c.String(maxLength: 128),
                        CreationTime = c.DateTime(nullable: false),
                        ExtensionData = c.String(),
                        ImpersonatorTenantId = c.Int(),
                        ImpersonatorUserId = c.Long(),
                        Reason = c.String(maxLength: 256),
                        TenantId = c.Int(),
                        UserId = c.Long(),
                    },
                annotations: new Dictionary<string, object>
                {
                    { "DynamicFilter_EntityChangeSet_MayHaveTenant", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                })
                .PrimaryKey(t => t.Id)
                .Index(t => t.CreationTime, name: "IX_TenantId_CreationTime")
                .Index(t => new { t.TenantId, t.Reason })
                .Index(t => t.TenantId)
                .Index(t => t.UserId, name: "IX_TenantId_UserId");
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AbpEntityChanges", "EntityChangeSetId", "dbo.AbpEntityChangeSets");
            DropForeignKey("dbo.AbpEntityPropertyChanges", "EntityChangeId", "dbo.AbpEntityChanges");
            DropIndex("dbo.AbpEntityChangeSets", "IX_TenantId_UserId");
            DropIndex("dbo.AbpEntityChangeSets", new[] { "TenantId" });
            DropIndex("dbo.AbpEntityChangeSets", new[] { "TenantId", "Reason" });
            DropIndex("dbo.AbpEntityChangeSets", "IX_TenantId_CreationTime");
            DropIndex("dbo.AbpEntityPropertyChanges", new[] { "TenantId" });
            DropIndex("dbo.AbpEntityPropertyChanges", new[] { "EntityChangeId" });
            DropIndex("dbo.AbpEntityChanges", new[] { "TenantId" });
            DropIndex("dbo.AbpEntityChanges", new[] { "EntityTypeFullName", "EntityId" });
            DropIndex("dbo.AbpEntityChanges", new[] { "EntityChangeSetId" });
            DropTable("dbo.AbpEntityChangeSets",
                removedAnnotations: new Dictionary<string, object>
                {
                    { "DynamicFilter_EntityChangeSet_MayHaveTenant", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                });
            DropTable("dbo.AbpEntityPropertyChanges",
                removedAnnotations: new Dictionary<string, object>
                {
                    { "DynamicFilter_EntityPropertyChange_MayHaveTenant", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                });
            DropTable("dbo.AbpEntityChanges",
                removedAnnotations: new Dictionary<string, object>
                {
                    { "DynamicFilter_EntityChange_MayHaveTenant", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                });
        }
    }
}
