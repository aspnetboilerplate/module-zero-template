using AbpZeroSample.Migrations.SeedData;
using EntityFramework.DynamicFilters;

namespace AbpZeroSample.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<AbpZeroSample.EntityFramework.AbpZeroSampleDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            ContextKey = "AbpZeroSample";
        }

        protected override void Seed(AbpZeroSample.EntityFramework.AbpZeroSampleDbContext context)
        {
            context.DisableAllFilters();
            new DefaultTenantRoleAndUserBuilder(context).Build();
        }
    }
}
