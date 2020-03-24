namespace AbpCompanyName.AbpProjectName.Migrations
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity.Infrastructure.Annotations;
    using System.Data.Entity.Migrations;
    
    public partial class Ugraded_To_ABP_5_4_0 : DbMigration
    {
        public override void Up()
        {
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
                .PrimaryKey(t => t.Id)
                .Index(t => new { t.ParameterName, t.TenantId }, unique: true)
                .Index(t => t.TenantId);
            
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
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AbpDynamicParameters", t => t.DynamicParameterId, cascadeDelete: true)
                .Index(t => t.TenantId)
                .Index(t => t.DynamicParameterId);
            
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
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AbpDynamicParameters", t => t.DynamicParameterId, cascadeDelete: true)
                .Index(t => new { t.EntityFullName, t.DynamicParameterId, t.TenantId }, unique: true)
                .Index(t => t.TenantId);
            
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
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AbpEntityDynamicParameters", t => t.EntityDynamicParameterId, cascadeDelete: true)
                .Index(t => t.EntityDynamicParameterId)
                .Index(t => t.TenantId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AbpEntityDynamicParameterValues", "EntityDynamicParameterId", "dbo.AbpEntityDynamicParameters");
            DropForeignKey("dbo.AbpEntityDynamicParameters", "DynamicParameterId", "dbo.AbpDynamicParameters");
            DropForeignKey("dbo.AbpDynamicParameterValues", "DynamicParameterId", "dbo.AbpDynamicParameters");
            DropIndex("dbo.AbpEntityDynamicParameterValues", new[] { "TenantId" });
            DropIndex("dbo.AbpEntityDynamicParameterValues", new[] { "EntityDynamicParameterId" });
            DropIndex("dbo.AbpEntityDynamicParameters", new[] { "TenantId" });
            DropIndex("dbo.AbpEntityDynamicParameters", new[] { "EntityFullName", "DynamicParameterId", "TenantId" });
            DropIndex("dbo.AbpDynamicParameterValues", new[] { "DynamicParameterId" });
            DropIndex("dbo.AbpDynamicParameterValues", new[] { "TenantId" });
            DropIndex("dbo.AbpDynamicParameters", new[] { "TenantId" });
            DropIndex("dbo.AbpDynamicParameters", new[] { "ParameterName", "TenantId" });
            DropTable("dbo.AbpEntityDynamicParameterValues",
                removedAnnotations: new Dictionary<string, object>
                {
                    { "DynamicFilter_EntityDynamicParameterValue_MayHaveTenant", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                });
            DropTable("dbo.AbpEntityDynamicParameters",
                removedAnnotations: new Dictionary<string, object>
                {
                    { "DynamicFilter_EntityDynamicParameter_MayHaveTenant", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                });
            DropTable("dbo.AbpDynamicParameterValues",
                removedAnnotations: new Dictionary<string, object>
                {
                    { "DynamicFilter_DynamicParameterValue_MayHaveTenant", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                });
            DropTable("dbo.AbpDynamicParameters",
                removedAnnotations: new Dictionary<string, object>
                {
                    { "DynamicFilter_DynamicParameter_MayHaveTenant", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                });
        }
    }
}
