using System.Data.Entity.Migrations;
using AbpCompanyName.AbpProjectName.Migrations.SeedData;

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
            new InitialDataBuilder(context).Build();
        }
    }
}
