namespace AbpCompanyName.AbpProjectName.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Upgraded_To_Abp_v3_5 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.AbpUsers", "PhoneNumber", c => c.String(maxLength: 32));
            AlterColumn("dbo.AbpUsers", "SecurityStamp", c => c.String(maxLength: 128));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.AbpUsers", "SecurityStamp", c => c.String());
            AlterColumn("dbo.AbpUsers", "PhoneNumber", c => c.String());
        }
    }
}
