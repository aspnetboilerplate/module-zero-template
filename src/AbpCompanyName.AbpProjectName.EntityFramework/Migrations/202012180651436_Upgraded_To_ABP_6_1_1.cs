namespace AbpCompanyName.AbpProjectName.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Upgraded_To_ABP_6_1_1 : DbMigration
    {
        public override void Up()
        {
            DropPrimaryKey("dbo.AbpDynamicPropertyValues");
            DropPrimaryKey("dbo.AbpDynamicEntityPropertyValues");
            AlterColumn("dbo.AbpDynamicPropertyValues", "Id", c => c.Long(nullable: false, identity: true));
            AlterColumn("dbo.AbpDynamicEntityPropertyValues", "Id", c => c.Long(nullable: false, identity: true));
            AddPrimaryKey("dbo.AbpDynamicPropertyValues", "Id");
            AddPrimaryKey("dbo.AbpDynamicEntityPropertyValues", "Id");
        }
        
        public override void Down()
        {
            DropPrimaryKey("dbo.AbpDynamicEntityPropertyValues");
            DropPrimaryKey("dbo.AbpDynamicPropertyValues");
            AlterColumn("dbo.AbpDynamicEntityPropertyValues", "Id", c => c.Int(nullable: false, identity: true));
            AlterColumn("dbo.AbpDynamicPropertyValues", "Id", c => c.Int(nullable: false, identity: true));
            AddPrimaryKey("dbo.AbpDynamicEntityPropertyValues", "Id");
            AddPrimaryKey("dbo.AbpDynamicPropertyValues", "Id");
        }
    }
}
