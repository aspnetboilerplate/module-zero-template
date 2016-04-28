using System.Data.Entity.Migrations;
using AbpCompanyName.AbpProjectName.Migrations.SeedData;
using EntityFramework.DynamicFilters;

namespace AbpCompanyName.AbpProjectName.Migrations
{
    internal sealed class Configuration : DbMigrationsConfiguration<AbpProjectName.EntityFramework.AbpProjectNameDbContext>
    {
        public SeedMode SeedMode { get; set; }

        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            ContextKey = "AbpProjectName";
        }

        protected override void Seed(AbpProjectName.EntityFramework.AbpProjectNameDbContext context)
        {
            context.DisableAllFilters();

            if (SeedMode == SeedMode.Host)
            {
                //Host seed
                new InitialHostDbBuilder(context).Create();

                //Default tenant seed (in host database).
                new DefaultTenantCreator(context).Create();
                new TenantRoleAndUserBuilder(context, 1).Create();
            }
            else if (SeedMode == SeedMode.Tenant)
            {
                //You can add seed for tenant databases...
            }

            context.SaveChanges();
        }
    }
}
