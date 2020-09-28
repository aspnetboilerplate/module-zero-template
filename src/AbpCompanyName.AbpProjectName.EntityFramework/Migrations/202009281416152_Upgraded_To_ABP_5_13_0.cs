namespace AbpCompanyName.AbpProjectName.Migrations
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity.Infrastructure.Annotations;
    using System.Data.Entity.Migrations;
    
    public partial class Upgraded_To_ABP_5_13_0 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.AbpDynamicParameterValues", "DynamicParameterId", "dbo.AbpDynamicParameters");
            DropForeignKey("dbo.AbpEntityDynamicParameters", "DynamicParameterId", "dbo.AbpDynamicParameters");
            DropForeignKey("dbo.AbpEntityDynamicParameterValues", "EntityDynamicParameterId", "dbo.AbpEntityDynamicParameters");
            DropIndex("dbo.AbpDynamicParameters", new[] { "ParameterName", "TenantId" });
            DropIndex("dbo.AbpDynamicParameters", new[] { "TenantId" });
            DropIndex("dbo.AbpDynamicParameterValues", new[] { "TenantId" });
            DropIndex("dbo.AbpDynamicParameterValues", new[] { "DynamicParameterId" });
            DropIndex("dbo.AbpEntityDynamicParameters", new[] { "EntityFullName", "DynamicParameterId", "TenantId" });
            DropIndex("dbo.AbpEntityDynamicParameters", new[] { "TenantId" });
            DropIndex("dbo.AbpEntityDynamicParameterValues", new[] { "EntityDynamicParameterId" });
            DropIndex("dbo.AbpEntityDynamicParameterValues", new[] { "TenantId" });
            CreateTable(
                "dbo.AbpDynamicEntityProperties",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        EntityFullName = c.String(maxLength: 250),
                        DynamicPropertyId = c.Int(nullable: false),
                        TenantId = c.Int(),
                    },
                annotations: new Dictionary<string, object>
                {
                    { "DynamicFilter_DynamicEntityProperty_MayHaveTenant", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AbpDynamicProperties", t => t.DynamicPropertyId, cascadeDelete: true)
                .Index(t => new { t.EntityFullName, t.DynamicPropertyId, t.TenantId }, unique: true)
                .Index(t => t.TenantId);
            
            CreateTable(
                "dbo.AbpDynamicProperties",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        PropertyName = c.String(maxLength: 250),
                        InputType = c.String(),
                        Permission = c.String(),
                        TenantId = c.Int(),
                    },
                annotations: new Dictionary<string, object>
                {
                    { "DynamicFilter_DynamicProperty_MayHaveTenant", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                })
                .PrimaryKey(t => t.Id)
                .Index(t => new { t.PropertyName, t.TenantId }, unique: true)
                .Index(t => t.TenantId);
            
            CreateTable(
                "dbo.AbpDynamicPropertyValues",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Value = c.String(nullable: false),
                        TenantId = c.Int(),
                        DynamicPropertyId = c.Int(nullable: false),
                    },
                annotations: new Dictionary<string, object>
                {
                    { "DynamicFilter_DynamicPropertyValue_MayHaveTenant", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AbpDynamicProperties", t => t.DynamicPropertyId, cascadeDelete: true)
                .Index(t => t.TenantId)
                .Index(t => t.DynamicPropertyId);
            
            CreateTable(
                "dbo.AbpDynamicEntityPropertyValues",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Value = c.String(nullable: false),
                        EntityId = c.String(),
                        DynamicEntityPropertyId = c.Int(nullable: false),
                        TenantId = c.Int(),
                    },
                annotations: new Dictionary<string, object>
                {
                    { "DynamicFilter_DynamicEntityPropertyValue_MayHaveTenant", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AbpDynamicEntityProperties", t => t.DynamicEntityPropertyId, cascadeDelete: true)
                .Index(t => t.DynamicEntityPropertyId)
                .Index(t => t.TenantId);
            
            DropTable("dbo.AbpDynamicParameters",
                removedAnnotations: new Dictionary<string, object>
                {
                    { "DynamicFilter_DynamicParameter_MayHaveTenant", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                });
            DropTable("dbo.AbpDynamicParameterValues",
                removedAnnotations: new Dictionary<string, object>
                {
                    { "DynamicFilter_DynamicParameterValue_MayHaveTenant", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                });
            DropTable("dbo.AbpEntityDynamicParameters",
                removedAnnotations: new Dictionary<string, object>
                {
                    { "DynamicFilter_EntityDynamicParameter_MayHaveTenant", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                });
            DropTable("dbo.AbpEntityDynamicParameterValues",
                removedAnnotations: new Dictionary<string, object>
                {
                    { "DynamicFilter_EntityDynamicParameterValue_MayHaveTenant", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                });
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.AbpEntityDynamicParameterValues",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Value = c.String(nullable: false),
                        EntityId = c.String(),
                        EntityDynamicParameterId = c.Int(nullable: false),
                        TenantId = c.Int(),
                    },
                annotations: new Dictionary<string, object>
                {
                    { "DynamicFilter_EntityDynamicParameterValue_MayHaveTenant", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.AbpEntityDynamicParameters",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        EntityFullName = c.String(maxLength: 250),
                        DynamicParameterId = c.Int(nullable: false),
                        TenantId = c.Int(),
                    },
                annotations: new Dictionary<string, object>
                {
                    { "DynamicFilter_EntityDynamicParameter_MayHaveTenant", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.AbpDynamicParameterValues",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Value = c.String(nullable: false),
                        TenantId = c.Int(),
                        DynamicParameterId = c.Int(nullable: false),
                    },
                annotations: new Dictionary<string, object>
                {
                    { "DynamicFilter_DynamicParameterValue_MayHaveTenant", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.AbpDynamicParameters",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ParameterName = c.String(maxLength: 250),
                        InputType = c.String(),
                        Permission = c.String(),
                        TenantId = c.Int(),
                    },
                annotations: new Dictionary<string, object>
                {
                    { "DynamicFilter_DynamicParameter_MayHaveTenant", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                })
                .PrimaryKey(t => t.Id);
            
            DropForeignKey("dbo.AbpDynamicEntityPropertyValues", "DynamicEntityPropertyId", "dbo.AbpDynamicEntityProperties");
            DropForeignKey("dbo.AbpDynamicEntityProperties", "DynamicPropertyId", "dbo.AbpDynamicProperties");
            DropForeignKey("dbo.AbpDynamicPropertyValues", "DynamicPropertyId", "dbo.AbpDynamicProperties");
            DropIndex("dbo.AbpDynamicEntityPropertyValues", new[] { "TenantId" });
            DropIndex("dbo.AbpDynamicEntityPropertyValues", new[] { "DynamicEntityPropertyId" });
            DropIndex("dbo.AbpDynamicPropertyValues", new[] { "DynamicPropertyId" });
            DropIndex("dbo.AbpDynamicPropertyValues", new[] { "TenantId" });
            DropIndex("dbo.AbpDynamicProperties", new[] { "TenantId" });
            DropIndex("dbo.AbpDynamicProperties", new[] { "PropertyName", "TenantId" });
            DropIndex("dbo.AbpDynamicEntityProperties", new[] { "TenantId" });
            DropIndex("dbo.AbpDynamicEntityProperties", new[] { "EntityFullName", "DynamicPropertyId", "TenantId" });
            DropTable("dbo.AbpDynamicEntityPropertyValues",
                removedAnnotations: new Dictionary<string, object>
                {
                    { "DynamicFilter_DynamicEntityPropertyValue_MayHaveTenant", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                });
            DropTable("dbo.AbpDynamicPropertyValues",
                removedAnnotations: new Dictionary<string, object>
                {
                    { "DynamicFilter_DynamicPropertyValue_MayHaveTenant", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                });
            DropTable("dbo.AbpDynamicProperties",
                removedAnnotations: new Dictionary<string, object>
                {
                    { "DynamicFilter_DynamicProperty_MayHaveTenant", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                });
            DropTable("dbo.AbpDynamicEntityProperties",
                removedAnnotations: new Dictionary<string, object>
                {
                    { "DynamicFilter_DynamicEntityProperty_MayHaveTenant", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                });
            CreateIndex("dbo.AbpEntityDynamicParameterValues", "TenantId");
            CreateIndex("dbo.AbpEntityDynamicParameterValues", "EntityDynamicParameterId");
            CreateIndex("dbo.AbpEntityDynamicParameters", "TenantId");
            CreateIndex("dbo.AbpEntityDynamicParameters", new[] { "EntityFullName", "DynamicParameterId", "TenantId" }, unique: true);
            CreateIndex("dbo.AbpDynamicParameterValues", "DynamicParameterId");
            CreateIndex("dbo.AbpDynamicParameterValues", "TenantId");
            CreateIndex("dbo.AbpDynamicParameters", "TenantId");
            CreateIndex("dbo.AbpDynamicParameters", new[] { "ParameterName", "TenantId" }, unique: true);
            AddForeignKey("dbo.AbpEntityDynamicParameterValues", "EntityDynamicParameterId", "dbo.AbpEntityDynamicParameters", "Id", cascadeDelete: true);
            AddForeignKey("dbo.AbpEntityDynamicParameters", "DynamicParameterId", "dbo.AbpDynamicParameters", "Id", cascadeDelete: true);
            AddForeignKey("dbo.AbpDynamicParameterValues", "DynamicParameterId", "dbo.AbpDynamicParameters", "Id", cascadeDelete: true);
        }
    }
}
