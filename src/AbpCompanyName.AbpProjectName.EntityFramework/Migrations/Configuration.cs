using System.Data.Entity.Migrations;
using AbpCompanyName.AbpProjectName.Migrations.SeedData;
using EntityFramework.DynamicFilters;

namespace AbpCompanyName.AbpProjectName.Migrations
{
    internal sealed class Configuration : DbMigrationsConfiguration<AbpProjectName.EntityFramework.AbpProjectNameDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            ContextKey = "AbpProjectName";
        }

        protected override void Seed(AbpProjectName.EntityFramework.AbpProjectNameDbContext context)
        {
            context.DisableAllFilters();
            new InitialDataBuilder(context).Build();
        }
    }
}
