using AbpCompanyName.AbpProjectName.EntityFramework;

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
            new DefaultTenantRoleAndUserBuilder(_context).Build();
        }
    }
}
