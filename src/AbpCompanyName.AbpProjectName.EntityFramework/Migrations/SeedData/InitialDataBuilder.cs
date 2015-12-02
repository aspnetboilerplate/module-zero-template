using AbpCompanyName.AbpProjectName.EntityFramework;
using EntityFramework.DynamicFilters;

namespace AbpCompanyName.AbpProjectName.Migrations.SeedData
{
    public class InitialDataBuilder
    {
        private readonly AbpProjectNameDbContext _context;

        public InitialDataBuilder(AbpProjectNameDbContext context)
        {
            _context = context;
        }

        public void Build()
        {
            _context.DisableAllFilters();

            new DefaultEditionsBuilder(_context).Build();
            new DefaultTenantRoleAndUserBuilder(_context).Build();
            new DefaultLanguagesBuilder(_context).Build();
        }
    }
}
