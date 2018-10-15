namespace AbpCompanyName.AbpProjectName.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Upgraded_To_ABP_v3_9_0 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.AbpUsers", "Name", c => c.String(nullable: false, maxLength: 64));
            AlterColumn("dbo.AbpUsers", "Surname", c => c.String(nullable: false, maxLength: 64));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.AbpUsers", "Surname", c => c.String(nullable: false, maxLength: 32));
            AlterColumn("dbo.AbpUsers", "Name", c => c.String(nullable: false, maxLength: 32));
        }
    }
}
