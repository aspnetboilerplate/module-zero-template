namespace AbpCompanyName.AbpProjectName.Migrations
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity.Infrastructure.Annotations;
    using System.Data.Entity.Migrations;
    
    public partial class Upgrated_To_ABP_4_8_0 : DbMigration
    {
        public override void Up()
        {
            AlterTableAnnotations(
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
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "DynamicFilter_OrganizationUnitRole_SoftDelete",
                        new AnnotationValues(oldValue: null, newValue: "EntityFramework.DynamicFilters.DynamicFilterDefinition")
                    },
                });
            
            AlterColumn("dbo.AbpLanguages", "Name", c => c.String(nullable: false, maxLength: 128));
            AlterColumn("dbo.AbpLanguageTexts", "LanguageName", c => c.String(nullable: false, maxLength: 128));
            CreateIndex("dbo.AbpOrganizationUnitRoles", "IsDeleted");
        }
        
        public override void Down()
        {
            DropIndex("dbo.AbpOrganizationUnitRoles", new[] { "IsDeleted" });
            AlterColumn("dbo.AbpLanguageTexts", "LanguageName", c => c.String(nullable: false, maxLength: 10));
            AlterColumn("dbo.AbpLanguages", "Name", c => c.String(nullable: false, maxLength: 10));
            AlterTableAnnotations(
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
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "DynamicFilter_OrganizationUnitRole_SoftDelete",
                        new AnnotationValues(oldValue: "EntityFramework.DynamicFilters.DynamicFilterDefinition", newValue: null)
                    },
                });
            
        }
    }
}
