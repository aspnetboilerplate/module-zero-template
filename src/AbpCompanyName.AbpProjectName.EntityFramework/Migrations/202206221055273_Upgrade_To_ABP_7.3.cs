namespace AbpCompanyName.AbpProjectName.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Upgrade_To_ABP_73 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AbpNotifications", "TargetNotifiers", c => c.String());
            AddColumn("dbo.AbpUserNotifications", "TargetNotifiers", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.AbpUserNotifications", "TargetNotifiers");
            DropColumn("dbo.AbpNotifications", "TargetNotifiers");
        }
    }
}
